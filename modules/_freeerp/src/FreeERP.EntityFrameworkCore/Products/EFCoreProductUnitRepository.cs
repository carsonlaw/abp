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
    public class EFCoreProductUnitRepository : EfCoreRepository<FreeERPDbContext, ProductUnit, Guid>, IProductUnitRepository
    {
        public EFCoreProductUnitRepository(IDbContextProvider<FreeERPDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

        public virtual async Task<IList<Guid>> GetAllChildById(Guid? Pid)
        {
            var ret = new List<Guid>();
            var query = await GetQueryableAsync();
            query = query.Where(f => f.SmallerUnit.Id == Pid);
            var ids = query.Select(f => f.Id).ToList();
            ret.AddRange(ids);
            foreach (var id in ids)
            {
                ret.AddRange(await GetAllChildById(id));
            }
            return ret;
        }

        public virtual async Task<int> GetNextSortByPid(Guid? Pid)
        {
            var query = await GetQueryableAsync();
            var max = await query.Where(f => f.SmallerUnit.Id == Pid).MaxAsync(f => f.Sort);
            return (max + 1);
        }

        public override async Task<IQueryable<ProductUnit>> WithDetailsAsync()
        {
            var query = await base.WithDetailsAsync();
            query = query.Include(f => f.SmallerUnit);
            query = query.Include(f => f.BiggerUnits);
            return query;
        }

    }
}