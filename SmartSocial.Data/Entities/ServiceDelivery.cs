using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;
using System.Data.Linq;
using CodeSmith.Data.Audit;

namespace SmartSocial.Data
{
    public partial class ServiceDelivery
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdServiceDelivery { get; set; }

            public System.DateTime? DateDelivered { get; set; }

            public int? IdServiceSubscription { get; set; }

            public string Insights { get; set; }

            public System.DateTime? DeliveryDateTo { get; set; }

            public ServiceSubscription ServiceSubscription { get; set; }

            public EntitySet<SmartReport> SmartReportList { get; set; }

        }

        #endregion
    }
}