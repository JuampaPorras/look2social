using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SmartSocial.Data;

namespace SmartSocial.Web.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                var user = manager.FindByEmail(txtEmail.Text);
                /*if (!manager.IsEmailConfirmed(user.Id))
                {
                    Response.Redirect("/Account/NotConfirmed");
                }*/

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(txtEmail.Text, txtPassword.Text, chkRememberMe.Checked, shouldLockout: true);

                switch (result)
                {
                    case SignInStatus.Success:
                        using (SmartSocialdbDataContext myDb = new SmartSocialdbDataContext()) 
                        {
                            var reportId = myDb.AspNetUsers.FirstOrDefault(x => x.Email == txtEmail.Text).IdLastReport;
                            if (reportId!=null)
                            {
                                Response.Redirect("~/pages/main?idSmartReport="+reportId);
                            }
                            else
                            {
                                Response.Redirect("~/pages/Home");
                            }
                        }
                        //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        chkRememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        RadWindowManager1.RadAlert("Invalid login attempt.",200,50,"Login failure","");
                        break;
                }
            }
        }
    }
}