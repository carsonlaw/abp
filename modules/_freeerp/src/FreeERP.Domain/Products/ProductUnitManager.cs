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

        public virtual async Task<ProductUnit> CreateAsync([CanBeNull] Guid? pid, [NotNull] string name, [NotNull] string description, [NotNull] int ratioCount, [NotNull] int sort)
        {
            var entity = new ProductUnit(GuidGenerator.Create(), name, description, ratioCount, sort);
            entity.SetSmallerUnit(await CheckPid(entity, pid));
            return entity;
        }

        public virtual async Task<ProductUnit> UpdateAsync([NotNull] ProductUnit productUnit, [CanBeNull] Guid? pid, [NotNull] string name, [NotNull] string description, [NotNull] int ratioCount, [NotNull] int sort)
        {
            productUnit.SetName(name);
            productUnit.SetDescription(description);
            productUnit.SetRatioCount(ratioCount);
            productUnit.SetSort(sort);
            if (pid != productUnit.SmallerUnit?.Id)
            {
                productUnit.SetSmallerUnit(await CheckPid(productUnit, pid));
            }

            return productUnit;
        }

        private async Task<ProductUnit> CheckPid(ProductUnit entity, Guid? pid)
        {
            if (pid == null) return null;
            var ids = await _repository.GetAllChildById(entity.Id);
            if (ids.Contains(pid.Value) || pid == entity.Id)
            {
                throw new ProductUnitPidReferenceLoopException(entity.Id, pid);
            }
            var ret = await _repository.GetAsync(f => f.Id == pid);
            if (ret == null)
                throw new ProductUnitPidReferenceLoopException(entity.Id, pid);
            return ret;
        }

    }
}