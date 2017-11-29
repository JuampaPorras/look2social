using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class SmartChartRepository: EntityRepository<SmartChart>, ISmartChartRepository
    {
        public SmartChartRepository(SmartSocialContext context) : base(context) {  }
        public SmartChartRepository() : base() { }
    }
}
