using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using FreeERP.Permissions;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Caching;
using Microsoft.Extensions.Logging;

namespace FreeERP.Stories
{
    [Authorize(FreeERPPermissions.Stories.Default)]
    public class StoreAppService : CrudAppService<Store, StoreDto, Guid, StoreGetListInput, StoreCreateUpdateDto, StoreCreateUpdateDto>
    , IStoreAppService
    {
        private readonly IDistributedCache<IList<StoreDto>> _cache;
        IStoreRepository _repository;
        StoreManager _manager;

        public StoreAppService(
            IStoreRepository repository,
            StoreManager manager,
            IDistributedCache<IList<StoreDto>> cache)
        : base(repository)
        {
            _repository = repository;
            _manager = manager;
            _cache = cache;
        }

        [Authorize(FreeERPPermissions.Stories.Create)]
        public override async Task<StoreDto> CreateAsync(StoreCreateUpdateDto input)
        {
            var entity = await _manager.CreateAsync(input.Name, input.Description, input.Sort);
            await _repository.InsertAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.Stories.Update)]
        public override async Task<StoreDto> UpdateAsync(Guid id, StoreCreateUpdateDto input)
        {
            var entity = await _repository.GetAsync(id);
            entity = await _manager.UpdateAsync(entity, input.Name, input.Description, input.Sort);
            await _repository.UpdateAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.Stories.Delete)]
        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }

        protected override async Task<Store> GetEntityByIdAsync(Guid id)
        {
            return await _repository.GetAsync(f => f.Id == id, true);
        }

        public async Task<IList<StoreSelectDto>> GetSelectData()
        {
            var input = new StoreGetListInput() { };
            var list = await CreateFilteredQueryAsync(input);

            return list.Select(f => new StoreSelectDto()
            {
                Id = f.Id,
                Name = f.Name
            }).ToList();
        }


        protected override async Task<IQueryable<Store>> CreateFilteredQueryAsync(StoreGetListInput input)
        {
            var list = await _cache.GetOrAddAsync(
                FreeERPDomainCacheKeys.Store.AllList,
                async () =>
                {
                    Logger.Log(LogLevel.Debug, $"no cache key '{FreeERPDomainCacheKeys.Store.AllList}'");

                    var query = await base.CreateFilteredQueryAsync(new StoreGetListInput() { });
                    return await MapToGetListOutputDtosAsync(query.ToList());
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(FreeERPDomainCacheKeys.Store.AllListMin)
                }
            );
            var query = ObjectMapper.Map<IList<StoreDto>, IList<Store>>(list).AsQueryable();

            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), f => f.Name.Contains(input.Filter));

            return query;
        }




    }
}