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
        public virtual IList<PurchaseOrderLine> Lines {get; protected set;}

        private PurchaseOrder()
        {}
        protected internal PurchaseOrder(Guid productID,long number,Guid? tenantId)
        {
            TenantId = tenantId;
            ChangeLine(productID,number);
        }
        public virtual void ChangeLine(Guid productID,long number)
        {
            var oldline = Lines?.FirstOrDefault(f=>f.ProductID == productID);
            if(oldline != null)
            {
                oldline.AddNumber(number);
                if(oldline.Number == 0)
                    Lines.Remove(oldline);
            }
            else
            {
                oldline = new PurchaseOrderLine(productID,number);
                if(Lines == null) Lines = new List<PurchaseOrderLine>();
                Lines.Add(oldline);
            }
            
            AddLocalEvent(new PurchaseOrderLineChangedEvent(productID,number));
        }
       
    }
}