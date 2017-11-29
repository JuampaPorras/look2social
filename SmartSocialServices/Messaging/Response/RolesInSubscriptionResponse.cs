using System.Collections.Generic;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Objects;

namespace SmartSocialServices.Messaging.Response
{
    public class RolesInSubscriptionReponse : BaseResponse
    {
        public List<RoleActive> RolesInSubscription { get; set; }
        public RolesInSubscriptionReponse()
        {
            this.RolesInSubscription = new List<RoleActive>();
        }
    }
}