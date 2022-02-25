using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp.Domain.Repositories;

namespace FreeERP.Stories
{
    public class StoreManager : DomainService
    {
        protected IStoreRepository CategroyRepository;

        public StoreManager(IStoreRepository repository)
        {
            CategroyRepository = repository;
        }
        public virtual async Task<Store> CreateAsync([NotNull] string name, [NotNull] string desc, [CanBeNull] int? sort = null)
        {
            await Task.CompletedTask;
            if (!sort.HasValue) sort = 0;
            return new Store(GuidGenerator.Create(), name, desc, sort.Value, CurrentTenant.Id);
        }

        public virtual async Task<Store> UpdateAsync([NotNull] Store store, [NotNull] string name, [NotNull] string desc, [CanBeNull] int? sort = null)
        {

            await Task.CompletedTask;
            store.SetName(name);
            store.SetDescription(desc);
            if (sort.HasValue)
                store.SetSort(sort.Value);

            return store;
        }


    }
}