using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FreeERP.Products
{
    public interface IProductSKURepository : IBasicRepository<ProductSKU, Guid>
    {
        Task DeleteByProductIdAsync(Guid Id);
        Task<List<ProductSKU>> GetListByProductIdsAsync(IEnumerable<Guid> Ids);
    }
}