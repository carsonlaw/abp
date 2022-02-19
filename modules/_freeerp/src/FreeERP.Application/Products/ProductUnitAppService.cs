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
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Caching;
using Microsoft.Extensions.Logging;

namespace FreeERP.Products
{
    [Authorize(FreeERPPermissions.Categories.Default)]
    public class ProductUnitAppService : CrudAppService<ProductUnit, ProductUnitDto, Guid, ProductUnitGetListInput, ProductUnitCreateUpdateDto, ProductUnitCreateUpdateDto>
    , IProductUnitAppService
    {
        private readonly IDistributedCache<IList<ProductUnitDto>> _cache;
        IProductUnitRepository _repository;
        ProductUnitManager _manager;

        public ProductUnitAppService(
            IProductUnitRepository repository,
            ProductUnitManager manager,
            IDistributedCache<IList<ProductUnitDto>> cache)
        : base(repository)
        {
            _repository = repository;
            _manager = manager;
            _cache = cache;
        }

        [Authorize(FreeERPPermissions.Categories.Create)]
        public override async Task<ProductUnitDto> CreateAsync(ProductUnitCreateUpdateDto input)
        {
            var entity = await _manager.CreateAsync(input.Pid, input.Name, input.Description, input.RatioCount, input.Sort);
            await _repository.InsertAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.Categories.Update)]
        public override async Task<ProductUnitDto> UpdateAsync(Guid id, ProductUnitCreateUpdateDto input)
        {
            var entity = await _repository.GetAsync(id);
            entity = await _manager.UpdateAsync(entity, input.Pid, input.Name, input.Description, input.RatioCount, input.Sort);
            await _repository.UpdateAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.Categories.Delete)]
        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }

        protected override async Task<ProductUnit> GetEntityByIdAsync(Guid id)
        {
            return await _repository.GetAsync(f => f.Id == id, true);
        }


        protected override async Task<IQueryable<ProductUnit>> CreateFilteredQueryAsync(ProductUnitGetListInput input)
        {
            var ret = await base.CreateFilteredQueryAsync(input);
            ret = ret.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), f => f.Name.Contains(input.Filter));
            ret = ret.WhereIf(input.Pid != null || !input.PidNullIsAll, f => f.SmallerUnit.Id == input.Pid);

            return ret;
        }

        public async Task<IList<ProductUnitDto>> GetAllListFromCache()
        {
            return await _cache.GetOrAddAsync(
                FreeERPDomainCacheKeys.ProductUnit.AllList,
                async () =>
                {
                    Logger.Log(LogLevel.Debug, $"no cache key '{FreeERPDomainCacheKeys.ProductUnit.AllList}'");
                    var input = new ProductUnitGetListInput()
                    {
                        PidNullIsAll = true,
                    };

                    var query = await CreateFilteredQueryAsync(input);
                    query = ApplyDefaultSorting(query);
                    return await MapToGetListOutputDtosAsync(query.ToList());
                },
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddDays(20)
                }
            );

        }

        public async Task<IList<ProductUnitDto>> GetUnitTree()
        {
            var list = await GetAllListFromCache();
            return await buildTree(list, null);

        }

        private async Task<IList<ProductUnitDto>> buildTree(IList<ProductUnitDto> query, Guid? pid)
        {
            var list = (query.Where(f => (pid == null && f.SmallerUnit == null) || (f.SmallerUnit != null && f.SmallerUnit.Id == pid))
                .ToList()
            );

            for (int i = 0; i < list.Count(); i++)
            {
                list[i].BiggerUnits = await buildTree(query, list[i].Id);
            }

            return list.ToList();
        }

    }
}