using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class ChartTypeRepository : EntityRepository<ChartType>, IChartTypeRepository
    {
        public ChartTypeRepository(SmartSocialContext context) : base(context) {  }
        public ChartTypeRepository() : base() { }
    }
}
