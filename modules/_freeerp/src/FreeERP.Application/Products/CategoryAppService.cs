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

namespace FreeERP.Products
{
    [Authorize(FreeERPPermissions.Categories.Default)]
    public class CategoryAppService : CrudAppService<Category, CategoryDto, Guid, CategoryGetListInput, CategoryCreateUpdateDto, CategoryCreateUpdateDto>
    , ICategoryAppService
    {
        ICategoryRepository _repository;
        CategroyManager _manager;

        public CategoryAppService(ICategoryRepository repository, CategroyManager manager)
        : base(repository)
        {
            _repository = repository;
            _manager = manager;
        }

        [Authorize(FreeERPPermissions.Categories.Create)]
        public override Task<CategoryDto> CreateAsync(CategoryCreateUpdateDto input)
        {
            var entity = _manager.CreateAsync(input.Name, input.Slug, input.Pid);
            return base.CreateAsync(input);
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


        public async Task<IList<CategoryDto>> GetCategoryTree(CategoryGetListInput input)
        {
            input.PidNullIsAll = true;
            var query = await CreateFilteredQueryAsync(input);
            return await buildTree(query, input.Pid);

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

        protected override async Task<IQueryable<Category>> CreateFilteredQueryAsync(CategoryGetListInput input)
        {
            var ret = await base.CreateFilteredQueryAsync(input);
            ret = ret.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), f => f.Name.Contains(input.Filter));
            ret = ret.WhereIf(input.Pid != null || !input.PidNullIsAll, f => f.Pid == input.Pid);
            return ret;
        }
    }
}