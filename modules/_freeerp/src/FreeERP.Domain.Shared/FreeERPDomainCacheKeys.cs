namespace FreeERP
{
    public static class FreeERPDomainCacheKeys
    {
        public static class MediaDescriptors
        {
        }

        /* You can add your business exception error codes here, as constants */
        public static class Category
        {
            public const string AllList = "Category:AllList";
            public const int AllListMin = 1440 * 300;
        }
        public static class Product
        {

        }

        public static class ProductUnit
        {

            public const string AllList = "ProductUnit:AllList";
            public const int AllListMin = 1440 * 301;
        }

        public static class Store
        {
            public const string AllList = "Store:AllList";
            public const int AllListMin = 1440 * 302;
        }
    }
}
