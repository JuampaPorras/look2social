using System;
using System.Collections.Generic;
using System.Linq;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Objects;
using SmartSocialServices.Repositories;
using SmartSocial.Data.V2;
using System.Net.Mail;
using System.Text;
using System.IO;
using SmartSocialServices.Utilities;
using System.Web.Security;
using WebMatrix.WebData;
using ChargifyNET;
using System.Configuration;

namespace SmartSocialServices.Services
{
    public class LeadService
    {
        public LeadResponse CreateLead(LeadDto leadDto, bool sendMail) {
            

            var response = new LeadResponse();
            try
            {
                UserService _userService = new UserService();

               // _userService.GetUserInformation
                if (ValidateLeadEmail(leadDto.Email))
                {
                    var leadRepository = new LeadRepository();
                    var newLead = new Lead()
                    {
                        Aliases = leadDto.Aliases,
                        CountryCode = leadDto.CountryCode,
                        DateCreated = leadDto.DateCreated,
                        DateUpdated = leadDto.DateUpdated,
                        Email = leadDto.Email,
                        FirstName = leadDto.FirstName,
                        LastName = leadDto.LastName,
                        Keywords = leadDto.Keywords,
                        PhoneNumber = leadDto.PhoneNumber,
                        MarketSegments = leadDto.MarketSegments,
                        OtherMarketSegments = leadDto.OtherMarketSegments,
                        IntakeEmailSentDate = DateTime.Now,
                        IntakeToken = leadDto.IntakeToken,
                        IntakeUrl = leadDto.IntakeUrl,
                        IsActive = true,
                        IsIntakeAnswered = false
                    };
                    leadRepository.Add(newLead);
                    leadRepository.SaveChanges();
                    leadDto.idLead = newLead.idLead;
                    response.Acknowledgment = true;
                    response.Message = "Success";

                    if (sendMail)
                        SendLeadConfirmationEmail(leadDto.Email, leadDto.FirstName, leadDto.IntakeUrl);
                    response.Lead = leadDto;
                }
                else
                {
                    //response.Acknowledgment = false;
                    //response.Message = "Error Adding a Lead: Email already exist";
                    //response.Lead = null;
                    throw new System.ArgumentException("The email is already registered as a user. Please choose another one.");
                }

            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
                response.Lead = null;
            }
            return response;
        }

        private bool ValidateLeadEmail(string email) 
        {
            var leadRepository = new LeadRepository();
            var currentLead = leadRepository.Query().FirstOrDefault(x => x.Email == email);
            return (currentLead == null);
        }
        
