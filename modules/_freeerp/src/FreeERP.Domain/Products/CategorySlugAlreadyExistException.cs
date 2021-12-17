using System.Runtime.Serialization;
using Volo.Abp;

namespace FreeERP.Products
{
    public class CategorySlugAlreadyExistException : BusinessException
    {
        public CategorySlugAlreadyExistException(string Slug)
            :base(code : FreeERPDomainErrorCodes.Category.SlugAlreadyExist)
            {
                WithData(nameof(Category.Slug),Slug);
            }
        public CategorySlugAlreadyExistException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
        {
        }
    }
}