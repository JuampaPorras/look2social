using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSocialServices.Services;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Utilities;
using SmartSocial.Corporate.Filters;
using System.Configuration;
using SmartSocialServices.Messaging.Response;

namespace SmartSocial.Corporate.Controllers
{
    [InitializeSimpleMembership]
    public class LeadController : Controller
    {
        //
        // GET: /Lead/
        LeadService _leadService = new LeadService();

        [HttpPost]
        public JsonResult AddFirstStep(string firstName, string lastName, string email, string countryCode, string phoneNumber)
        {
            var token = Guid.NewGuid().ToString();
            var leadDto = new LeadDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                CountryCode = countryCode,
                PhoneNumber = phoneNumber,
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                IntakeUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~") + "Intake/MoreInformation?token=" + token,
                IntakeToken = token
            };
            return Json(_leadService.CreateLead(leadDto, true), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult AddSecondStep(string token, string firstName, string lastName, string email, string countryCode, string phoneNumber, string aliases, string keywords, string productName, string productURL, string marketSegments, string otherMarketSegments, string competitors, string notes, string idLead)
        {
            //TODO Prepare Image for Database

            var leadDto = new LeadDto()
            {   
                //The intake token to identify the "lead" in the database
                IntakeToken = token,

                //from the First Step
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                CountryCode = countryCode,
                PhoneNumber = phoneNumber,
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                IntakeUrl = "",

                //From the 2nd step 
                Aliases = aliases,
                Keywords = keywords,
                ProductName = productName,
                ProductURL = productURL,
                MarketSegments = marketSegments,
                OtherMarketSegments = otherMarketSegments,
                Competitors = competitors,
                Notes = notes,
                IsActive = true,
                idLead = int.Parse(idLead)
            };
            var urlToValidateUser =
                 ConfigurationManager.AppSettings["SmartSocialWeb"];


            return Json(_leadService.UpdateLead(leadDto, urlToValidateUser), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult AddLead(string token, string firstName, string lastName, string email, string countryCode, string phoneNumber, string aliases, string keywords, string productName, string productURL, string marketSegments, string otherMarketSegments, string competitors, string notes, string idLead, string ProductType)
        {
            try
            {
                //TODO Prepare Image for Database
                token = Guid.NewGuid().ToString();

                var leadDto = new LeadDto()
                {
                    //The intake token to identify the "lead" in the database
                    IntakeToken = token,

                    //from the First Step
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    CountryCode = countryCode,
                    PhoneNumber = phoneNumber,
                    DateUpdated = DateTime.Now,
                    DateCreated = DateTime.Now,
                    IntakeUrl = "",

                    //From the 2nd step 
                    Aliases = aliases,
                    Keywords = keywords,
                    ProductName = productName,
                    ProductURL = productURL,
                    MarketSegments = marketSegments,
                    OtherMarketSegments = otherMarketSegments,
                    Competitors = competitors,
                    Notes = notes,
                    IsActive = true,
                    //idLead = int.Parse(idLead)
                };
                LeadResponse response = _leadService.CreateLead(leadDto, false);

                if (response.Acknowledgment == false && ProductType == "Trial")
                    throw new System.ArgumentException("The email is already registered as a user. Please choose another one.");

                var url = ConfigurationManager.AppSettings[ProductType] + "?first_name=" + firstName + "&last_name=" + lastName + "&email=" + email + "&reference=" + token + "&phone=" + countryCode + phoneNumber;
                return Json(new { success = true, toUrl = url });
            }catch(Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }
            ///return Redirect(url);

        }

    }
}
