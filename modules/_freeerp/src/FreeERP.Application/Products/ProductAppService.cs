using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using FreeERP.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
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
        readonly ICategoryAppService _categoryService;
        readonly IProductUnitAppService _productUnitService;
        public ProductAppService(IProductRepository repository,
            IProductSKURepository skuRepository,
            ProductManager manager,
            ProductSKUManager skuManager,
            ICategoryAppService CategoryAppService,
            IProductUnitAppService ProductUnitAppService)
        {
            _repository = repository;
            _skuRepository = skuRepository;
            _manager = manager;
            _skuManager = skuManager;
            _categoryService = CategoryAppService;
            _productUnitService = ProductUnitAppService;
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
            if (input.Items != null)
            {
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
            }

            return ObjectMapper.Map<Product, ProductDto>(product);
        }


        [Authorize(FreeERPPermissions.Products.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
            await _skuRepository.DeleteByProductIdAsync(id);
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var query = await _repository.WithDetailsAsync();
            query = query.Where(f => f.Id == id);
            var entity = await AsyncExecuter.SingleOrDefaultAsync(query);
            return ObjectMapper.Map<Product, ProductDto>(entity);
        }

        public async Task<PagedResultDto<ProductDto>> GetListAsync(ProductGetListInput input)
        {
            var query = await _repository.WithDetailsAsync();

            query = query.WhereIf(!string.IsNullOrEmpty(input.Filter),
                f => f.Name.Contains(input.Filter) || f.Code.Contains(input.Filter));
            query = query.WhereIf(input.CategoryId != null,
                f => f.CategoryId == input.CategoryId);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = query.OrderBy(input.Sorting);
            query = query.PageBy(input);
            var entities = await AsyncExecuter.ToListAsync(query);

            var categories = await _categoryService.GetAllListFromCache();
            var units = await _productUnitService.GetAllListFromCache();
            var items = await _skuRepository.GetListByProductIdsAsync(entities.Select(f => f.Id));

            var entityDtos = new List<ProductDto>();

            foreach (var entity in entities)
            {
                var dto = ObjectMapper.Map<Product, ProductDto>(entity);
                dto.CategoryName = categories.FirstOrDefault(f => f.Id == dto.CategoryId)?.Name;
                dto.UnitName = units.FirstOrDefault(f => f.Id == dto.UnitId)?.Name;
                entityDtos.Add(dto);
            }

            return new PagedResultDto<ProductDto>(
                totalCount,
                entityDtos
            );
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
            foreach (var sku in input.Items.Where(f => f.Id == Guid.Empty))
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