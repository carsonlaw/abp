using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace Volo.HDShop.Users
{
    public class ShopUserLookupService: UserLookupService<ShopUser, IShopUserRepository>, IShopUserLookupService
    {
        public ShopUserLookupService(
            IShopUserRepository userRepository,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                userRepository,
                unitOfWorkManager)
        {

        }

        protected override ShopUser CreateUser(IUserData externalUser)
        {
            return new ShopUser(externalUser);
        }
    }
}
