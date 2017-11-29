using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ChargifyNET;
using ChargifyNET.Configuration;
using SmartSocialServices.DataTransferObjects;
using SmartSocialServices.Objects;
using SmartSocial.Data.V2;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Repositories;
using System.Net;

namespace SmartSocialServices.Services
{
    public class SubscriptionService
    {
        private static ChargifyConnect chargify;

        private ChargifyConnect Chargify
        {
            get
            {
                if (chargify == null)
                {
                    ChargifyAccountRetrieverSection config = ConfigurationManager.GetSection("chargify") as ChargifyAccountRetrieverSection;
                    ChargifyAccountElement accountInfo = config.GetDefaultOrFirst();
                     
                    chargify = new ChargifyConnect();
                    chargify.apiKey = accountInfo.ApiKey;
                    chargify.Password = accountInfo.ApiPassword;
                    chargify.URL = accountInfo.Site;
                    chargify.SharedKey = accountInfo.SharedKey;
                    chargify.UseJSON = config.UseJSON;
                    chargify.ProtocolType = SecurityProtocolType.Tls12;
                }

                return chargify;
            }
        }

        public ISubscription SubscribeChargifyTrial(Lead leadDto)
        {
            string subscriptionType = "trial";

            //// This determines if the _CreditCard partial gets rendered
            IProduct productResult = (from a in Chargify.GetProductList().Values
                                      where a.Handle == subscriptionType
                                      select a).SingleOrDefault();

            if (productResult == null)
            {
                return null;
            }

            ICustomer customerResult = (from c in Chargify.GetCustomerList().Values
                                        where c.Email == leadDto.Email
                                        select c).FirstOrDefault();

            if (customerResult == null)
            {

                // Now that the user is created, attempt to create the corresponding subscription
                CustomerAttributes cInfo = new CustomerAttributes();
                cInfo.FirstName = leadDto.FirstName;
                cInfo.LastName = leadDto.LastName;
                cInfo.Email = leadDto.Email;
                cInfo.SystemID = Guid.NewGuid().ToString();///Convert.ToInt32(Session["userId"]).ToString();
                ISubscription newSubscription = Chargify.CreateSubscription(subscriptionType, cInfo);
                return newSubscription;//newSubscription.Customer.ChargifyID.ToString() + "," + newSubscription.SubscriptionID.ToString();
            }
            else
            {
                // Will be used to test suscription type
                //ISubscription subscriptionResult = (from s in Chargify.GetSubscriptionList().Values
                //                                    where s.Customer.ChargifyID == customerResult.ChargifyID
                //                            select s).FirstOrDefault();

                ISubscription newSubscription = Chargify.CreateSubscription(subscriptionType, customerResult.ChargifyID);


                return newSubscription;//customerResult.ChargifyID.ToString() + "," + newSubscription.SubscriptionID.ToString(); ;
            }
        }

        public int AddTrialServiceSubscription(string ChargifyID, string CustomerId, int idLead)
        {
            var response = new BaseResponse();
            try
            {
                var serviceSubscriptionRepository = new ServiceSubscriptionRepository();
                var serviceSubscription = new ServiceSubscription()
                {
                    SubscriptionName = "TrialSuscription",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1),
                    IsActive = true,
                    idChargifyCustomer = CustomerId,
                    idChargifySuscription = ChargifyID,
                    idLead = idLead
                };
                serviceSubscriptionRepository.Add(serviceSubscription);
                serviceSubscriptionRepository.SaveChanges();
                return serviceSubscription.idServiceSubscription;
            }
            catch (Exception ex)
            {
                response.Acknowledgment = false;
                response.Message = ex.Message;
            }
            return 0;
        }

        public string GetSubscriptionProductName(int subscriptionID)
        {
            //// This determines if the _CreditCard partial gets rendered
            ISubscription subscriptionResult = (from s in Chargify.GetSubscriptionList().Values
                                                where s.SubscriptionID == subscriptionID
                                        select s).FirstOrDefault();

            if (subscriptionResult == null)
            {
                return "";
            }
            return subscriptionResult.Product.Name;
        }

