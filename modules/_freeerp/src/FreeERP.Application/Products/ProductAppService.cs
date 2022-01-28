using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeERP.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;

namespace FreeERP.Products
{

    [Authorize(FreeERPPermissions.Products.Default)]
    public class ProductAppService : FreeERPAppService, IProductAppService
    {
        readonly IProductRepository _repository;
        readonly IProductSKURepository _skuRepository;
        readonly ProductManager _manager;
        readonly ProductSKUManager _skuManager;
        public ProductAppService(IProductRepository repository,
            IProductSKURepository skuRepository,
            ProductManager manager)
        {
            _repository = repository;
            _skuRepository = skuRepository;
            _manager = manager;
        }


        [Authorize(FreeERPPermissions.Products.Create)]
        public async Task<ProductDto> CreateAsync(ProductCreateUpdateDto input)
        {
            var product = await _manager.CreateAsync(
                input.CategoryId,
                input.Name,
                input.Code,
                input.UnitId,
                input.MediaId,
                input.Description
            );
            await _repository.InsertAsync(product);

            foreach (var sku in input.Items)
            {
                var productSKU = await _skuManager.CreateSKUAsync(
                    product.Id,
                    sku.Name,
                    sku.Code,
                    sku.UnitId,
                    sku.MediaId,
                    sku.Description
                );
                await _skuRepository.InsertAsync(productSKU);
            }

            return ObjectMapper.Map<Product, ProductDto>(product);
        }


        [Authorize(FreeERPPermissions.Products.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
            await _skuRepository.DeleteByProductIdAsync(id);
        }

        public async Task<IList<ProductDto>> GetListAsync()
        {
            var ret = await _repository.GetListAsync(false);
            var items = await _skuRepository.GetListByProductIdsAsync(ret.Select(f => f.Id));

            return ObjectMapper.Map<List<Product>, IList<ProductDto>>(ret);
        }


        [Authorize(FreeERPPermissions.Products.Update)]
        public async Task<ProductDto> UpdateAsync(Guid id, ProductCreateUpdateDto input)
        {
            var product = await _repository.GetAsync(id, true);
            product = await _manager.UpdateAsync(product,
                input.CategoryId,
                input.Name,
                input.Code,
                input.UnitId,
                input.MediaId,
                input.Description
            );
            await _repository.UpdateAsync(product);

            var oldSku = await _skuRepository.GetListByProductIdsAsync(new List<Guid> { product.Id });
            foreach (var sku in oldSku)
            {
                var inputsku = input.Items.Where(f => f.Id == sku.Id).FirstOrDefault();
                if (inputsku == null)
                {
                    await _skuRepository.DeleteAsync(sku.Id);
                }
                else
                {
                    await _skuManager.UpdateAsync(sku,
                    inputsku.Name,
                    inputsku.Code,
                    inputsku.UnitId,
                    inputsku.MediaId,
                    inputsku.Description);

                    await _skuRepository.UpdateAsync(sku);
                }

            }
            foreach (var sku in input.Items.Where(f => f.Id == null || f.Id == Guid.Empty))
            {
                var productSKU = await _skuManager.CreateSKUAsync(
                    product.Id,
                    sku.Name,
                    sku.Code,
                    sku.UnitId,
                    sku.MediaId,
                    sku.Description
                );
                await _skuRepository.InsertAsync(productSKU);
            }

            return ObjectMapper.Map<Product, ProductDto>(product);
        }

    }
}