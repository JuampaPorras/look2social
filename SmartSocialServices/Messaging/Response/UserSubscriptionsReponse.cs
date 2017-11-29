using System.Collections.Generic;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Objects;

namespace SmartSocialServices.Messaging.Response
{
    public class UserSubscriptionsReponse: BaseResponse
    {
        public ServiceSubscriptionDto ServiceSubscription { get; set; }
        public List<UserSubscriptionsObjects> UserSubscriptionsObjects { get; set; }
        public List<LeftNavReportObject> ShareWithMe { get; set; }

        public UsersXSubscriptionDto UsersXSubscription { get; set; }

        public UserSubscriptionsReponse()
        {
            UserSubscriptionsObjects = new List<UserSubscriptionsObjects>();
        }

    }
}
