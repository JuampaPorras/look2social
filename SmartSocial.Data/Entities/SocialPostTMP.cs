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
    public partial class SocialPostTMP
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdSocialPost { get; set; }

            public int? IdSmartReport { get; set; }

            public string SocialNetwork { get; set; }

            public string SenderScreenName { get; set; }

            [DataType(System.ComponentModel.DataAnnotations.DataType.Url)]
            public string SenderProfileImgUrl { get; set; }

            public string SenderFollowersCount { get; set; }

            public string Message { get; set; }

            public string MessageCreatedDate { get; set; }

            public string Permalink { get; set; }

            public string Country { get; set; }

            public bool? Completed { get; set; }

            public string Product { get; set; }

        }

        #endregion
    }
}