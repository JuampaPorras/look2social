using SmartSocialServices.Objects;

namespace SmartSocialServices.Messaging.Response
{
    public class ChartDataReponse : BaseResponse
    {
        public dynamic ChartData { get; set; }
        public dynamic PastDelivery { get; set; }

        public SeriesObject Series { get; set; }

        public ChartDataReponse() {
            Series = new SeriesObject();
        }
             
    }
}
