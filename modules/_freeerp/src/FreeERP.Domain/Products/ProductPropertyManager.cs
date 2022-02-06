using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace FreeERP.Products
{
    public class ProductPropertyManager : DomainService
    {
        protected IProductPropertyRepository _repository;
        public ProductPropertyManager(IProductPropertyRepository productPropertyRepository)
        {
            _repository = productPropertyRepository;
        }

        public virtual async Task<ProductProperty> CreateAsync([NotNull] string name,
        [CanBeNull] string description,
        [NotNull] IList<string> names)
        {
            var items = names.Select(f => new ProductProperty(GuidGenerator.Create(),
                f,
                "",
                f)
            ).ToList();
            return new ProductProperty(GuidGenerator.Create(),
             name,
             description,
             name,
             items,
             CurrentTenant.Id);
        }

        public virtual async Task<ProductProperty> UpdateAsync([NotNull] ProductProperty entity,
        [NotNull] string name,
        [CanBeNull] string description,
        [NotNull] IList<(Guid Id, string Name)> names
        )
        {
            var items = names.Select(f => new ProductProperty(f.Id,
                f.Name,
                "",
                f.Name)
            ).ToList();
            entity.SetName(name);
            entity.SetDescription(description);
            entity.SetValue("");
            entity.SetItems(items);
            return entity;
        }
    }
}