using Volo.Abp.Reflection;

namespace Volo.Match.Permissions
{
    public class MatchPermissions
    {
        public const string GroupName = "Match";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MatchPermissions));
        }
    }
}