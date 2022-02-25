using Volo.Abp.EventBus;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FreeERP.Stories
{
    public class StoreChangedHandler
        : ILocalEventHandler<EntityChangedEventData<Store>>,
        ITransientDependency
    {
        protected IDistributedCache<IList<StoreDto>> _cache;
        public StoreChangedHandler(IDistributedCache<IList<StoreDto>> cache)
        {
            _cache = cache;
        }

        public Task HandleEventAsync(EntityChangedEventData<Store> eventData)
        {
            return _cache.RemoveAsync(FreeERPDomainCacheKeys.Store.AllList);
        }
    }
}