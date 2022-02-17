using System;
using System.Linq;
using System.Collections.Generic;
using FreeERP.Products;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace FreeERP.Purchase
{
    public class PurchaseOrder : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual IList<PurchaseOrderLine> Lines { get; protected set; }

        private PurchaseOrder()
        { }
        protected internal PurchaseOrder(Guid id,
        Guid? tenantId)
        : base(id)
        {
            TenantId = tenantId;
            Lines = new List<PurchaseOrderLine>();
            //ChangeLine(productID, number);
        }
        public virtual void AddLine(Guid lineId, Guid productId, Guid? productSkuId, Guid storeId, long number)
        {
            var oldline = Lines?.FirstOrDefault(f => f.ProductId == productId
                && f.ProductSkuId == productSkuId
                && f.StoreId == storeId
            );
            if (oldline != null)
            {
                oldline.AddNumber(number);
                if (oldline.Number == 0)
                    Lines.Remove(oldline);
            }
            else
            {
                oldline = new PurchaseOrderLine(lineId, productId, productSkuId, storeId, number);
                if (Lines == null) Lines = new List<PurchaseOrderLine>();
                Lines.Add(oldline);
            }

            AddLocalEvent(new PurchaseOrderLineChangedEvent(productId, productSkuId, storeId, number));
        }

    }
}