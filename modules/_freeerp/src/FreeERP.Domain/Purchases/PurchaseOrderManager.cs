using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace FreeERP.Purchases
{
    public class PurchaseOrderManager : DomainService
    {
        protected IPurchaseOrderRepository CategroyRepository;

        public PurchaseOrderManager(IPurchaseOrderRepository repository)
        {
            CategroyRepository = repository;
        }
        public virtual async Task<PurchaseOrder> CreateAsync(
            [NotNull] string orderNo,
            [NotNull] DateTime orderTime,
            [CanBeNull] Guid? supplierId,
            [CanBeNull] string description)
        {
            await Task.CompletedTask;
            return new PurchaseOrder(
                GuidGenerator.Create(),
                orderNo,
                orderTime,
                supplierId,
                description,
                CurrentTenant.Id);
        }

        public virtual async Task<PurchaseOrder> UpdateAsync([NotNull] PurchaseOrder purchaseOrder,
            [NotNull] string orderNo,
            [NotNull] DateTime orderTime,
            [CanBeNull] Guid? supplierId,
            [CanBeNull] string description)
        {
            await Task.CompletedTask;
            purchaseOrder.SetOrderNo(orderNo);
            purchaseOrder.SetOrderTime(orderTime);
            purchaseOrder.SetSupplierId(supplierId);
            purchaseOrder.SetDescription(description);


            return purchaseOrder;
        }

    }
}