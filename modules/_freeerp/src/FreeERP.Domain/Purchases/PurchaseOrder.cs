using System;
using System.Linq;
using System.Collections.Generic;
using FreeERP.Products;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace FreeERP.Purchases
{
    public class PurchaseOrder : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        [NotNull]
        public virtual string OrderNo { get; protected set; }
        [NotNull]
        public virtual DateTime OrderTime { get; protected set; }
        [CanBeNull]
        public virtual Guid? SupplierId { get; protected set; }
        [CanBeNull]
        public virtual string Description { get; protected set; }
        [CanBeNull]
        public virtual decimal? Price { get; protected set; }
        public virtual IList<PurchaseOrderLine> Lines { get; protected set; }

        private PurchaseOrder()
        { }
        protected internal PurchaseOrder(Guid id,
        string orderNo,
        DateTime orderTime,
        Guid? supplierId,
        string description,
        Guid? tenantId)
        : base(id)
        {
            TenantId = tenantId;
            SetOrderNo(orderNo);
            SetOrderTime(orderTime);
            SetSupplierId(supplierId);
            SetDescription(description);
            OrderTime = orderTime;
            Lines = new List<PurchaseOrderLine>();
        }

        public virtual void SetOrderNo(string orderNo)
        {
            OrderNo = Check.NotNullOrWhiteSpace(orderNo, nameof(orderNo), PurchaseOrderConsts.MaxOrderNoLength);
        }
        public virtual void SetOrderTime(DateTime orderTime)
        {
            OrderTime = orderTime;
        }
        public virtual void SetSupplierId(Guid? supplierid)
        {
            SupplierId = supplierid;
        }
        public virtual void SetDescription(string description)
        {
            Description = Check.Length(description, nameof(description), PurchaseOrderConsts.MaxDescriptionLength);
        }

        public virtual void AddLine(Guid lineId, Guid productId, Guid? productSkuId, Guid storeId, long number, decimal? unitPrice)
        {
            var oldline = Lines?.FirstOrDefault(f => f.ProductId == productId
                && f.ProductSkuId == productSkuId
                && f.StoreId == storeId
            );
            if (oldline != null)
            {
                oldline.ChangeUnitPrice(unitPrice);
                oldline.AddNumber(number);
                if (oldline.Number == 0)
                    Lines.Remove(oldline);
            }
            else
            {
                oldline = new PurchaseOrderLine(lineId, productId, productSkuId, storeId, number, unitPrice);
                if (Lines == null) Lines = new List<PurchaseOrderLine>();
                Lines.Add(oldline);
            }

            Price = Lines.Sum(f => f.Number * f.UnitPrice);

            AddLocalEvent(new PurchaseOrderLineChangedEvent(productId, productSkuId, storeId, number));
        }

    }
}