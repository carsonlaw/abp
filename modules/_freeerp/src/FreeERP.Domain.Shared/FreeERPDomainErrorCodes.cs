namespace FreeERP
{
    public static class FreeERPDomainErrorCodes
    {
        public static class MediaDescriptors
        {
            public const string InvalidName = "FreeERP:Media:0001";
        }

        /* You can add your business exception error codes here, as constants */
        public static class Category
        {
            public const string SlugAlreadyExist = "FreeERP:Category:0001";

            public const string PidReferenceLoop = "FreeERP:Category:0002";
        }
        public static class Product
        {
            public const string CodeAlreadyExist = "FreeERP:Product:0001";
            public const string Stockltzero = "FreeERP:Product:0002";

        }
    }
}
