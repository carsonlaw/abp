using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace FreeERP.Products
{
    public class ProductProperty : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        [NotNull]
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Value { get; protected set; }
        public ProductProperty Parent { get; protected set; }
        public IList<ProductProperty> Items { get; protected set; }
        public virtual Guid? TenantId { get; protected set; }


        private ProductProperty()
        { }
        protected internal ProductProperty(
            Guid id,
            string name,
            string description,
            string value,
            List<ProductProperty> items = null,
            [CanBeNull] Guid? tenantId = null)
        : base(id)
        {
            SetName(name);
            SetDescription(description);
            SetValue(value);
            Items = items ?? new List<ProductProperty>();
            TenantId = tenantId;
        }
        public virtual void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), ProductUnitConsts.MaxNameLength);
        }
        public virtual void SetDescription(string description)
        {
            Description = Check.Length(description, nameof(description), ProductConsts.MaxDescriptionLength);
        }
        public virtual void SetValue(string value)
        {
            Name = Check.NotNullOrWhiteSpace(value, nameof(value), ProductUnitConsts.MaxValueLength);
        }

        public virtual void SetItems(List<ProductProperty> items)
        {
            Items = items;
        }
    }
}