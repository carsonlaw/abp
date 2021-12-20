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
    public class CategoryAppService : CrudAppService<Category, CategoryDto, Guid, CategoryGetListInput, CreateUpdateCategoryDto, CreateUpdateCategoryDto>
    , ICategoryAppService
    {
        public CategoryAppService(IRepository<Category, Guid> repository) : base(repository)
        {
        }

        public async Task<IList<CategoryDto>> GetCategoryTree(CategoryGetListInput input)
        {
            var query = await CreateFilteredQueryAsync(input);
            return await buildTree(query, input.Pid);

        }

        private async Task<IList<CategoryDto>> buildTree(IQueryable<Category> query, Guid? pid)
        {
            var list = query.Where(f => f.Pid == pid)
            .ToList()
            .Select(f => MapToGetOutputDto(f));
            foreach (var cate in list)
            {
                cate.Items = await buildTree(query, cate.Id);
            }
            return list.ToList();
        }

        protected override async Task<IQueryable<Category>> CreateFilteredQueryAsync(CategoryGetListInput input)
        {
            var ret = await base.CreateFilteredQueryAsync(input);
            ret = ret.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), f => f.Name.Contains(input.Filter));
            ret = ret.WhereIf(input.Pid != null, f => f.Pid == input.Pid);
            return ret;
        }
    }
}