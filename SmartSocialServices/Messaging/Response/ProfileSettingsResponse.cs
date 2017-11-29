using System.Collections.Generic;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Objects;

namespace SmartSocialServices.Messaging.Response
{
    public class ProfileSettingsResponse: BaseResponse
    {
        public UserProfileDto UserProfile { get; set; }

    }
}
