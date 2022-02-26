using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FreeERP.Products;
using FreeERP.Purchases;
using FreeERP.Stories;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace FreeERP.Domain.Data
{
    public class FreeERPDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductUnitRepository _productUnitRepository;
        private readonly IProductPropertyRepository _productPropertyRepository;
        private readonly IRepository<PurchaseOrder> _purchaseOrderRepository;
        private readonly ICurrentTenant _currentTenant;
        private readonly IGuidGenerator _guidGenerator;

        private Store store;
        private Category category;
        private Product product;
        private ProductUnit productUnit;
        private ProductProperty productProperty;

        public FreeERPDataSeedContributor(
            IStoreRepository storeRepository,
            ICategoryRepository categoryRepository,
            IProductUnitRepository productUnitRepository,
            IProductPropertyRepository productPropertyRepository,
            IProductRepository productRepository,
            IRepository<PurchaseOrder> purchaseOrderRepository,
            ICurrentTenant currentTenant,
            IGuidGenerator guidGenerator
        )
        {
            _storeRepository = storeRepository;
            _categoryRepository = categoryRepository;
            _productUnitRepository = productUnitRepository;
            _productPropertyRepository = productPropertyRepository;
            _productRepository = productRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
            _currentTenant = currentTenant;
            _guidGenerator = guidGenerator;
        }


        public virtual async Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context?.TenantId))
            {
                await CreateStoreAsync();
                await CreateCategoryAsync();
                await CreateProductUnitAsync();
                await CreateProductPropertyAsync();
                await CreateProductAsync();
                await CreatePurchaseOrderAsync();
            }
        }

        private async Task CreateProductPropertyAsync()
        {
            if (await _productPropertyRepository.GetCountAsync() > 0)
                return;
            productProperty = await _productPropertyRepository.InsertAsync(
                new ProductProperty(
                    _guidGenerator.Create(),
                    "颜色",
                    "颜色属性",
                    "Color",
                    new List<ProductProperty>()
                    {
                        new ProductProperty(
                            _guidGenerator.Create(),
                            "红",
                            "",
                            "Red"
                        )
                    }
                )
            );
        }

        private async Task CreateProductUnitAsync()
        {
            if (await _productUnitRepository.GetCountAsync() > 0)
                return;
            productUnit = await _productUnitRepository.InsertAsync(
                new ProductUnit(_guidGenerator.Create(),
                "瓶",
                "(12瓶=1箱)",
                1,
                0,
                new Collection<ProductUnit>(){
                    new ProductUnit(_guidGenerator.Create(),
                        "箱",
                        "(12瓶=1箱)",
                        12,
                        0
                    )
                }
                )
            );
        }

        private async Task CreatePurchaseOrderAsync()
        {
            if (await _purchaseOrderRepository.GetCountAsync() > 0)
                return;
            var order = new PurchaseOrder(_guidGenerator.Create()
                    , _currentTenant.Id
                );
            order.AddLine(_guidGenerator.Create(), product.Id, null, store.Id, 10);
            await _purchaseOrderRepository.InsertAsync(
                order,
                autoSave: true
            );
        }

        private async Task CreateProductAsync()
        {
            if (await _productRepository.GetCountAsync() > 0)
                return;
            product = await _productRepository.InsertAsync(
                new Product(_guidGenerator.Create(),
                    category.Id,
                    "test", "test", productUnit.Id, null, "test"
                ),
                autoSave: true
            );
        }

        private async Task CreateCategoryAsync()
        {
            if (await _categoryRepository.GetCountAsync() > 0)
                return;

            category = await _categoryRepository.InsertAsync(
                new Category(_guidGenerator.Create(), "test", "test", null, _currentTenant.Id),
                autoSave: true
            );
        }

        private async Task CreateStoreAsync()
        {
            if (await _storeRepository.GetCountAsync() > 0)
                return;

            store = await _storeRepository.InsertAsync(
                new Store(_guidGenerator.Create(), "test", "test", 0, _currentTenant.Id),
                autoSave: true
            );
        }

    }
}