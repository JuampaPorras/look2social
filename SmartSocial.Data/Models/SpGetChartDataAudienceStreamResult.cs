using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;
using CodeSmith.Data.Audit;

namespace SmartSocial.Data
{
    public partial class SpGetChartDataAudienceStreamResult
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public string SocialNetwork { get; set; }

            public string UserName { get; set; }

            public string FullName { get; set; }

            public string Bio { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Url)]
            public string ProfileUrl { get; set; }

            public string Statuses { get; set; }

            public string Reach { get; set; }

            public string Followers { get; set; }

            public string Following { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Url)]
            public string ProfileImageUrl { get; set; }

        }

        #endregion
    }
}