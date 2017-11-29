using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class SocialPostRepository: EntityRepository<SocialPost>, ISocialPostRepository
    {
        public SocialPostRepository(SmartSocialContext context) : base(context) {  }
        public SocialPostRepository() : base() { }
    }
}
