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
    public class EFCoreProductSKURepository : EfCoreRepository<FreeERPDbContext, ProductSKU, Guid>, IProductSKURepository
    {
        public EFCoreProductSKURepository(IDbContextProvider<FreeERPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task DeleteByProductIdAsync(Guid Id)
        {
            await DeleteAsync(f => f.ProductId == Id);
        }
        public virtual async Task<List<ProductSKU>> GetListByProductIdsAsync(IEnumerable<Guid> Ids)
        {
            var query = await GetQueryableAsync();
            return await query.Where(f => Ids.Contains(f.ProductId)).ToListAsync();
        }

    }
}