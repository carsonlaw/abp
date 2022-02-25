using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp.Domain.Repositories;

namespace FreeERP.Customers
{
    public class CustomerManager : DomainService
    {
        protected ICustomerRepository CategroyRepository;

        public CustomerManager(ICustomerRepository repository)
        {
            CategroyRepository = repository;
        }
        public virtual async Task<Customer> CreateAsync([NotNull] string name, [NotNull] string desc, [CanBeNull] int? sort = null)
        {
            await Task.CompletedTask;
            if (!sort.HasValue) sort = 0;
            return new Customer(GuidGenerator.Create(), name, desc, sort.Value, CurrentTenant.Id);
        }

        public virtual async Task<Customer> UpdateAsync([NotNull] Customer customer, [NotNull] string name, [NotNull] string desc, [CanBeNull] int? sort = null)
        {
            await Task.CompletedTask;
            customer.SetName(name);
            customer.SetDescription(desc);
            if (sort.HasValue)
                customer.SetSort(sort.Value);

            return customer;
        }


    }
}