namespace FreeERP
{
    public static class FreeERPDomainErrorCodes
    {
        public static class MediaDescriptors
        {
            public const string InvalidName = "Media:0001";
        }

        /* You can add your business exception error codes here, as constants */
        public static class Category
        {
            public const string SlugAlreadyExist = "Category:0001";

        }
        public static class Product
        {
            public const string CodeAlreadyExist = "Product:0001";
            public const string Stockltzero = "Product:0002";

        }
    }
}
