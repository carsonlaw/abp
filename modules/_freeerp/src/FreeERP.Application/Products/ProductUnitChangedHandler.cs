using Volo.Abp.EventBus;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FreeERP.Products
{
    public class ProductUnitChangedHandler
        : ILocalEventHandler<EntityChangedEventData<ProductUnit>>,
        ITransientDependency
    {
        protected IDistributedCache<IList<ProductUnitDto>> _cache;
        public ProductUnitChangedHandler(IDistributedCache<IList<ProductUnitDto>> cache)
        {
            _cache = cache;
        }

        public Task HandleEventAsync(EntityChangedEventData<ProductUnit> eventData)
        {
            return _cache.RemoveAsync(FreeERPDomainCacheKeys.ProductUnit.AllList);
        }
    }
}