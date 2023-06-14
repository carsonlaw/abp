using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FreeERP.Products
{
    public interface IProductAppService : ICrudAppService<ProductDto, System.Guid, ProductGetListInput, ProductCreateUpdateDto, ProductCreateUpdateDto>
    {
        //Task<ProductDto> GetAsync(Guid id);
        Task<ProductDto> GetProductDOrSKUByCode(string code);
        //Task<PagedResultDto<ProductDto>> GetListAsync(ProductGetListInput input);

        //Task<ProductDto> CreateAsync(ProductCreateUpdateDto input);

        //Task<ProductDto> UpdateAsync(Guid id, ProductCreateUpdateDto input);

        //Task DeleteAsync(Guid id);
    }
}