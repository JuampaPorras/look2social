using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;
using CodeSmith.Data.Audit;

namespace SmartSocial.Data
{
    public partial class SpGetDeliveryReportsResult
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdSmartReport { get; set; }

            public int? IdServiceDelivery { get; set; }

            public string ReportName { get; set; }

            public string Insights { get; set; }

            public System.DateTime? DateCreated { get; set; }

            public bool? IsTemplate { get; set; }

        }

        #endregion
    }
}