        public BaseResponse UpdateLead(LeadDto leadDto, string urlToValidateUser) {
            var response = new BaseResponse();
            try
            {
                var leadRepository = new LeadRepository();
                var currentLead = leadRepository.Query().FirstOrDefault(x=> x.idLead == leadDto.idLead);

                if(currentLead != null)
                {
                    currentLead.FirstName = (leadDto.FirstName != null && !leadDto.FirstName.Equals("")) ? leadDto.FirstName : currentLead.FirstName;
                    currentLead.LastName = (leadDto.LastName != null && !leadDto.LastName.Equals("")) ? leadDto.LastName : currentLead.LastName;
                    currentLead.CountryCode = (leadDto.CountryCode != null && !leadDto.CountryCode.Equals("")) ? leadDto.CountryCode : currentLead.CountryCode; 
                    currentLead.PhoneNumber = (leadDto.PhoneNumber != null && !leadDto.PhoneNumber.Equals("")) ? leadDto.PhoneNumber : currentLead.PhoneNumber;
                    currentLead.Email = (leadDto.Email != null && !leadDto.Email.Equals("")) ? leadDto.Email : currentLead.Email;
                    
                    currentLead.ProductName = (leadDto.ProductName != null && !leadDto.ProductName.Equals("")) ? leadDto.ProductName : currentLead.ProductName;
                    currentLead.ProductURL = (leadDto.ProductURL != null && !leadDto.ProductURL.Equals("")) ? leadDto.ProductURL : currentLead.ProductURL;
                    currentLead.Aliases = (leadDto.Aliases != null && !leadDto.Aliases.Equals("")) ? leadDto.Aliases : currentLead.Aliases;
                    currentLead.Keywords = (leadDto.Keywords != null && !leadDto.Keywords.Equals("")) ? leadDto.Keywords : currentLead.Keywords;

                    currentLead.Competitors = (leadDto.Competitors != null && !leadDto.Competitors.Equals("")) ? leadDto.Competitors : currentLead.Competitors;
                    currentLead.Notes = (leadDto.Notes != null && !leadDto.Notes.Equals("")) ? leadDto.Notes : currentLead.Notes;
                    currentLead.MarketSegments = (leadDto.MarketSegments != null && !leadDto.MarketSegments.Equals("")) ? leadDto.MarketSegments : currentLead.MarketSegments;
                    currentLead.OtherMarketSegments = (leadDto.OtherMarketSegments != null && !leadDto.OtherMarketSegments.Equals("")) ? leadDto.OtherMarketSegments : currentLead.OtherMarketSegments;
                    currentLead.DateUpdated = DateTime.Now;

                    currentLead.IsIntakeAnswered = true;
                    currentLead.IsActive = leadDto.IsActive;
                }
                leadRepository.SaveChanges();

                // Create Chargify Suscription
                SubscriptionService chargifyService = new SubscriptionService();
                ISubscription subscription = null;

                if(currentLead.IntakeUrl == "")
                    subscription = chargifyService.GetSubscription(int.Parse(currentLead.IntakeToken));

                int serviceSuscriptionId = 0;
                if (subscription == null)
                {
                    subscription = chargifyService.SubscribeChargifyTrial(currentLead);
                    
                    // Create System Suscription
                    if (subscription != null)
                    {
                        // Create Trial Suscription
                        serviceSuscriptionId = chargifyService.AddTrialServiceSubscription(subscription.SubscriptionID.ToString(), subscription.Customer.ChargifyID.ToString(), currentLead.idLead);
                    }
                    else
                    {
                        response.Acknowledgment = false;
                        response.Message = "Invalid Charify Suscription";
                        return response;
                    }
                }

                //Create new System User
                UserService _userService = new UserService();
                _userService.TrialCreateUser(currentLead.Email, 1, urlToValidateUser, subscription.SubscriptionID, subscription.Customer.ChargifyID, serviceSuscriptionId);

                // Send Lead Confirmation
                string token = WebSecurity.GeneratePasswordResetToken(currentLead.Email);
                SendTrialIntakeConfirmationEmail(currentLead.Email, currentLead.FirstName, urlToValidateUser + token);

                response.Acknowledgment = true;
                response.Message = "Success";
               
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Updating a Lead: "+ex.Message;
            }
            return response;
        }


        public BaseResponse CreateUser(string subscription_id, string customer_id, string customer_reference)
        {
            var response = new BaseResponse();
            try
            {
                var leadRepository = new LeadRepository();
                var currentLead = leadRepository.Query().FirstOrDefault(x => x.IntakeToken == customer_reference);


                //// Create Chargify Suscription
                SubscriptionService chargifyService = new SubscriptionService();

                int serviceSuscriptionId = chargifyService.AddTrialServiceSubscription(subscription_id, customer_id, currentLead.idLead);

                string urlToValidateUser = ConfigurationManager.AppSettings["SmartSocialWeb"];

                //Create new System User
                UserService _userService = new UserService();
                _userService.TrialCreateUser(currentLead.Email, 1, urlToValidateUser, int.Parse(subscription_id), int.Parse(customer_id), serviceSuscriptionId);

                // Send Lead Confirmation
                string token = WebSecurity.GeneratePasswordResetToken(currentLead.Email);
                SendTrialIntakeConfirmationEmail(currentLead.Email, currentLead.FirstName, urlToValidateUser + token);

                response.Acknowledgment = true;
                response.Message = "Success";


            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Updating a Lead: " + ex.Message;
            }
            return response;
        }


