using System;
using System.Web.Mvc;
using System.Linq;
using System.IO;
using SmartSocial.web.V2.DataAttributes;
using SmartSocial.web.V2.Models;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Services;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Utilities;
using System.Diagnostics;
using NLog;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

namespace SmartSocial.web.V2.Controllers
{
    public class HomeController : Controller
    {
        ChartsService _chartService = new ChartsService();
        NotificationsService _notificationService = new NotificationsService();
        readonly CommentsService _commentService = new CommentsService();
        private static readonly Logger _log = LogManager.GetCurrentClassLogger();


        [Authorize]
        [Authorization]
        public ActionResult Main()
        {

            return View();
        }

        [Authorize]
        [Authorization]
        public ActionResult NoReport()
        {

            return View();
        }

        [Authorize]
        [Authorization]
        public ActionResult MainToPdf(int reportId, bool withInsights, bool withComments, bool withChartInsights, int chartId,string from, string to)
        {
            var charts = _chartService.GetChartsBySmartReportId(reportId);
            var model = new MainToPDFViewModel()
            {
                Report = charts,
                WithInsights = withInsights,
                WithComments = withComments,
                WithChartInsights = withChartInsights,
                ReportId = reportId,
                ChartId = chartId,
                DateRange = charts.Delivery.DateDelivered.GetValueOrDefault().ToString("MMM") + ", " + charts.Delivery.DateDelivered.GetValueOrDefault().Year,
                From=from,
                To=to
            };
            return View(model);
        }

        public ActionResult IndividualChart(int chartId, bool withInsights, bool withComments, string insights, int chartTypeId, string chartName, string from, string to)
        {
            var comments = _commentService.GetCommentsByChart(chartId);
            var model = new IndividualChartViewModel()
            {
                ChartId = chartId,
                Insights = insights,
                WithInsights = withInsights,
                WithComments = withComments,
                ChartTypeId = chartTypeId,
                ChartName = chartName,
                Comments = comments,
                From = from,
                To = to
            };
            return View(model);
        }

        public JsonResult UrlAsPDF(int reportId, bool withInsights, bool withChartInsights, bool withComments, string reportName, string from, string to)
        {
            var response = new NotificationsResponse();
            try
            {
                var pdf = new Rotativa.ActionAsPdf("MainToPdf", new { reportId = reportId, withComments = withComments, withInsights = withInsights, withChartInsights = withChartInsights, chartId = 0, from = from, to = to })
                {
                    FileName = reportName + ".pdf",
                    IsJavaScriptDisabled = false,
                    PageMargins = { Left = 10, Right = 10 }
                };
                _log.Warn("Started");
                byte[] applicationPDFData = pdf.BuildPdf(ControllerContext);
                var path = Server.MapPath("~/Reports/Pdf");
                var fileName = reportName + WebSecurity.CurrentUserId + ".pdf";
                if (!System.IO.Directory.Exists(path + "/" + WebSecurity.CurrentUserId.ToString()))
                {
                    System.IO.Directory.CreateDirectory(path + "/" + WebSecurity.CurrentUserId.ToString());
                }
                var directory = new DirectoryInfo(path + "/" + WebSecurity.CurrentUserId.ToString());
                path = System.IO.Path.Combine(path, WebSecurity.CurrentUserId.ToString(), fileName);
                System.IO.File.WriteAllBytes(path, applicationPDFData);
                var fileUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~") + "/Reports/Pdf/" + WebSecurity.CurrentUserId.ToString() + "/" + fileName;
                var filesOrdered = directory.GetFiles().OrderByDescending(x => x.LastWriteTime);
                if (filesOrdered.Count() > 10)
                {
                    var files = filesOrdered.Skip(10).ToList();
                    foreach (var file in files)
                    {
                        file.Delete();
                    }
                }
                var notificationDto = new NotificationDto()
                {
                    CreateBy = WebSecurity.CurrentUserId,
                    Text = "Your \"" + reportName + "\" PDF is ready <a href='" + fileUrl + "' target='_blank'>here</a>",
                    WasViewed = false,
                    CreatedDate = DateTime.Now
                };
                if (_notificationService.AddNotification(notificationDto).Acknowledgment)
                {
                    response.Notification = notificationDto;
                    response.Acknowledgment = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Acknowledgment = false;
                    response.Message = "Error";
                }
                _notificationService.DeleteNotifications(WebSecurity.CurrentUserId);

            }
            catch (Exception ex)
            {
                ViewBag.myData = "error: " + ex.Message;
                _log.Error("---- Exception Creating PDF: " + ex.Message + " ----");//("Exception Creating PDF", ex.Message);
                response.Acknowledgment = false;
                response.Message = "Error";
            }
            return Json(response, JsonRequestBehavior.AllowGet);


            //return RedirectToAction("MainToPdf", new { reportId = reportId });;
        }

        public JsonResult ChartAsPDF(int reportId, int chartId, bool withChartInsights, bool withComments, string reportName, string chartName, string from, string to)
        {
            var response = new NotificationsResponse();
            try
            {
                var pdf = new Rotativa.ActionAsPdf("MainToPdf", new { reportId = reportId, withComments = withComments, withInsights = false, withChartInsights = withChartInsights, chartId = chartId, from = from, to = to })
                {
                    FileName = reportName + ".pdf",
                    IsJavaScriptDisabled = false,
                    PageMargins = { Left = 10, Right = 10 }
                };
                _log.Warn("Started");
                byte[] applicationPDFData = pdf.BuildPdf(ControllerContext);
                var path = Server.MapPath("~/Reports/Pdf");
                var fileName = reportName + WebSecurity.CurrentUserId + ".pdf";
                if (!System.IO.Directory.Exists(path + "/" + WebSecurity.CurrentUserId.ToString()))
                {
                    System.IO.Directory.CreateDirectory(path + "/" + WebSecurity.CurrentUserId.ToString());
                }
                var directory = new DirectoryInfo(path + "/" + WebSecurity.CurrentUserId.ToString());
                path = System.IO.Path.Combine(path, WebSecurity.CurrentUserId.ToString(), fileName);
                System.IO.File.WriteAllBytes(path, applicationPDFData);
                var fileUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~") + "/Reports/Pdf/" + WebSecurity.CurrentUserId.ToString() + "/" + fileName; var notificationDto = new NotificationDto()
                {
                    CreateBy = WebSecurity.CurrentUserId,
                    Text = "Your \"" + chartName + "\" PDF is ready <a href='" + fileUrl + "' target='_blank'>here</a>",
                    WasViewed = false,
                    CreatedDate = DateTime.Now
                };
                var filesOrdered = directory.GetFiles().OrderByDescending(x => x.LastWriteTime);
                if (filesOrdered.Count() > 10)
                {
                    var files = filesOrdered.Skip(10).ToList();
                    foreach (var file in files)
                    {
                        file.Delete();
                    }
                }
                if (_notificationService.AddNotification(notificationDto).Acknowledgment)
                {
                    response.Notification = notificationDto;
                    response.Acknowledgment = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Acknowledgment = false;
                    response.Message = "Error";
                }
                _notificationService.DeleteNotifications(WebSecurity.CurrentUserId);

            }
            catch (Exception ex)
            {
                ViewBag.myData = "error: " + ex.Message;
                _log.Error("---- Exception Creating PDF: " + ex.Message + " ----");//("Exception Creating PDF", ex.Message);
                response.Acknowledgment = false;
                response.Message = "Error";
            }
            return Json(response, JsonRequestBehavior.AllowGet);


            //return RedirectToAction("MainToPdf", new { reportId = reportId });;
        }


    }
}
