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
    public partial class ServiceSubscription
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public int IdServiceSubscription { get; set; }

            public string SubscriptionName { get; set; }

            public System.DateTime? StartDate { get; set; }

            public System.DateTime? EndDate { get; set; }

            public bool? IsActive { get; set; }

            public EntitySet<ServiceDelivery> ServiceDeliveryList { get; set; }

            public EntitySet<UsersXSubscription> IdSubscriptionUsersXSubscriptionList { get; set; }

        }

        #endregion
    }
}