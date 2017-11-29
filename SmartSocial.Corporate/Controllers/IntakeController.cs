using SmartSocialServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSocial.Corporate.Controllers
{
    public class IntakeController : Controller
    {
        LeadService _leadService = new LeadService();

        public ActionResult MoreInformation()
        {

            return View();

        }
        public ActionResult Subscribe(string ProductType)
        {
            return View();
        }

        [HttpGet]
        public JsonResult Load1stLeadPart(string strToken)
        {
            return Json(_leadService.GetLeadByToken(strToken), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Load1stLeadPartChargify(string subscription_id, string customer_id)
        {
            return Json(_leadService.ChargifySuscription(subscription_id, customer_id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SuccessSubscription(string subscription_id, string customer_id, string customer_reference)
        {
            _leadService.CreateUser(subscription_id, customer_id, customer_reference);
            return View("");
        }
    }
}
