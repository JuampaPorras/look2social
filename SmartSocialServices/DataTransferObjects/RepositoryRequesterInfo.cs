
namespace SmartSocialServices.DataTransferObjects
{
    public class RepositoryRequesterInfo
    {
        public int UserId { get; set; }
        public int SmartReportId { get; set; }

        public RepositoryRequesterInfo() { }

        public RepositoryRequesterInfo(int userId, int smartReportId)
        {
            this.UserId = userId;
            this.SmartReportId = smartReportId;
        }

        public RepositoryRequesterInfo(int userId)
        {
            this.UserId = userId;
        }
    }
}
