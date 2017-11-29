using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

namespace SmartSocial.web.V2.Controllers
{
    public class NotificationsController : Controller
    {
        //
        // GET: /Notifications/

        NotificationsService _notificationService = new NotificationsService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetUserNotifications()
        {
            //return Json(_notificationService.GetNotificationsByUser(WebSecurity.CurrentUserId), JsonRequestBehavior.AllowGet);
            return Json(_notificationService.GetNotificationsByUser(WebSecurity.CurrentUserId), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult SetViewed()
        {
            return Json(_notificationService.SetAllNotificationsAsViewed(WebSecurity.CurrentUserId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult AddReportNotification()
        {
            var notificationDto = new NotificationDto()
            {
                CreateBy = WebSecurity.CurrentUserId,
                Text = "You PDF file has been created",
                WasViewed = false
            };
            return Json(_notificationService.AddNotification(notificationDto), JsonRequestBehavior.AllowGet);
        }
    }
}
