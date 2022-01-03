using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace FreeERP.Products
{
    public class ProductUnitPidReferenceLoopException : BusinessException
    {
        public ProductUnitPidReferenceLoopException(Guid Id, Guid? Pid)
            : base(code: FreeERPDomainErrorCodes.ProductUnit.PidReferenceLoop)
        {
            WithData(nameof(ProductUnit.Id), Id);

            WithData(nameof(ProductUnit.SmallerUnit), Pid);
        }
        public ProductUnitPidReferenceLoopException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
        {
        }
    }
}