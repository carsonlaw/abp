using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Products
{
    public class ProductStock : Entity
    {
        [NotNull]
        public Guid ProductID {get;protected set;}
        [NotNull]
        public long StockNum { get; protected set; }

        private ProductStock()
        {}
        protected internal ProductStock(Guid productID,long stocknum)
        {
            ProductID = productID;
            AddStock(stocknum);
        }

        public virtual void AddStock( long num)
        {
            if(StockNum + num < 0 )
                throw new ProductStockltZeroException(ProductID.ToString(),StockNum + num);
            StockNum += num;
        }
        public override object[] GetKeys()
        {
            return new object[] { ProductID };
        }
    }

}