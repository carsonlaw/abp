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

namespace FreeERP.Products
{
    [Authorize(FreeERPPermissions.Categories.Default)]
    public class ProductUnitAppService : CrudAppService<ProductUnit, ProductUnitDto, Guid, PagedAndSortedResultRequestDto, ProductUnitCreateUpdateDto, ProductUnitCreateUpdateDto>
    , IProductUnitAppService
    {
        private readonly IDistributedCache<IList<ProductUnitDto>> _cache;
        IProductUnitRepository _repository;
        //ProductUnitManager _manager;

        public ProductUnitAppService(
            IProductUnitRepository repository,
            //ProductUnitManager manager,
            IDistributedCache<IList<ProductUnitDto>> cache)
        : base(repository)
        {
            _repository = repository;
            //_manager = manager;
            _cache = cache;
        }

        [Authorize(FreeERPPermissions.Categories.Create)]
        public override Task<ProductUnitDto> CreateAsync(ProductUnitCreateUpdateDto input)
        {
            var entity = new ProductUnit();
            return base.CreateAsync(input);
        }
        [Authorize(FreeERPPermissions.Categories.Update)]
        public override async Task<ProductUnitDto> UpdateAsync(Guid id, ProductUnitCreateUpdateDto input)
        {
            var cate = await _repository.GetAsync(id);
            cate = await _manager.UpdateAsync(cate, input.Name, input.Slug, input.Pid);
            await _repository.UpdateAsync(cate);
            return await MapToGetOutputDtoAsync(cate);
        }
        [Authorize(FreeERPPermissions.Categories.Delete)]
        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }


        public async Task<IList<ProductUnitDto>> GetProductUnitTree()
        {
            return await _cache.GetOrAddAsync(FreeERPDomainCacheKeys.ProductUnit.AllTree,
            async () =>
            {
                var input = new ProductUnitGetListInput()
                {
                    PidNullIsAll = true,
                };
                var query = await CreateFilteredQueryAsync(input);
                var query = cr
                query = ApplyDefaultSorting(query);
                return await buildTree(query, input.Pid);
            },
            () => new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromDays(30)
            }
            );
        }

        private async Task<IList<ProductUnitDto>> buildTree(IQueryable<ProductUnit> query, Guid? pid)
        {
            var list = await MapToGetListOutputDtosAsync(query.Where(f => f.Pid == pid)
                .ToList()
            );
            for (int i = 0; i < list.Count(); i++)
            {
                list[i].Items = await buildTree(query, list[i].Id);
            }

            return list.ToList();
        }


        public Task<IList<ProductUnitDto>> GetAllUnit()
        {
            throw new NotImplementedException();
        }
    }
}