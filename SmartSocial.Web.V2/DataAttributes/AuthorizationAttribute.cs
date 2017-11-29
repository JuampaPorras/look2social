using System.Web.Mvc;
using System.Web.Routing;
using WebMatrix.WebData;

namespace SmartSocial.web.V2.DataAttributes
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public bool IsPublic { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!WebSecurity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "Login",
                    controller = "Account",
                    area = "",
                    ReturnUrl = filterContext.HttpContext.Request.CurrentExecutionFilePath
                }));
            }
        }

    }
}