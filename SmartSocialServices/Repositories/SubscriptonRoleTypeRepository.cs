using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class SubscriptionRoleTypeRepository : EntityRepository<SubscriptionRoleType>, ISubscriptionRoleTypeRepository
    {
        public SubscriptionRoleTypeRepository(SmartSocialContext context) : base(context) {  }
        public SubscriptionRoleTypeRepository() : base() { }
    }
}
