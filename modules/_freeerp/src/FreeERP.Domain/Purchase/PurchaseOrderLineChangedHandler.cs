using Volo.Abp.EventBus;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;
using FreeERP.Products;

namespace FreeERP.Purchase
{
    public class PurchaseOrderLineChangedHandler
        : ILocalEventHandler<PurchaseOrderLineChangedEvent>
        , ITransientDependency
    {
        protected ProductManager _productManager;
        public PurchaseOrderLineChangedHandler(ProductManager productManager)
        {
            _productManager = productManager;
        }
        public async Task HandleEventAsync(PurchaseOrderLineChangedEvent eventData)
        {
            await _productManager.ChangedStock(eventData.ProductID,eventData.Number);
        }
    }
}