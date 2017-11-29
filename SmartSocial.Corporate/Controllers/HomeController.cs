using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Configuration;
using ChargifyNET;
using ChargifyNET.Configuration;
using SmartSocial.Corporate.Models;

namespace SmartSocial.Corporate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Services()
        {

            ViewBag.Title = "Our Services";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       [HttpPost]
        public ActionResult ChargifyWebHook()
        {
            //ViewBag.Message = "Your contact page.";

            //var responseText=string.Empty;
            //ChargifyAccountRetrieverSection config = ConfigurationManager.GetSection("chargify") as ChargifyAccountRetrieverSection;
            //ChargifyAccountElement accountInfo = config.GetDefaultOrFirst();

            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(accountInfo.Site + "webhooks.format");
            //httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            ////2.Pass the apikey and apipassword of chargify
            //httpWebRequest.Headers.Add("username:" + accountInfo.ApiKey);
            //httpWebRequest.Headers.Add("password:" + accountInfo.ApiPassword);
            ////3.pass basic authentication credentials
            //httpWebRequest.Credentials = new NetworkCredential(accountInfo.ApiKey, accountInfo.ApiPassword);
            ////4.Assign the httpWebRequest method ,here the method is GET
            //httpWebRequest.Method = "GET";


            ////https://domainname.chargify.com/

            //return View();

            WebhookEventData webHookdata = new WebhookEventData();
            webHookdata.@event = "signup_success";

            ChargifyAccountRetrieverSection config = ConfigurationManager.GetSection("chargify") as ChargifyAccountRetrieverSection;
            ChargifyAccountElement accountInfo = config.GetDefaultOrFirst();
            var sharedKey = accountInfo.SharedKey;

            var signatureHeaderHandle = "X-Chargify-Webhook-Signature-Hmac-Sha-256";
            //string signature = !string.IsNullOrEmpty(signature_hmac_sha_256) ? signature_hmac_sha_256 : this.Request.Headers[signatureHeaderHandle]; // Try and get the signature passed in the request header

            //ChargifyAccountRetrieverSection config = ConfigurationManager.GetSection("chargify") as ChargifyAccountRetrieverSection;
            //ChargifyAccountElement accountInfo = config.GetDefaultOrFirst();

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(accountInfo.Site + "webhooks.json");
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            //2.Pass the apikey and apipassword of chargify
            httpWebRequest.Headers.Add("username:" + accountInfo.ApiKey);
            httpWebRequest.Headers.Add("password:" + accountInfo.ApiPassword);
            //3.pass basic authentication credentials
            httpWebRequest.Credentials = new NetworkCredential(accountInfo.ApiKey, accountInfo.ApiPassword);
            //4.Assign the httpWebRequest method ,here the method is GET
            httpWebRequest.Method = "GET";
            
            
           // var isRequestValid = this.Request.InputStream.IsWebhookRequestValid(sharedKey, signature);

            //if (!isRequestValid) { return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable, "Signature mismatch"); }

            switch (webHookdata.@event)
            {
                case "signup_success":
                    break;
                case "signup_failure":
                    break;
                case "renewal_success":
                    break;
                case "renewal_failure":
                    break;
                case "payment_success":
                    break;
                case "payment_failure":
                    break;
                case "billing_date_change":
                    break;
                case "subscription_state_change":
                    break;
                case "subscription_product_change":
                    break;
                case "subscription_card_update":
                    break;
                case "expiring_card":
                    break;
                case "customer_update":
                    break;
                case "component_allocation_change":
                    break;
                case "metered_usage":
                    break;
                case "upgrade_downgrade_sucess":
                    break;
                case "upgrade_downgrade_failure":
                    break;
                case "refund_success":
                    break;
                case "refund_failure":
                    break;
                case "upcoming_renewal_notice":
                    break;
                case "end_of_trial_notice":
                    break;
                case "statement_closed":
                    break;
                case "statement_settled":
                    break;
                case "expiration_date_change":
                    break;
                default:
                    break;
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}
