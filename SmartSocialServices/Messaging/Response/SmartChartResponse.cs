using System.Collections.Generic;
using SmartSocialServices.DataTransferObjects;

namespace SmartSocialServices.Messaging.Response
{
    public class SmartChartResponse : BaseResponse
    {
        public ServiceDeliveryDto Delivery { get; set; }
        public SmartReportDto SmartReport { get; set; }
        public List<SmartChartDto> SmartCharts { get; set; }

        public SmartChartResponse() {
            SmartCharts = new List<SmartChartDto>();
        }
    }
}
