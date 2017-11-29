using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class ChartCommentRepository : EntityRepository<ChartComment>, IChartCommentRepository
    {
        public ChartCommentRepository(SmartSocialContext context) : base(context) {  }
        public ChartCommentRepository() : base() { }
    }
}
