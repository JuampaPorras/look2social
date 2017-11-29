using System;
using System.Web.UI;

namespace SmartSocial.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Account/Login.aspx");
            }
        }
    }
}