using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartSocialServices.Messaging.Response;

namespace SmartSocial.web.V2.Models
{
    public class IndividualChartViewModel
    {
        public int ChartId { get; set; }
        public int ChartTypeId { get; set; }
        public bool WithInsights { get; set; }
        public bool WithComments { get; set; }
        public string Insights { get; set; }
        public string ChartName { get; set; }
        public CommentsResponse Comments { get; set; }
        public string From { get; set; }
        public string To { get; set; }

    }
}