using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeERP.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;

namespace FreeERP.Products
{

    [Authorize(FreeERPPermissions.ProductProperties.Default)]
    public class ProductPropertyAppService : FreeERPAppService, IProductPropertyAppService
    {
        readonly IProductPropertyRepository _repository;
        readonly ProductPropertyManager _manager;
        public ProductPropertyAppService(IProductPropertyRepository repository,
            ProductPropertyManager manager)
        {
            _repository = repository;
            _manager = manager;
        }


        [Authorize(FreeERPPermissions.ProductProperties.Create)]
        public async Task<ProductPropertyDto> CreateAsync(ProductPropertyDto input)
        {
            var items = input.Items.Select(f => f.Name).ToList();
            var productProperty = await _manager.CreateAsync(
                input.Name,
                input.Description,
                items
                                                    );

            await _repository.InsertAsync(productProperty);

            return ObjectMapper.Map<ProductProperty, ProductPropertyDto>(productProperty);
        }

        [Authorize(FreeERPPermissions.ProductProperties.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IList<ProductPropertyDto>> GetListAsync()
        {
            var ret = await _repository.GetListAsync(false);
            ret = ret.WhereIf(true, f => f.Parent == null).ToList();

            return ObjectMapper.Map<List<ProductProperty>, IList<ProductPropertyDto>>(ret);
        }


        [Authorize(FreeERPPermissions.ProductProperties.Update)]
        public async Task<ProductPropertyDto> UpdateAsync(Guid id, ProductPropertyDto input)
        {
            var items = input.Items.Select(f => (f.Id, f.Name)).ToList();
            var productProperty = await _repository.GetAsync(f => f.Id == id, true);
            productProperty = await _manager.UpdateAsync(productProperty,
                input.Name,
                input.Description,
                items
            );

            await _repository.UpdateAsync(productProperty);

            return ObjectMapper.Map<ProductProperty, ProductPropertyDto>(productProperty);
        }
    }
}