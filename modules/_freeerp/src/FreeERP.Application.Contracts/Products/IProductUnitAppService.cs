using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace FreeERP.Products
{
    public interface IProductUnitAppService : ICrudAppService<ProductUnitDto, Guid, ProductUnitGetListInput, ProductUnitCreateUpdateDto, ProductUnitCreateUpdateDto>
    {

        Task<IList<ProductUnitDto>> GetAllListFromCache();
        Task<IList<ProductUnitDto>> GetUnitTree();
    }
}