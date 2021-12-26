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
    public class EFCoreCategoryRepository
    : EfCoreRepository<FreeERPDbContext, Category, Guid>,
    ICategoryRepository
    {
        public EFCoreCategoryRepository(IDbContextProvider<FreeERPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<IList<Guid>> GetAllChildById(Guid? Pid)
        {
            var ret = new List<Guid>();
            var query = await GetQueryableAsync();
            query = query.Where(f => f.Pid == Pid);
            var ids = query.Select(f => f.Id).ToList();
            ret.AddRange(ids);
            foreach (var id in ids)
            {
                ret.AddRange(await GetAllChildById(id));
            }
            return ret;
        }

        public virtual async Task<List<Category>> GetListAsync(string filter = null, string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        {
            var query = await GetListQueryAsync(filter);

            return await query.OrderBy(sorting.IsNullOrEmpty() ? $"{nameof(Category.CreationTime)} desc" : sorting)
                          .PageBy(skipCount, maxResultCount)
                          .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<bool> SlugExistsAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync()).AnyAsync(x => x.Slug == slug, GetCancellationToken(cancellationToken));
        }

        protected virtual async Task<IQueryable<Category>> GetListQueryAsync(string filter = null)
        {
            return (await GetDbSetAsync())
                .WhereIf(!filter.IsNullOrWhiteSpace(), b => (b.Name.Contains(filter) || b.Slug.Contains(filter)));
        }
    }
}