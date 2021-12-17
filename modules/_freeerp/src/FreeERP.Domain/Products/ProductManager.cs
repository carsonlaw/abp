using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace FreeERP.Products
{
    public class ProductManager : DomainService
    {
        protected IProductRepository _repository;
        public ProductManager(IProductRepository productRepository)
        {
            _repository = productRepository;
        }
        public virtual async Task ChangedStock(Guid pid, long changednum)
        {
            var product = await _repository.GetAsync(pid,true);
            product.AddStock(changednum);
        }
    }
}