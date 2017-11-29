using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class ServiceSubscriptionRepository : EntityRepository<ServiceSubscription>, IServiceSubscriptionRepository
    {
        public ServiceSubscriptionRepository(SmartSocialContext context) : base(context) {  }
        public ServiceSubscriptionRepository() : base() { }
    }

}
