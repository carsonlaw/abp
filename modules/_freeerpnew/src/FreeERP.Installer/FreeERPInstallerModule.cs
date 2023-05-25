using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FreeERP;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class FreeERPInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<FreeERPInstallerModule>();
        });
    }
}
