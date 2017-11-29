using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class UsersXSubscriptionRepository: EntityRepository<UsersXSubscription>, IUsersXSubscriptionRepository
    {
        public UsersXSubscriptionRepository(SmartSocialContext context) : base(context) {  }
        public UsersXSubscriptionRepository() : base() { }
    }
}
