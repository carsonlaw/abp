using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp.Domain.Repositories;

namespace FreeERP.Suppliers
{
    public class SupplierManager : DomainService
    {
        protected ISupplierRepository CategroyRepository;

        public SupplierManager(ISupplierRepository repository)
        {
            CategroyRepository = repository;
        }
        public virtual async Task<Supplier> CreateAsync([NotNull] string name, [NotNull] string desc, [CanBeNull] int? sort = null)
        {
            await Task.CompletedTask;
            if (!sort.HasValue) sort = 0;
            return new Supplier(GuidGenerator.Create(), name, desc, sort.Value, CurrentTenant.Id);
        }

        public virtual async Task<Supplier> UpdateAsync([NotNull] Supplier supplier, [NotNull] string name, [NotNull] string desc, [CanBeNull] int? sort = null)
        {
            await Task.CompletedTask;
            supplier.SetName(name);
            supplier.SetDescription(desc);
            if (sort.HasValue)
                supplier.SetSort(sort.Value);

            return supplier;
        }


    }
}