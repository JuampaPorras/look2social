using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class UserProfileRepository: EntityRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(SmartSocialContext context) : base(context) {  }
        public UserProfileRepository() : base() { }
    }
}
