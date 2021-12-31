using System;
using JetBrains.Annotations;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace FreeERP.Products
{
    public class ProductUnitManager : DomainService
    {
        protected IProductUnitRepository _repository;
        public ProductUnitManager(IProductUnitRepository productRepository)
        {
            _repository = productRepository;
        }

        public virtual async Task<ProductUnit> CreateAsync([NotNull] string name, [NotNull] string description, [NotNull] int ratioCount)
        {
            return new ProductUnit(GuidGenerator.Create(), name, description, ratioCount);
        }

        public virtual async Task<ProductUnit> UpdateAsync([NotNull] ProductUnit productUnit, [NotNull] string name, [NotNull] string description, [NotNull] int ratioCount)
        {
            productUnit.SetName(name);
            productUnit.SetDescription(description);
            productUnit.SetRatioCount(ratioCount);

            return productUnit;
        }

    }
}