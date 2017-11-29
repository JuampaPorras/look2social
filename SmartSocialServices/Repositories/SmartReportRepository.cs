using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class SmartReportRepository: EntityRepository<SmartReport>, ISmartReportRepository
    {
        public SmartReportRepository(SmartSocialContext context) : base(context) {  }
        public SmartReportRepository() : base() { }
    }
}
