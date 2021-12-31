using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace FreeERP.Products
{
    public interface ICategoryAppService : ICrudAppService<CategoryDto, Guid, CategoryGetListInput, CategoryCreateUpdateDto, CategoryCreateUpdateDto>
    {
        Task<IList<CategoryDto>> GetCategoryTree();
        Task<int> GetNextSortByPid(Guid? Pid);
    }
}