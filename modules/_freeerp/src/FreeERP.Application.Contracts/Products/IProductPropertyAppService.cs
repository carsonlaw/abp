using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeERP.Products
{
    public interface IProductPropertyAppService
    {
        Task<IList<ProductPropertyDto>> GetListAsync();

        Task<ProductPropertyDto> CreateAsync(ProductPropertyDto input);

        Task<ProductPropertyDto> UpdateAsync(Guid id, ProductPropertyDto input);

        Task DeleteAsync(Guid id);
    }
}