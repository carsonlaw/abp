using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace FreeERP.Purchase
{
    public class PurchaseOrderLineltZeroException : BusinessException
    {
        public PurchaseOrderLineltZeroException(Guid productid,long num)
            :base(code : FreeERPDomainErrorCodes.Product.Stockltzero)
            {
                WithData(nameof(PurchaseOrderLine.ProductID),productid);
                WithData(nameof(PurchaseOrderLine.Number),num);
            }
        public PurchaseOrderLineltZeroException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
        {
        }
    }
}