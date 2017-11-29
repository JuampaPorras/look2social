using System;
using System.Web.UI;

namespace SmartSocial.Web.testing
{
    public partial class WebServiceCallTest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = new WebServiceTest().HelloWorld();
        }
    }
}