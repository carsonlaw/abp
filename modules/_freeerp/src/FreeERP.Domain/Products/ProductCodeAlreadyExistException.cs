using System.Runtime.Serialization;
using Volo.Abp;

namespace FreeERP.Products
{
    public class ProductCodeAlreadyExistException : BusinessException
    {
        public ProductCodeAlreadyExistException(string code)
            :base(code : FreeERPDomainErrorCodes.Product.CodeAlreadyExist)
            {
                WithData(nameof(Product.Code),code);
            }
        public ProductCodeAlreadyExistException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
        {
        }
    }
}