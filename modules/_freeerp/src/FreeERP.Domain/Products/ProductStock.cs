using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Products
{
    public class ProductStock : Entity<Guid>
    {
        [NotNull]
        public Guid StoreId { get; protected set; }
        [NotNull]
        public long StockNum { get; protected set; }

        private ProductStock()
        { }
        protected internal ProductStock(Guid id, Guid storeId, long stocknum)
        : base(id)
        {
            StoreId = storeId;
            AddStock(stocknum);
        }

        public virtual void AddStock(long num)
        {
            if (StockNum + num < 0)
                throw new ProductStockltZeroException(Id.ToString(), StockNum + num);
            StockNum += num;
        }

    }

}