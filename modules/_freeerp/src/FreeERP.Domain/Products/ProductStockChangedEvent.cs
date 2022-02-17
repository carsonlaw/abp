using System;

namespace FreeERP.Products
{
    public class ProductStockChangedEvent
    {
        public Guid ProductId { get; set; }

        public Guid StoreId { get; set; }

        public long ChangedNum { get; set; }
    }
}