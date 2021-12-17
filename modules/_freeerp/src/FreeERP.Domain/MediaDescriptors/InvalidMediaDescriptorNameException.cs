using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Volo.Abp;

namespace FreeERP.MediaDescriptors
{
    [Serializable]
    public class InvalidMediaDescriptorNameException : BusinessException
    {
        public InvalidMediaDescriptorNameException([NotNull] string name)
        {
            Code = FreeERPDomainErrorCodes.MediaDescriptors.InvalidName;
            WithData(nameof(MediaDescriptor.Name), name);
        }

        public InvalidMediaDescriptorNameException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}