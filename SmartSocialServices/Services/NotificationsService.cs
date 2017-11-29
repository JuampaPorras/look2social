using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSocial.Data.V2;

namespace SmartSocialServices.Services
{
    public class NotificationsService
    {
        public NotificationsResponse GetNotificationsByUser(int userId) {
            var response = new NotificationsResponse();
            try
            {
                var notificationRepository = new NotificationRepository();
                var notifications = notificationRepository.Query().Where(x => x.CreateBy == userId).OrderByDescending(x=> x.CreatedDate).ToList();
                var newNotificationsCount = 0;
                foreach (var notification in notifications) {
                    bool wasViewed = (notification.WasViewed.HasValue) ? notification.WasViewed.Value : false;
                    if (!wasViewed)
                    {
                        newNotificationsCount++;
                    }

                    response.NotificationsList.Add(new NotificationDto() {
                        idNotification = notification.idNotification,
                        CreatedDate = notification.CreatedDate.Value,
                        Text = notification.Text,
                        WasViewed = notification.WasViewed
                    });
                }
                response.NotificationsCount = newNotificationsCount;
                notificationRepository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex) {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public BaseResponse SetAllNotificationsAsViewed(int userId) {
            var response = new BaseResponse();
            try
            {
                var notificationRepository = new NotificationRepository();
                var notifications = notificationRepository.Query().Where(x => x.CreateBy == userId).ToList();
                notifications.ForEach(notification => notification.WasViewed = true);
                notificationRepository.SaveChanges();
                notificationRepository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public BaseResponse AddNotification(NotificationDto notificationDto) {
            var response = new BaseResponse();
            try {
                var notificationRepository = new NotificationRepository();
                var newNotification = new Notification()
                {
                    CreateBy = notificationDto.CreateBy,
                    CreatedDate = DateTime.Now,
                    Text = notificationDto.Text,
                    UpdatedDate = DateTime.Now,
                    WasViewed = false
                };
                notificationRepository.Add(newNotification);
                notificationRepository.SaveChanges();
                notificationRepository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";
            }catch(Exception ex){
                response.Acknowledgment = true;
                response.Message = "Error addin a notification: "+ex.Message;
            }
            return response;
        }

        public BaseResponse DeleteNotifications(int userId)
        {
            var response = new BaseResponse();
            try
            {
                var notificationRepository = new NotificationRepository();
                var notificationsToDelete=notificationRepository.Query().Where(x => x.CreateBy == userId).OrderByDescending(x=>x.CreatedDate);
                if (notificationsToDelete.Count()>10)
                {
                    foreach (var notification in notificationsToDelete.Skip(10))
                    {
                        notificationRepository.Delete(notification);
                    }
                }
                notificationRepository.SaveChanges();
                notificationRepository.Dispose();
                response.Acknowledgment = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Acknowledgment = true;
                response.Message = "Error deleting a notification: " + ex.Message;
            }
            return response;
        }

    }
}
