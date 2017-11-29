using System;
using System.Web.UI;

namespace SmartSocial.Web.testing
{
    public partial class LoadMoreTesting : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
 
        protected void btnLoadMore_Click(object sender, EventArgs e)
        {
            RadListView1.PageSize+= 5;
            RadListView1.DataBind();
            
        }
    }
}