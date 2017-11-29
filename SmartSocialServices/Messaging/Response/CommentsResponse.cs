using System.Collections.Generic;
using SmartSocialServices.DataTransferObjects;

namespace SmartSocialServices.Messaging.Response
{
    public class CommentsResponse : BaseResponse
    {
        public List<ChartCommentDto> Comments { get; set; }


        public CommentsResponse()
        {
            Comments = new List<ChartCommentDto>();
        }
    }
}
