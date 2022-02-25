namespace FreeERP.MultiTenancy
{
    public class MultiTenancyConsts
    {
        /* Enable/disable multi-tenancy easily in a single point.
         * If you will never need to multi-tenancy, you can remove
         * related modules and code parts, including this file.
         */
        //public const bool IsEnabled = true;
        public static bool IsEnabled { get; set; } = true;
    }
}
