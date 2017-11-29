using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSocialServices.Services;
using SmartSocialServices.DataTransferObjects;

namespace SmartSocial.Web.V2.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        CommentsService _commentmService = new CommentsService();

        public ActionResult Index()
        {
            return View();
        }

    }
}