        public LeadResponse GetLeadByToken(string token)
        {
            var response = new LeadResponse();
            try
            {
                var leadRepository = new LeadRepository();
                var currentLead = leadRepository.Query().FirstOrDefault(x => x.IntakeToken == token);
                if (currentLead != null)
                {
                    response.Lead = new LeadDto()
                    {
                        idLead = currentLead.idLead,
                        FirstName = currentLead.FirstName,
                        LastName = currentLead.LastName,
                        CountryCode = currentLead.CountryCode,
                        PhoneNumber = currentLead.PhoneNumber,
                        Email = currentLead.Email
                    };
                    response.Acknowledgment = true;
                    response.Message = "Success";
                }
                else {
                    response.Acknowledgment = false;
                    response.Message = "Unable to Find a lead with that token";
                }
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Updating a Lead: " + ex.Message;
            }
            return response;
        }

        public LeadResponse ChargifySuscription(string subscription_id, string customer_id)
        {
            var response = new LeadResponse();
            SubscriptionService chargifyService = new SubscriptionService();
            ISubscription subscription = chargifyService.GetSubscription(int.Parse(subscription_id));
            ICustomer customerResult = subscription.Customer;

            try
            {
                var leadRepository = new LeadRepository();
                var newLead = new Lead()
                {
                    Aliases = "",
                    CountryCode = "USA(+1)",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    Email = customerResult.Email,
                    FirstName = customerResult.FirstName,
                    LastName = customerResult.LastName,
                    Keywords = "",
                    PhoneNumber = customerResult.Phone,
                    MarketSegments = "",
                    OtherMarketSegments = "",
                    IntakeEmailSentDate = DateTime.Now,
                    IntakeToken = subscription_id,
                    IntakeUrl = "",
                    IsActive = true,
                    IsIntakeAnswered = false
                };
                leadRepository.Add(newLead);
                leadRepository.SaveChanges();

                var currentLead = newLead;
                if (currentLead != null)
                {
                    response.Lead = new LeadDto()
                    {
                        idLead = currentLead.idLead,
                        FirstName = currentLead.FirstName,
                        LastName = currentLead.LastName,
                        CountryCode = currentLead.CountryCode,
                        PhoneNumber = currentLead.PhoneNumber,
                        Email = currentLead.Email
                    };
                    response.Acknowledgment = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Acknowledgment = false;
                    response.Message = "Unable to Find a lead with that token";
                }
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = "Error Updating a Lead: " + ex.Message;
            }
            return response;
        }


        public void SendLeadConfirmationEmail(string email, string firstName, string intakeUrl) {
            try {

                string html = Resource.LeadConfirmation.ToString(); //File.ReadAllText("~/HtmlEmails/LeadConfirmation.html");
                var withname = html.Replace("<name>", firstName);
                var finalHtml = withname.Replace("<intakeUrl>", intakeUrl);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("smartsocial.no-reply@outlook.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Smart Social - Free Trial Additional Information";
                message.IsBodyHtml = true;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.Body = finalHtml;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                EmailUtility.SendEmail(message);
            }catch(Exception ex){
                Console.Write(ex.Message);
            }
        }

        public void SendIntakeConfirmationEmail(string email, string firstName)
        {
            try
            {
                string html = Resource.IntakeConfirmation.ToString(); 
                var finalHtml = html.Replace("<name>", firstName);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("smartsocial.no-reply@outlook.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Smart Social - We're preparing your report";
                message.IsBodyHtml = true;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.Body = finalHtml;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                EmailUtility.SendEmail(message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void SendTrialIntakeConfirmationEmail(string email, string firstName, string urlToValidateUser)
        {
            try
            {
                string html = Resource.IntakeConfirmation.ToString();
                var finalHtml = html.Replace("<name>", firstName);
                var finalHtml2 = finalHtml.Replace("<invitationUrl>", urlToValidateUser);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("smartsocial.no-reply@outlook.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Smart Social - We're preparing your report";
                message.IsBodyHtml = true;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.Body = finalHtml2;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                EmailUtility.SendEmail(message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

    }
}
