using System.ServiceModel;
using System.ServiceModel.Web;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Messaging.Response;

namespace SmartSocial.Web.Rest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestService" in both code and config file together.
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "smartChart/{id}")]
        CommentsResponse GetCommentsByChart(int smartChartId);


        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "comment")]
        CommentsResponse AddChartComment(ChartCommentDto comment);

    }
}