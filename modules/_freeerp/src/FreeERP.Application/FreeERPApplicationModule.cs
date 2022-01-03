using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace FreeERP
{
    [DependsOn(
        typeof(FreeERPDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(FreeERPApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpSettingManagementApplicationModule)
        )]
    public class FreeERPApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<FreeERPApplicationModule>();
            });
            Configure<AbpDistributedCacheOptions>(options =>
            {
                options.KeyPrefix = "FreeERP";
                options.HideErrors = false;
                options.GlobalCacheEntryOptions = new DistributedCacheEntryOptions()
                {
                    SlidingExpiration = System.TimeSpan.FromMinutes(30)
                };
            });
        }
    }
}
