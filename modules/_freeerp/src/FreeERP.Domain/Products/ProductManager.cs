using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace FreeERP.Products
{
    public class ProductManager : DomainService
    {
        protected IProductRepository _repository;
        public ProductManager(IProductRepository productRepository)
        {
            _repository = productRepository;
        }
        public virtual async Task ChangedStock(Guid productId, long changednum)
        {
            var product = await _repository.GetAsync(productId, true);
            product.AddStock(changednum);
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
                description
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