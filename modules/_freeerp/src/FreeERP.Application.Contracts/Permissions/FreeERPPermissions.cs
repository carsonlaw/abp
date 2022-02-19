namespace FreeERP.Permissions
{
    public static class FreeERPPermissions
    {
        public const string ProductsGroupName = "FreeERP.Products";
        public const string PurchaseGroupName = "FreeERP.Purchase";
        public const string StoriesGroupName = "FreeERP.Stories";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
        public static class Categories
        {
            public const string Default = ProductsGroupName + ".Categories";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
        public static class ProductUnits
        {
            public const string Default = ProductsGroupName + ".ProductUnits";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
        public static class ProductProperties
        {
            public const string Default = ProductsGroupName + ".ProductProperties";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
        public static class Products
        {
            public const string Default = ProductsGroupName + ".Products";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class PurchaseOrder
        {
            public const string Default = PurchaseGroupName + ".PurchaseOrder";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class SettingManagement
        {
            public const string HelpSetting = "FreeERP.SettingManagement.HelpSetting";
        }

        public static class Stories
        {
            public const string Default = StoriesGroupName + ".Stories";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
    }
}