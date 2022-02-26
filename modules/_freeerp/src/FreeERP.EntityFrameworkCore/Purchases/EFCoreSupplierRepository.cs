using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using FreeERP.EntityFrameworkCore;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FreeERP.Purchases
{
    public class EFCorePurchaseOrderRepository : EfCoreRepository<FreeERPDbContext, PurchaseOrder, Guid>, IPurchaseOrderRepository
    {
        public EFCorePurchaseOrderRepository(IDbContextProvider<FreeERPDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }



    }
}