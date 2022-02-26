using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FreeERP.Purchases
{
    public interface IPurchaseOrderRepository : IRepository<PurchaseOrder, Guid>
    {

    }
}