using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class SharedReportRepository: EntityRepository<SharedReport>, ISharedReportRepository
    {
        public SharedReportRepository(SmartSocialContext context) : base(context) {  }
        public SharedReportRepository() : base() { }
    }
}
