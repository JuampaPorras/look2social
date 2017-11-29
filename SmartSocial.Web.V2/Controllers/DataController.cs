using System;
using System.Web.Mvc;
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
    public class DataController : Controller
    {
        UserService _userService = new UserService();
        ChartsService _chartService = new ChartsService();
        ShareReportService _sharedReportService = new ShareReportService();

        [HttpGet]
        [AllowAnonymous]
        public JsonResult MainPageData()
        {
            string[] rolesArray = Roles.GetRolesForUser();
            var mainPageInfo = _userService.GetMainPageInfo(WebSecurity.CurrentUserId, rolesArray, WebSecurity.CurrentUserName);
            return Json(mainPageInfo, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetUserSubscriptions()
        {
            return Json(_userService.GetUserSubscriptionDeliveriesReportsById(WebSecurity.CurrentUserId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetChartsBySmartReportId(int smartReportId)
        {
            var userService = new UserService();
            //userService.UpdateLastReport(Convert.ToInt32(Session["userId"].ToString()), smartReportId);
            userService.UpdateLastReport(WebSecurity.CurrentUserId, smartReportId);
            return Json(_chartService.GetChartsBySmartReportId(smartReportId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetChartDataByChartTypeId(int chartTypeId, int smartChartId, string from, string to)
        {
            var listOfCharts = new List<int>();
            //if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to) && !from.Equals(to))
            //{
            var chart = _chartService.GetSmartChartById(smartChartId);
            if (chart != null && !string.IsNullOrEmpty(chart.ChartName))
            {
                listOfCharts = _chartService.GetChartsIdByDateRange( smartChartId, chart.ChartName, from, to);
            }

            //}
            //else {
            //    listOfCharts.Add(smartChartId);
            //}
            switch (chartTypeId)
            {
                case 1:
                    return Json(_chartService.GetColumnsChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                case 2:
                    return Json(_chartService.GetLinearChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                case 3:
                    return Json(_chartService.GetStackedColumnChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                //case 4:
                //    //treemap
                //    break;
                case 5:
                    return Json(_chartService.GetWordCloudChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                case 6:
                    return Json(_chartService.GetPieChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                case 7:
                    return Json(_chartService.GetMostProlificUsersChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                case 8:
                    return Json(_chartService.GetLocationAnalysisChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                case 9:
                    return Json(_chartService.GetReachSummaryChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                //case 10:
                //    break;
                //Conversation Stream
                case 11:
                    return Json(_chartService.GetMentionSummaryChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                case 12:
                    return Json(_chartService.GetBestDaySummaryChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                case 13:
                    return Json(_chartService.GetTopUserSummaryChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                case 14:
                    return Json(_chartService.GetTopPostChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                case 15:
                    return Json(_chartService.GetTopPostByProductChartData(listOfCharts), JsonRequestBehavior.AllowGet);
                default:
                    return Json(new BaseResponse { Acknowledgment = false, Message = "None Chart Match with that Chart Type Id" }, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetConversationStream(int[] reportId, string filter, int rowsSkipped)
        {
            return Json(_chartService.GetConversationStream(reportId, filter, rowsSkipped), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetConversationStreamMessage(int[] reportId, string filter, int rowsSkipped)
        {
            return Json(_chartService.GetConversationStreamMessage(reportId, filter, rowsSkipped), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetSharedreport(string comments, int smartReportid, string url)
        {

            var currentUrl = Request.RawUrl;
            var token = Guid.NewGuid().ToString();
            var sharedReportDto = new SharedReportDto()
            {
                Comments = comments,
                CreatedBy = WebSecurity.CurrentUserId,
                CreatedDate = DateTime.Now,
                ExpiredDate = DateTime.Now.AddDays(365.0),
                IsActive = true,
                Token = token,
                SmartReportId = smartReportid,
                URL = url,
                TinyUrl = TinyURL.GetTinyUrl(Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~") + "Share/Redirect?token=" + token)
            };
            return Json(_sharedReportService.AddSharedReport(sharedReportDto), JsonRequestBehavior.AllowGet);
        }





    }
}
