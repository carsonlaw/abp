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
    public class EFCoreProductRepository : EfCoreRepository<FreeERPDbContext, Product, Guid>, IProductRepository
    {
        public EFCoreProductRepository(IDbContextProvider<FreeERPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public override async Task<IQueryable<Product>> WithDetailsAsync()
        {
            var query = await base.WithDetailsAsync();
            query = query.Include(f => f.Stock);
            return query;
        }

        // public virtual async Task<List<Product>> GetListAsync(string filter = null, string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        // {
        //     var query = await GetListQueryAsync(filter);

        //     return await query.OrderBy(sorting.IsNullOrEmpty() ? $"{nameof(Product.CreationTime)} desc" : sorting)
        //                   .PageBy(skipCount, maxResultCount)
        //                   .ToListAsync(GetCancellationToken(cancellationToken));
        // }

        // protected virtual async Task<IQueryable<Product>> GetListQueryAsync(string filter = null)
        // {
        //     return (await GetDbSetAsync())
        //         .WhereIf(!filter.IsNullOrWhiteSpace(), b => (b.Name.Contains(filter) || b.Code.Contains(filter)));
        // }
    }
}