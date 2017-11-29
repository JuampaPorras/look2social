using System.ComponentModel;
using System.Web.Script.Services;
using System.Web.Services;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Services;

namespace SmartSocial.Web.Rest
{
    /// <summary>
    /// Summary description for CommentsWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CommentsWS : WebService
    {
        readonly CommentsService _commentService = new CommentsService();

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public CommentsResponse GetCommentsByChart(int smartChartId)
        {
            return _commentService.GetCommentsByChart(smartChartId);
        }

        [WebMethod]
        public CommentsResponse AddChartComment(string IdUser,int IdSmartChart, string Message)
        {
            var aduto = "";
            return _commentService.AddChartComment(new ChartCommentDto()
            {
               IdSmartChart = IdSmartChart,
               Message =  Message,
               IdUser = IdUser
            });
        }
    }
}
