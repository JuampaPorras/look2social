using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;

namespace SmartSocial.Data
{
    public partial class SharedReports
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [CodeSmith.Data.Audit.Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdSharedReports { get; set; }

            public int CreatedBy { get; set; }

            public int SmartReportId { get; set; }

            public int? SharedWith { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Url)]
            public string Url { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Url)]
            public string TinyUrl { get; set; }

            public string Comments { get; set; }

            public string Token { get; set; }

            [Now(EntityState.New)]
            [CodeSmith.Data.Audit.NotAudited]
            public System.DateTime CreatedDate { get; set; }

            public System.DateTime ExpiredDate { get; set; }

            public bool IsActive { get; set; }

            public SmartReport SmartReport { get; set; }

        }

        #endregion
    }
}