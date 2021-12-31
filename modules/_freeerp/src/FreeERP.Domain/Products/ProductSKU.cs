using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace FreeERP.Products
{
    public class ProductSKU : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public string Name { get; protected set; }
        [NotNull]
        public Guid ProductId { get; protected set; }
        [NotNull]
        public virtual string Code { get; protected set; }
        [CanBeNull]
        public virtual Guid? MediaId { get; protected set; }
        [CanBeNull]
        public virtual string Description { get; protected set; }
        [NotNull]
        public ProductStock Stock { get; protected set; }
        public IList<Guid> PropertyIds { get; protected set; }


        private ProductSKU()
        { }
        protected internal ProductSKU(
            Guid id,
            [NotNull] Guid productId,
            [NotNull] string name,
            [NotNull] string code,
            [NotNull] Guid unitId,
            [CanBeNull] Guid? mediaId,
            [CanBeNull] string description)
        : base(id)
        {
            ProductId = productId;
            SetName(name);
            SetCode(code);
            SetMediaId(mediaId);
            SetDescription(description);
            Stock = new ProductStock(id, unitId, 0);
        }

        public virtual void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), ProductSKUConsts.MaxNameLength);
        }

        public virtual void SetCode(string code)
        {
            Code = Check.NotNullOrWhiteSpace(code, nameof(code), ProductSKUConsts.MaxCodeLength);
        }

        public virtual void SetMediaId(Guid? mediaId)
        {
            MediaId = mediaId;
        }

        public virtual void SetDescription(string description)
        {
            Description = Check.Length(description, nameof(description), ProductSKUConsts.MaxDescriptionLength);
        }



    }
}