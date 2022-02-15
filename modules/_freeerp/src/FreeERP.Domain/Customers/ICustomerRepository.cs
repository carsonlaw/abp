using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FreeERP.Customers
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {

    }
}