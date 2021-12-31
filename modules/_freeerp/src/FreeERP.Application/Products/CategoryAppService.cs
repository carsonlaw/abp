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
    public class CategoryAppService : CrudAppService<Category, CategoryDto, Guid, CategoryGetListInput, CategoryCreateUpdateDto, CategoryCreateUpdateDto>
    , ICategoryAppService
    {
        private readonly IDistributedCache<IList<CategoryDto>> _cache;
        ICategoryRepository _repository;
        CategoryManager _manager;

        public CategoryAppService(
            ICategoryRepository repository,
            CategoryManager manager,
            IDistributedCache<IList<CategoryDto>> cache)
        : base(repository)
        {
            _repository = repository;
            _manager = manager;
            _cache = cache;
        }

        [Authorize(FreeERPPermissions.Categories.Create)]
        public override async Task<CategoryDto> CreateAsync(CategoryCreateUpdateDto input)
        {
            var entity = await _manager.CreateAsync(input.Name, input.Slug, input.Pid);
            await _repository.InsertAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.Categories.Update)]
        public override async Task<CategoryDto> UpdateAsync(Guid id, CategoryCreateUpdateDto input)
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


        public async Task<IList<CategoryDto>> GetCategoryTree()
        {
            return await _cache.GetOrAddAsync(FreeERPDomainCacheKeys.Category.AllTree,
            async () =>
            {
                var input = new CategoryGetListInput()
                {
                    PidNullIsAll = true,
                };
                var query = await CreateFilteredQueryAsync(input);
                query = ApplyDefaultSorting(query);
                return await buildTree(query, input.Pid);
            },
            () => new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromDays(30)
            }
            );
        }

        [Authorize(FreeERPPermissions.Categories.Create)]
        public async Task<int> GetNextSortByPid(Guid? Pid)
        {
            return await _repository.GetNextSortByPid(Pid);
        }

        private async Task<IList<CategoryDto>> buildTree(IQueryable<Category> query, Guid? pid)
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
        protected override IQueryable<Category> ApplyDefaultSorting(IQueryable<Category> query)
        {
            return query.OrderBy(f => f.Sort);
        }
        protected override async Task<IQueryable<Category>> CreateFilteredQueryAsync(CategoryGetListInput input)
        {
            var ret = await base.CreateFilteredQueryAsync(input);
            ret = ret.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), f => f.Name.Contains(input.Filter));
            ret = ret.WhereIf(input.Pid != null || !input.PidNullIsAll, f => f.Pid == input.Pid);
            return ret;
        }
    }
}