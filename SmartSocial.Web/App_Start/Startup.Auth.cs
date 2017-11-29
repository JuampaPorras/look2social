using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.MicrosoftAccount;
using Microsoft.Owin.Security.Twitter;
using Owin;
using SmartSocial.Web.Models;

namespace SmartSocial.Web
{
    public partial class Startup {

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301883
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            var msAuthOptions = new MicrosoftAccountAuthenticationOptions
            {
                ClientId = "000000004814B875",
                ClientSecret = "lngSfDXmZcYlDclRcKfzas6hpk3LOipE",
                CallbackPath = new PathString("/Account/ExternalLoginCallback"),
            };

            app.UseMicrosoftAccountAuthentication(msAuthOptions);

            var twAuthOptions = new TwitterAuthenticationOptions
            {
                ConsumerKey = "WzrkEmxx51YrWtwy2gIeJ5Aiv",
                ConsumerSecret = "S9IBpCoLFV6DKXhsUiM2wiedGUvSa6dltAa2PSVTxrOAWtWfYD",
            };

            app.UseTwitterAuthentication(twAuthOptions);

            var fbAuthOptions = new FacebookAuthenticationOptions
            {
                AppId = "808310982550906",
                AppSecret = "72b007177792a854f6f76188845046aa",
            };

            app.UseFacebookAuthentication(fbAuthOptions);

            var goAuthOptions = new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "300609129400-v1p6srt3i10fuvi3escsuo3a2428jbpv.apps.googleusercontent.com",
                ClientSecret = "g_u48liMarAn-PwhhaMdt4NM",
            };

            app.UseGoogleAuthentication(goAuthOptions);
        }
    }
}