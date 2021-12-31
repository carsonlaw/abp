using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace FreeERP.Products
{
    public interface IProductUnitAppService : ICrudAppService<ProductUnitDto, Guid, PagedAndSortedResultRequestDto, ProductUnitCreateUpdateDto, ProductUnitCreateUpdateDto>
    {
        Task<IList<ProductUnitDto>> GetAllUnit();
    }
}