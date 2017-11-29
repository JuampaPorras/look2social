using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Services;

namespace SmartSocial.Web.Rest
{
    public class RestService : IRestService
    {
        readonly CommentsService _commentService = new CommentsService();


        public CommentsResponse GetCommentsByChart(int smartChartId)
        {
            return _commentService.GetCommentsByChart(smartChartId);
        }

        public CommentsResponse AddChartComment(ChartCommentDto comment)
        {
            return _commentService.AddChartComment(comment);
        }
    }
}
