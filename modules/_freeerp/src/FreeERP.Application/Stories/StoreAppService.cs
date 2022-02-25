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

        public override async Task<PagedResultDto<StoreDto>> GetListAsync(StoreGetListInput input)
        {
            var list = (await GetAllListFromCache()).AsQueryable();
            var length = list.Count();
            list = list.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), f => f.Name.Contains(input.Filter));
            if (string.IsNullOrEmpty(input.Sorting))
                list = list.OrderBy(f => f.Sort);
            else
                list = list.OrderBy(input.Sorting);
            list = list.Skip(input.SkipCount).Take(input.MaxResultCount);
            return new PagedResultDto<StoreDto>(length, list.ToList());
        }


        protected override async Task<IQueryable<Store>> CreateFilteredQueryAsync(StoreGetListInput input)
        {
            var ret = await base.CreateFilteredQueryAsync(input);
            ret = ret.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), f => f.Name.Contains(input.Filter));

            return ret;
        }

        public async Task<IList<StoreDto>> GetAllListFromCache()
        {
            return await _cache.GetOrAddAsync(
                FreeERPDomainCacheKeys.Store.AllList,
                async () =>
                {
                    Logger.Log(LogLevel.Debug, $"no cache key '{FreeERPDomainCacheKeys.Store.AllList}'");
                    var input = new StoreGetListInput()
                    {
                    };

                    var query = await CreateFilteredQueryAsync(input);
                    query = ApplyDefaultSorting(query);
                    return await MapToGetListOutputDtosAsync(query.ToList());
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(FreeERPDomainCacheKeys.Store.AllListMin)
                }
            );

        }



    }
}