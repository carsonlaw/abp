using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace FreeERP.Products
{
    public class ProductSKUManager : DomainService
    {
        protected IProductSKURepository _repository;
        public ProductSKUManager(IProductSKURepository productRepository)
        {
            _repository = productRepository;
        }


        public virtual async Task<ProductSKU> CreateSKUAsync(
            [NotNull] Guid productId,
            [NotNull] string name,
            [NotNull] string code,
            [NotNull] Guid unitId,
            Guid? mediaId,
            string description
        )
        {
            var sku = new ProductSKU(
                GuidGenerator.Create(),
                productId,
                name,
                code,
                unitId,
                mediaId,
                description
            );
            return sku;
        }

        public virtual async Task<ProductSKU> UpdateAsync(ProductSKU productSku, string name, string code, Guid unitId, Guid? mediaId, string description)
        {
            productSku.SetName(name);
            productSku.SetCode(code);
            //product.SetUnitId(unitId);
            productSku.SetMediaId(mediaId);
            productSku.SetDescription(description);
            return productSku;
        }

    }
}