using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using SmartSocialServices.Objects;

namespace SmartSocialServices.DataTransferObjects
{
    public partial class SharedReportDto
    {
        public string SubscriptionName { get; set; }
        public string ReportName { get; set; }
        public string CreatorName { get; set; }
        public string ShareWithName { get; set; }
    }
}
