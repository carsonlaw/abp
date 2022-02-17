using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace FreeERP.Products
{
    public class ProductManager : DomainService
    {
        protected IProductRepository _repository;
        protected IProductSKURepository _skuRepository;
        public ProductManager(
            IProductRepository productRepository,
            IProductSKURepository skuRepository
            )
        {
            _repository = productRepository;
            _skuRepository = skuRepository;
        }
        public virtual async Task ChangedStock(Guid productId, Guid? productSkuId, Guid storeId, long changednum)
        {
            var product = await _repository.GetAsync(productId, true);
            product.AddStock(GuidGenerator.Create(), storeId, changednum);
            if (productSkuId.HasValue && productSkuId.Value != Guid.Empty)
            {
                var sku = await _skuRepository.GetAsync(productSkuId.Value, true);
                sku.AddStock(GuidGenerator.Create(), storeId, changednum);
            }
        }

        public virtual async Task<Product> CreateAsync(
            [NotNull] Guid categoryId,
            [NotNull] string name,
            [NotNull] string code,
            [NotNull] Guid unitId,
            Guid? mediaId,
            string description
        )
        {
            var product = new Product(
                GuidGenerator.Create(),
                categoryId,
                name,
                code,
                unitId,
                mediaId,
                description,
                CurrentTenant.Id
            );
            return product;
        }

        public virtual async Task<Product> UpdateAsync(Product product, Guid categoryId, string name, string code, Guid unitId, Guid? mediaId, string description)
        {
            product.SetCategory(categoryId);
            product.SetName(name);
            product.SetCode(code);
            //product.SetUnitId(unitId);
            product.SetMediaId(mediaId);
            product.SetDescription(description);
            return product;
        }
    }
}