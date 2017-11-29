using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSocialServices.DataTransferObjects;

namespace SmartSocialServices.Messaging.Response
{
    public class SharedReportsResponse : BaseResponse
    {
        public List<SharedReportDto> SharedByMeReports { get; set; }
        public List<SharedReportDto> SharedWithMeReports { get; set; }
    }
}
