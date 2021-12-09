using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.HDShop.Users;

namespace Volo.HDShop.EntityFrameworkCore
{
    [DependsOn(
        typeof(HDShopDomainModule),        
        typeof(AbpUsersEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class HDShopEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HDShopDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<ShopUser,EfCoreShopUserRepository>();
            });
        }
    }
}