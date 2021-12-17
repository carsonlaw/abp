using System;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Purchase
{
    public class PurchaseOrderLine : Entity<Guid>
    {
        public virtual Guid ProductID { get; protected set;}
        public virtual long Number {get; protected set;}

        private PurchaseOrderLine()
        {}
        protected internal PurchaseOrderLine(Guid productID, long number)
        {
            ProductID = productID;
            AddNumber(number);
        }
        public virtual void AddNumber(long number)
        {
            Number += number;
            if(Number<0)
                throw new PurchaseOrderLineltZeroException(ProductID,Number);
        }
    }
}