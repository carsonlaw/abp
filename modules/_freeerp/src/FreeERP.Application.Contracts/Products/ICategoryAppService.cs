using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace FreeERP.Products
{
    public interface ICategoryAppService : ICrudAppService<CategoryDto, Guid, CategoryGetListInput, CreateUpdateCategoryDto, CreateUpdateCategoryDto>
    {
        Task<IList<CategoryDto>> GetCategoryTree(CategoryGetListInput input);
    }
}