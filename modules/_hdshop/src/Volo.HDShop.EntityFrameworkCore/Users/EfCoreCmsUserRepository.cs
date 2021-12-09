using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;
using Volo.HDShop.EntityFrameworkCore;

namespace Volo.HDShop.Users
{
    public class EfCoreShopUserRepository: EfCoreUserRepositoryBase<IHDShopDbContext, ShopUser>, IShopUserRepository
    {
        public EfCoreShopUserRepository(IDbContextProvider<IHDShopDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
