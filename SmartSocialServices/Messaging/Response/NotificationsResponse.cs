using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Objects;
using System.Collections.Generic;


namespace SmartSocialServices.Messaging.Response
{
    public class NotificationsResponse : BaseResponse
    {
        public NotificationDto Notification { get; set; }
        public List<NotificationDto> NotificationsList { get; set; }
        public int NotificationsCount { get; set; }

        public NotificationsResponse() {
            this.NotificationsList = new List<NotificationDto>();
        }
    }
}
