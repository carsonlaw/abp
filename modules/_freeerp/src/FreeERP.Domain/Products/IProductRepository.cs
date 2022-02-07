using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FreeERP.Products
{
    public interface IProductRepository : IRepository<Product, Guid>
    {

    }
}