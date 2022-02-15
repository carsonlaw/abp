using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FreeERP.Suppliers
{
    public interface ISupplierRepository : IRepository<Supplier, Guid>
    {

    }
}