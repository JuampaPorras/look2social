using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;


namespace SmartSocialServices.Repositories
{
    public class NotificationRepository: EntityRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(SmartSocialContext context) : base(context) {  }
        public NotificationRepository() : base() { }
    }
}
