using System;

namespace FreeERP.Purchase
{
    public class PurchaseOrderLineChangedEvent
    {
        public virtual Guid ProductID { get; protected set;}
        public virtual long Number {get; protected set;}

        private PurchaseOrderLineChangedEvent()
        {}
        public PurchaseOrderLineChangedEvent(Guid productID, long number)
        {
            ProductID = productID;
            Number = number;
        }
    }
}