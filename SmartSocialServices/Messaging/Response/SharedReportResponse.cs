using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSocialServices.DataTransferObjects;

namespace SmartSocialServices.Messaging.Response
{
    public class SharedReportResponse : BaseResponse
    {
        public SharedReportDto SharedResponse { get; set; }
    }
}
