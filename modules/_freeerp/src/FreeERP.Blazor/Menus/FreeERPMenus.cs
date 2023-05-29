namespace FreeERP.Blazor.Menus;

public class FreeERPMenus
{
    public const string Prefix = "FreeERP";


    //Add your menu items here...
    //public const string Home = Prefix + ".MyNewMenuItem";

    public const string Home = Prefix + ".Home";

    public const string ProductsGroup = Prefix + ".Products";
    public const string Category = ProductsGroup + ".Category";
    public const string Product = ProductsGroup + ".Product";
    public const string ProductUnit = ProductsGroup + ".ProductUnit";

    public const string PurchasesGroup = Prefix + ".Purchases";
    public const string Supplier = PurchasesGroup + ".Supplier";
    public const string PurchaseOrder = PurchasesGroup + ".PurchaseOrder";

    public const string StoriesGroup = Prefix + ".Stories";
    public const string Store = StoriesGroup + ".Store";

    public const string SalesGroup = Prefix + ".Sales";

    public const string Customer = Prefix + ".Customer";
    public const string SaleOrder = Prefix + ".SaleOrder";

}
