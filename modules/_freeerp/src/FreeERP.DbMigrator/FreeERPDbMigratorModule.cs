using FreeERP.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace FreeERP.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(FreeERPEntityFrameworkCoreModule),
        typeof(FreeERPApplicationContractsModule)
        )]
    public class FreeERPDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
