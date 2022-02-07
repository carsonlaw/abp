using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FreeERP.Products
{
    public interface IProductAppService
    {
        Task<ProductDto> GetAsync(Guid id);
        Task<PagedResultDto<ProductDto>> GetListAsync(ProductGetListInput input);

        Task<ProductDto> CreateAsync(ProductCreateUpdateDto input);

        Task<ProductDto> UpdateAsync(Guid id, ProductCreateUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}