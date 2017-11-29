using System.Web.Mvc;
using System.Collections.Generic;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Services;
using WebMatrix.WebData;
using System.Web.Security;

namespace SmartSocial.web.V2.Controllers
{
    public class CommentsController : Controller
    {
        readonly CommentsService _commentService = new CommentsService();

        [HttpGet]
        public JsonResult GetCommentsByChart(int smartChartId)
        {
            return Json(_commentService.GetCommentsByChart(smartChartId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddChartComment( int IdSmartChart, string Message)
        {
            return Json(_commentService.AddChartComment(new ChartCommentDto()
            {
                IdSmartChart = IdSmartChart,
                Message = Message,
                IdUser = WebSecurity.CurrentUserId.ToString()
            }), JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        public JsonResult DeactivateChartComment(int idComment)
        {
            string[] rolesArray = Roles.GetRolesForUser();
            return Json(_commentService.DeactivateCommentsByChartId(WebSecurity.CurrentUserId, idComment, rolesArray), JsonRequestBehavior.AllowGet);
        }

    }
}
