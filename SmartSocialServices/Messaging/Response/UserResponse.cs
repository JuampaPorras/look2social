using SmartSocialServices.DataTransferObjects;
using System.Collections.Generic;

namespace SmartSocialServices.Messaging.Response
{
    public class UserResponse : BaseResponse
    {
        public List<UserProfileDto> Users { get; set; }
        public UserProfileDto User { get; set; }
        public int userLastReportId { get; set; }
        public CompanyDto CompanyInformation { get; set; }

        public string BillingPortalUrl { get; set; }

        public UserResponse() {
            this.Users = new List<UserProfileDto>();
            this.User = new UserProfileDto();
        }
    }
}
