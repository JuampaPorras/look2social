using System;
using System.Web.Mvc;
using System.Configuration;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Services;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Utilities;
using System.Collections.Generic;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

namespace SmartSocial.web.V2.Controllers
{
    public class ManageController : Controller
    {
        //
        // GET: /Manage/

        UserService _userService = new UserService();
        ChartsService _chartService = new ChartsService();
        ShareReportService _sharedReportService = new ShareReportService();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetUserProfilePage()
        {
            return Json(_userService.GetProfileSettingsByUserId(WebSecurity.CurrentUserId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetUserInfoById(int userId, int subsId)
        {
            return Json(_userService.GetUserInSubsById(userId, subsId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetUserInfoByIdWithRoles(int userId, int subsId)
        {
            return Json(_userService.GetUserInfoByIdWithRoles(userId, subsId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetSubscriptionRoles(int subsId)
        {
            return Json(_userService.GetSubscriptionRoles(subsId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetBillingPortal()
        {
            return Json(_userService.GetBillingPortal(WebSecurity.CurrentUserId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult UpdateProfileSettings(string pFirstName, string pLastName, int pPhone, string pCountryCode)
        {
            return Json(_userService.UpdateProfileSettings(WebSecurity.CurrentUserId, pFirstName, pLastName, pPhone, pCountryCode), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetUserXSubscriptions(int subscriptionId)
        {
            return Json(_userService.GetUsersPerSubscriptionId(subscriptionId, WebSecurity.CurrentUserId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetUserAdminSbscription()
        {
            return Json(_userService.GetSubscriptions(WebSecurity.CurrentUserId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult DeactivateUser(int userId, int subId)
        {
            return Json(_userService.DeactivateUserFromSub(userId,subId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeactivateRolesUserSubscription(int userId,int subscriptionId, int[] rolesId)
        {
            return Json(_userService.EditRolesUserSubscription(userId, subscriptionId, rolesId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult DeactivateSharedReport(int shareId)
        {
            return Json(_sharedReportService.DeleteSharedReport(shareId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult AddNewUserXSubscription(string email,int subscriptionId, int[] roleIds,string firstName, string lastName, int phone, string countryCode) {
            return Json(_userService.AddNexUserXSubscription(email, WebSecurity.CurrentUserId, firstName,lastName,phone,countryCode,subscriptionId, roleIds, ConfigurationManager.AppSettings["SmartSocialWeb"]), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult AddUserXSubscription(int userId, int subscriptionId, int[] roleIds)
        {

            return Json(_userService.AddUserXSubscription(userId,WebSecurity.CurrentUserId, subscriptionId, roleIds), JsonRequestBehavior.AllowGet);
        }

    }
}
