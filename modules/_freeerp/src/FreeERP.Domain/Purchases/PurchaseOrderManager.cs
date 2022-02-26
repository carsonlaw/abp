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
        public virtual async Task<PurchaseOrder> CreateAsync([NotNull] string name, [NotNull] string desc, [CanBeNull] int? sort = null)
        {
            await Task.CompletedTask;
            if (!sort.HasValue) sort = 0;
            return new PurchaseOrder(GuidGenerator.Create(), CurrentTenant.Id);
        }

        public virtual async Task<PurchaseOrder> UpdateAsync([NotNull] PurchaseOrder purchaseOrder, [NotNull] string name, [NotNull] string desc, [CanBeNull] int? sort = null)
        {
            await Task.CompletedTask;
            //purchaseOrder.SetName(name);
            //purchaseOrder.SetDescription(desc);


            return purchaseOrder;
        }

    }
}