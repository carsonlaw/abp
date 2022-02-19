using Volo.Abp.EventBus;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FreeERP.Products
{
    public class CategoryChangedHandler
        : ILocalEventHandler<EntityChangedEventData<Category>>,
        ITransientDependency
    {
        protected IDistributedCache<IList<CategoryDto>> _cache;
        public CategoryChangedHandler(IDistributedCache<IList<CategoryDto>> cache)
        {
            _cache = cache;
        }

        public Task HandleEventAsync(EntityChangedEventData<Category> eventData)
        {
            return _cache.RemoveAsync(FreeERPDomainCacheKeys.Category.AllList);
        }
    }
}