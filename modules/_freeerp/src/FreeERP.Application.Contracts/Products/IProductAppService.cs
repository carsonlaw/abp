using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeERP.Products
{
    public interface IProductAppService
    {
        Task<IList<ProductDto>> GetListAsync();

        Task<ProductDto> CreateAsync(ProductCreateUpdateDto input);

        Task<ProductDto> UpdateAsync(Guid id, ProductCreateUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}