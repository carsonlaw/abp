using System;
using System.Linq;
using System.Threading.Tasks;
using FreeERP.Products;
using FreeERP.Purchase;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IRepository<PurchaseOrder> _purchaseOrderRepository;
        private readonly ICurrentTenant _currentTenant;
        private readonly IGuidGenerator _guidGenerator;

        private Category category;
        private Product product;

        public FreeERPDataSeedContributor(
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IRepository<PurchaseOrder> purchaseOrderRepository,
            ICurrentTenant currentTenant,
            IGuidGenerator guidGenerator
        )
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
            _currentTenant = currentTenant;
            _guidGenerator = guidGenerator;
        }


        public virtual async Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context?.TenantId))
            {
                await CreateCategoryAsync();
                await CreateProductAsync();
                await CreatePurchaseOrderAsync();
            }
        }

        private async Task CreatePurchaseOrderAsync()
        {
            if (await _purchaseOrderRepository.GetCountAsync() > 0)
                return;
            await _purchaseOrderRepository.InsertAsync(
                new PurchaseOrder(
                    product.Id,
                    10, _currentTenant.Id
                ),
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
                    "test", "test", null, "test"
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

    }
}