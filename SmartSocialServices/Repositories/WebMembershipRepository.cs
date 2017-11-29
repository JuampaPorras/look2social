using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class WebMembershipRepository: EntityRepository<webpages_Membership>, IWebMembershipRepository
    {
        public WebMembershipRepository(SmartSocialContext context) : base(context) {  }
        public WebMembershipRepository() : base() { }
    }
}