using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Purchase
{
    public class PurchaseOrderLine : Entity<Guid>
    {
        [NotNull]
        public virtual Guid ProductId { get; protected set; }
        [CanBeNull]
        public virtual Guid? ProductSkuId { get; protected set; }
        [NotNull]
        public virtual Guid StoreId { get; protected set; }
        [NotNull]
        public virtual long Number { get; protected set; }

        private PurchaseOrderLine()
        { }
        protected internal PurchaseOrderLine(
            [NotNull] Guid id,
            [NotNull] Guid productId,
            [CanBeNull] Guid? productSkuId,
            [NotNull] Guid storeId,
            [NotNull] long number)
         : base(id)
        {
            ProductId = productId;
            ProductSkuId = productSkuId;
            StoreId = storeId;
            AddNumber(number);
        }
        public virtual void AddNumber(long number)
        {
            Number += number;
            if (Number < 0)
                throw new PurchaseOrderLineltZeroException(ProductId, Number);
        }
    }
}