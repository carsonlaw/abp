using Volo.Abp.EventBus;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;

namespace FreeERP.Products
{
    public class ProductStockChangedHandler
        : ILocalEventHandler<ProductStockChangedEvent>,
        ITransientDependency
    {
        protected ProductManager _manager;
        public ProductStockChangedHandler(ProductManager productManager)
        {
            _manager = productManager;
        }
        public async Task HandleEventAsync(ProductStockChangedEvent eventData)
        {
            await Task.CompletedTask;
            //await _manager.ChangedStock(eventData.ProductId,eventData.ChangedNum);
        }
    }
}