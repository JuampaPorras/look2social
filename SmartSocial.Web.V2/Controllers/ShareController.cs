using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Services;
using SmartSocialServices.Utilities;
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
    public class ShareController : Controller
    {
        ShareReportService _sharedReportService = new ShareReportService();
        UserService _userService = new UserService();
        //
        // GET: /Share/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Redirect() {
            var token = "";
            try
            {
                token = Request.QueryString["token"];
            }
            catch {
                return RedirectToAction("Login", "Account");
            }
            if (token != "")
            {
                var sharedReportResponse = _sharedReportService.GetSharedReportByToken(token);
                if (sharedReportResponse.Acknowledgment)
                {
                    return Redirect(sharedReportResponse.SharedResponse.URL+"/share/true");
                }                
            }
            else {
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public JsonResult User(string email)
        {
            return Json(_userService.SearchUsersByEmail(email), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Invite(string email, int[] smartReportid,string comment,string ranges,string reportName,bool sendMeACopy)
        {
            var shareReports = new List<SharedReportDto>();
            var currentUrl = Request.RawUrl;

            foreach (var id in smartReportid)
            {
                var token = Guid.NewGuid().ToString();
                shareReports.Add(new SharedReportDto()
                {
                    Comments = "comment",
                    CreatedBy = WebSecurity.CurrentUserId,
                    CreatedDate = DateTime.Now,
                    ExpiredDate = DateTime.Now.AddDays(365.0),
                    IsActive = true,
                    Token = token,
                    SmartReportId = id,
                    URL = currentUrl,
                    TinyUrl = TinyURL.GetTinyUrl(Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~") + "Share/Redirect?token=" + token)
                });
                
            }
            var urlToValidateUser = Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~");
            return Json(_userService.InviteUser(email, shareReports, urlToValidateUser,  comment,  ranges,  reportName,  sendMeACopy), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserSharedReports()
        {
            return Json(_sharedReportService.GetSharedReportsByUser(WebSecurity.CurrentUserId), JsonRequestBehavior.AllowGet);
        }
    }
}
