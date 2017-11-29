using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;
using System.ComponentModel.DataAnnotations;
using CodeSmith.Data.Audit;

namespace SmartSocial.Data
{
    public partial class UsersXSubscription
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdSubscription { get; set; }

            [Required]
            public string IdUser { get; set; }

            public System.DateTime? DateCreated { get; set; }

            public ServiceSubscription IdSubscriptionServiceSubscription { get; set; }

        }

        #endregion
    }
}