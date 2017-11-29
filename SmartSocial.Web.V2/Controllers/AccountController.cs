using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using SmartSocial.web.V2.Filters;
using SmartSocial.web.V2.Models;
using SmartSocialServices.Messaging.Response;
using SmartSocialServices.Services;


namespace SmartSocial.web.V2.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        UserService _userService = new UserService();
        //
        // GET: /Account/Login

        [AllowAnonymous]
        [Authorize]
        public ActionResult Login(string returnUrl)
        {
            HttpCookie existingCookie = Request.Cookies[".ASPXAUTH"];
            if (existingCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(existingCookie.Value);

                if (!ticket.Expired)
                {
                    LoginModel model = new LoginModel();
                    model.UserName = ticket.Name;
                    model.RememberMe = true;
                    ViewBag.RememberMeSet = false;
                    Session["userId"] = WebSecurity.GetUserId(model.UserName);

                    var userId = WebSecurity.GetUserId(model.UserName);
                    string[] rolesArray = Roles.GetRolesForUser();
                    bool isWorking = WebSecurity.CurrentUserId != -1;

                    //Session["subScriptionId"] = _userService.GetUserSubscription(WebSecurity.CurrentUserId)[0].idSubscription;
                    var userInformation = _userService.GetUserInformation(userId);
                    if (userInformation.Acknowledgment == true)
                    {
                        if (userInformation.userLastReportId != null && userInformation.userLastReportId > 0)
                        {
                            var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/MainReport/" + userInformation.userLastReportId;
                            return Redirect(url);
                        }
                        else
                        {
                            var userInfo = _userService.GetMainPageInfo(userId, rolesArray, model.UserName);
                            if (userInfo.userSubscriptionsReponse.UserSubscriptionsObjects.Count > 0)
                            {

                                if (userInfo.userSubscriptionsReponse.UserSubscriptionsObjects[0].ServiceSubscription.ServiceDeliveries.Count > 0)
                                {
                                    var firstReport = userInfo.userSubscriptionsReponse.UserSubscriptionsObjects[0].ServiceSubscription.ServiceDeliveries.FirstOrDefault().SmartReports.FirstOrDefault().idSmartReport;
                                    var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/MainReport/" + firstReport;
                                    return Redirect(url);
                                }
                                else
                                {
                                    var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/NoReport";
                                    return Redirect(url);
                                }
                            }
                            else
                            {
                                var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/NoReport";
                                return Redirect(url);
                            }
                        }
                    }
                }
                else 
                {
                    return View();
                }
            }
            else
            {
                ViewBag.RememberMeSet = false;
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Invite()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ChangePassword(string oldPassword, string newPassword)
        {
            // ChangePassword will throw an exception rather than return false in certain failure scenarios.
            var response = new BaseResponse();

            try
            {
                response.Acknowledgment = true;
                response.Acknowledgment = WebSecurity.ChangePassword((string)Session["userName"], oldPassword, newPassword);
            }
            catch (Exception)
            {
                response.Acknowledgment = false;
            }
            if (response.Acknowledgment)
            {
                response.Message = "Password changed successfully";
            }
            else
            {
                response.Message = "The current password is incorrect or the new password is invalid.";
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Invite(ConfirmModel model)
        {

            if (ModelState.IsValid)
            {
                var user = _userService.GetUserByResetToken(model.Token);
                //generate password token
                var token = WebSecurity.GeneratePasswordResetToken(user.UserName,5);
                var result = WebSecurity.ResetPassword(token, model.NewPassword);
                if (result != null)
                {
                    WebSecurity.Login(user.UserName, model.NewPassword, persistCookie: true);
                    var userId = WebSecurity.GetUserId(user.UserName);
                    Session["userName"] = user.UserName;
                    Session["userId"] = user.UserId;

                    string[] rolesArray = Roles.GetRolesForUser();
                    

                    var userInformation = _userService.GetUserInformation(userId);
                    if (userInformation.Acknowledgment == true)
                    {
                        if (userInformation.userLastReportId != null && userInformation.userLastReportId > 0)
                        {
                            var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/MainReport/" + userInformation.userLastReportId;
                            return Redirect(url);
                        }
                        else
                        {
                            var userInfo = _userService.GetMainPageInfo(WebSecurity.CurrentUserId, rolesArray, WebSecurity.CurrentUserName);
                            if (userInfo.userSubscriptionsReponse.UserSubscriptionsObjects.Count > 0)
                            {

                                if (userInfo.userSubscriptionsReponse.UserSubscriptionsObjects[0].ServiceSubscription.ServiceDeliveries.Count > 0)
                                {
                                    var firstReport = userInfo.userSubscriptionsReponse.UserSubscriptionsObjects[0].ServiceSubscription.ServiceDeliveries.FirstOrDefault().SmartReports.FirstOrDefault().idSmartReport;
                                    var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/MainReport/" + firstReport;
                                    return Redirect(url);
                                }
                                else
                                {
                                    var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/NoReport";
                                    return Redirect(url);
                                }
                            }
                            else
                            {
                                var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/NoReport";
                                return Redirect(url);
                            }

                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User Information unreacheable.");
                        return View(model);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Token");
                    return View(model);
                }

            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
        .SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage));
    

                ModelState.AddModelError("",  message);
                return View(model);
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult CreateAccount(string email, int idCompany)
        {
            var urlToValidateUser = Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~") + "Account/Invite?token=";
            return Json(_userService.AdminCreateUser(email, idCompany, urlToValidateUser), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult AddRoleUserSubscription(int subscriptionId, int idRole)
        {

            return Json(_userService.AddRoleUserSubscription(WebSecurity.CurrentUserId, subscriptionId, idRole), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult UpdateRoleUserSubscription(int subscriptionId, int idRole)
        {

            return Json(_userService.UpdateRoleUserSubscription(WebSecurity.CurrentUserId, subscriptionId, idRole), JsonRequestBehavior.AllowGet);
        }



        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                //var hola = WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe);
                Session["userName"] = model.UserName;
                Session["userId"] = WebSecurity.GetUserId(model.UserName);
            
                var userId = WebSecurity.GetUserId(model.UserName);
                string[] rolesArray = Roles.GetRolesForUser();
                bool isWorking = WebSecurity.CurrentUserId != -1;
                
                //Session["subScriptionId"] = _userService.GetUserSubscription(WebSecurity.CurrentUserId)[0].idSubscription;
                var userInformation = _userService.GetUserInformation(userId);
                if (userInformation.Acknowledgment == true)
                {
                    if (userInformation.userLastReportId != null && userInformation.userLastReportId > 0)
                    {
                        var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/MainReport/" + userInformation.userLastReportId;
                        return Redirect(url);
                    }
                    else
                    {
                        var userInfo = _userService.GetMainPageInfo(userId, rolesArray, model.UserName);
                        if (userInfo.userSubscriptionsReponse.UserSubscriptionsObjects.Count > 0)
                        {

                            if (userInfo.userSubscriptionsReponse.UserSubscriptionsObjects[0].ServiceSubscription.ServiceDeliveries.Count > 0)
                            {
                                var firstReport = userInfo.userSubscriptionsReponse.UserSubscriptionsObjects[0].ServiceSubscription.ServiceDeliveries.FirstOrDefault().SmartReports.FirstOrDefault().idSmartReport;
                                var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/MainReport/" + firstReport;
                                return Redirect(url);
                            }
                            else
                            {
                                var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/NoReport";
                                return Redirect(url);
                            }
                        }
                        else
                        {
                            var url = ConfigurationManager.AppSettings["SmartSocialWeb"] + "/Home/Main#/NoReport";
                            return Redirect(url);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", userInformation.Message);
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);

        }

        //
        // POST: /Account/LogOff

        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            // Drop all the information held in the session
            Session.Clear();
            Session.Abandon();

            FormsAuthentication.Initialize();
            string strRole = String.Empty;
            FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1, "", DateTime.Now, DateTime.Now.AddMinutes(-30), false, strRole, FormsAuthentication.FormsCookiePath);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(fat)));

            //// clear authentication cookie
            //HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            //cookie1.Expires = DateTime.Now.AddYears(-1);
            //Response.Cookies.Add(cookie1);

            //// clear session cookie
            //HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            //cookie2.Expires = DateTime.Now.AddYears(-1);
            //Response.Cookies.Add(cookie2);

            return RedirectToAction("Login");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (UsersContext db = new UsersContext())
                {
                    UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                    // Check if user already exists
                    if (user == null)
                    {
                        // Insert name into the profile table
                        db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                        OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
                    }
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ForgotPassword(string userEmail)
        {
            var urlToForApplication = Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~");
            var response = _userService.ForgotPassword(userEmail, urlToForApplication);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