        public ISubscription GetSubscription(int subscriptionID)
        {
            //// This determines if the _CreditCard partial gets rendered
            ISubscription subscriptionResult = (from s in Chargify.GetSubscriptionList().Values
                                                where s.SubscriptionID == subscriptionID
                                                select s).FirstOrDefault();
            return subscriptionResult;
        }

        public ICustomer GetCustomer(int chargifyID)
        {
            //// This determines if the _CreditCard partial gets rendered
            ICustomer customerResult = (from s in Chargify.GetCustomerList().Values
                                        where s.ChargifyID == chargifyID
                                                select s).FirstOrDefault();

            return customerResult;
        }

        public string GetBillingPortal(int chargifyId)
        {
            string url = "";
            IBillingManagementInfo billingManagementInfo = Chargify.GetManagementLink(chargifyId);
            if (billingManagementInfo!=null)
                url = billingManagementInfo.URL;
  
            return url;
        }
        public DateTime getTrialEnding(int userId) {
            try
            {
                var users = new UserProfileRepository();
                var subcriptions = new ServiceSubscriptionRepository();
                var customerId = users.Query().FirstOrDefault(x => x.UserId == userId).ChargifyCustomerId ?? 0;
                var subscriptionId = Convert.ToInt32(subcriptions.Query().FirstOrDefault(x => x.idChargifyCustomer == customerId.ToString()).idChargifySuscription);
                var chargifySubscription = GetSubscription(subscriptionId);
                if (chargifySubscription.State.ToString().ToLower() == "trialing" || chargifySubscription.State.ToString().ToLower() == "trial_ended")
                {
                    return chargifySubscription.TrialEndedAt;
                }
                return DateTime.Now.AddMonths(-1);
            }
            catch (Exception ex)
            {
                return DateTime.Now.AddMonths(-1);
            }
               
        }

        //public bool Subscribe(string id, LocalSubscriptionViewModel model)
        //{
        //    //  if (ModelState.IsValid)
        //    //{
        //    // Attempt to register the user
        //    //MembershipCreateStatus createStatus;
        //    //MembershipUser user = MembershipService.CreateUser(model.Username, model.Password, model.Email, model.Question, model.Answer, out createStatus);

        //    //if (createStatus == MembershipCreateStatus.Success)
        //    if (true)
        //    {
        //        //if (!RoleService.RoleExists("user"))
        //        //{
        //        //    RoleService.CreateRole("user");
        //        //}
        //        //RoleService.AddUsersToRoles(new string[] { user.UserName }, new string[] { "User" });

        //        // Now that the user is created, attempt to create the corresponding subscription
        //        CustomerAttributes cInfo = new CustomerAttributes();
        //        cInfo.FirstName = model.FirstName;
        //        cInfo.LastName = model.LastName;
        //        cInfo.Email = model.Email;
        //        cInfo.SystemID = Guid.NewGuid().ToString();///Convert.ToInt32(Session["userId"]).ToString();

        //        if (Convert.ToBoolean(Session["RequireCreditCard"]))
        //        {
        //            CreditCardAttributes ccAttr = new CreditCardAttributes();
        //            ccAttr.FullNumber = model.CardNumber.Trim();
        //            ccAttr.CVV = model.CVV;
        //            ccAttr.ExpirationMonth = model.ExpMonth;
        //            ccAttr.ExpirationYear = model.ExpYear;

        //            ccAttr.BillingAddress = model.Address;
        //            ccAttr.BillingCity = model.City;
        //            ccAttr.BillingZip = model.PostalCode;
        //            ccAttr.BillingState = model.Province;
        //            ccAttr.BillingCountry = "CA";

        //            ISubscription newSubscription = Chargify.CreateSubscription(id, cInfo, ccAttr);
        //        }
        //        else
        //        {
        //            ISubscription newSubscription = Chargify.CreateSubscription(id, cInfo);
        //        }

        //        try
        //        {

        //            //FormsService.SignIn(model.Username, false /* createPersistentCookie */);
        //            return RedirectToAction("Index", "Chargify");
        //        }
        //        catch (ChargifyException ex)
        //        {
        //            if (ex.ErrorMessages.Count > 0)
        //            {
        //                ModelState.AddModelError("", ex.ErrorMessages.FirstOrDefault().Message);
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", ex.ToString());
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
        //    }

        //    return true;
        //}
    }
}
