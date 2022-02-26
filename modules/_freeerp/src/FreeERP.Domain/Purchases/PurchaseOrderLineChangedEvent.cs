using System;

namespace FreeERP.Purchases
{
    public class PurchaseOrderLineChangedEvent
    {
        public virtual Guid ProductId { get; protected set; }
        public virtual Guid? ProductSkuId { get; protected set; }
        public virtual Guid StoreID { get; protected set; }
        public virtual long Number { get; protected set; }

        private PurchaseOrderLineChangedEvent()
        { }
        public PurchaseOrderLineChangedEvent(Guid productId, Guid? productSkuId, Guid storeId, long number)
        {
            ProductId = productId;
            ProductSkuId = productSkuId;
            StoreID = storeId;
            Number = number;
        }
    }
}