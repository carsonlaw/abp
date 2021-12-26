using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace FreeERP.Products
{
    public class CategoryPidReferenceLoopException : BusinessException
    {
        public CategoryPidReferenceLoopException(Guid Id, Guid? Pid)
            : base(code: FreeERPDomainErrorCodes.Category.PidReferenceLoop)
        {
            WithData(nameof(Category.Id), Id);

            WithData(nameof(Category.Pid), Pid);
        }
        public CategoryPidReferenceLoopException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
        {
        }
    }
}