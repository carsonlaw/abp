using Volo.Abp.Reflection;

namespace Volo.HDShop.Permissions
{
    public class HDShopPermissions
    {
        public const string GroupName = "HDShop";
        public const string AddName = ".Add";
        public const string EditName = ".Edit";
        public const string DeleteName = ".Delete";

        //Add your own permission names. Example:
        public const string GoodManager = ".GoodManager";

        public const string OrderManager = ".OrderManager";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(HDShopPermissions));
        }
    }
}