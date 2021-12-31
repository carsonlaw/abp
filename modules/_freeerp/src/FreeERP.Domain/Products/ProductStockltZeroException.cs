using System.Runtime.Serialization;
using Volo.Abp;

namespace FreeERP.Products
{
    public class ProductStockltZeroException : BusinessException
    {
        public ProductStockltZeroException(string code, long num)
            : base(code: FreeERPDomainErrorCodes.Product.StockLtZero)
        {
            WithData(nameof(Product.Code), code);
            WithData(nameof(ProductStock.StockNum), num);
        }
        public ProductStockltZeroException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
        {
        }
    }
}