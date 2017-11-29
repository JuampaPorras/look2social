using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartSocialServices.Messaging.Response;

namespace SmartSocial.web.V2.Models
{
    public class MainToPDFViewModel
    {
        public int ReportId { get; set; }
        public int ChartId { get; set; }

        public bool WithInsights { get; set; }
        public bool WithChartInsights { get; set; }
        public bool WithComments { get; set; }
        public SmartChartResponse Report { get; set; }
        public string DateRange { get; set; }
        public string From { get; set; }
        public string To { get; set; }

    }
}