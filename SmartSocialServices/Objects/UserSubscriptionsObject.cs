using SmartSocialServices.DataTransferObjects;
using System.Collections.Generic;

namespace SmartSocialServices.Objects
{
    public class UserSubscriptionsObjects
    {
        public ServiceSubscriptionDto ServiceSubscription { get; set; }
        public List<LeftNavReportObject> Reports { get; set; }   


        public UserSubscriptionsObjects() {
            this.Reports = new List<LeftNavReportObject>();
        }

    }
}
