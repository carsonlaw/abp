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

namespace FreeERP.Products
{
    public class EFCoreProductPropertyRepository : EfCoreRepository<FreeERPDbContext, ProductProperty, Guid>, IProductPropertyRepository
    {
        public EFCoreProductPropertyRepository(IDbContextProvider<FreeERPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

    }
}