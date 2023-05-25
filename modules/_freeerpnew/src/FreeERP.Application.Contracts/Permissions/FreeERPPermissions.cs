using Volo.Abp.Reflection;

namespace FreeERP.Permissions;

public class FreeERPPermissions
{
    public const string GroupName = "FreeERP";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(FreeERPPermissions));
    }
}
