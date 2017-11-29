using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using SmartSocial.Data;
using Telerik.Web.UI;

namespace SmartSocial.Web.masterpages
{
    public partial class Main : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Context.User.Identity.IsAuthenticated)
                { 
                    SlidingZone1.Items.Clear();

                    //Load Left Split data (ServicesSubscriptions, ServiceDeliveries and Reports)
                    using (SmartSocialdbDataContext myDB = new SmartSocialdbDataContext())    
                    {
                       
                        var mySS = myDB.SpGetUserSubscriptions(Context.User.Identity.GetUserId());

                        //Create a Sliding pane for each Subscription
                        foreach (var aSubscription in mySS) 
                        {
                            RadSlidingPane leftSlidingPane1 = new RadSlidingPane();
                            leftSlidingPane1.Title = aSubscription.SubscriptionName;
                            leftSlidingPane1.Width = new Unit(200);
                            leftSlidingPane1.MinWidth = 130;

                            RadPanelBar aPanelBar = new RadPanelBar();
                            aPanelBar.Width = Unit.Percentage(100);
                            var mySD = myDB.SpGetSubscriptionDeliveries(aSubscription.IdServiceSubscription);

                            //Create a Panel Item under the current Subscription for each Delivery
                            foreach (var aDelivery in mySD)
                            {
                                RadPanelItem aPanelItem = new RadPanelItem();
                                aPanelItem.Text = aDelivery.DateDelivered.Value.ToString("MMM d, yyyy");
                                aPanelItem.Value = aDelivery.IdServiceDelivery.ToString();
                                aPanelItem.ToolTip = aDelivery.DateDelivered.Value.ToLongDateString();
                                aPanelItem.ImageUrl = "http://icons.iconarchive.com/icons/oxygen-icons.org/oxygen/24/Actions-view-calendar-icon.png";

                                var mySR = myDB.SpGetDeliveryReports(aDelivery.IdServiceDelivery);

                                //Create a Panel sub item for the current Delivery for each Report
                                foreach (var aReport in mySR)
                                {
                                    RadPanelItem aPanelSubItem = new RadPanelItem();
                                    aPanelSubItem.Text = aReport.ReportName;
                                    aPanelSubItem.Value = aReport.IdSmartReport.ToString();
                                    aPanelSubItem.ImageUrl = "http://icons.iconarchive.com/icons/iconshock/real-vista-text/16/chart-icon.png";

                                    aPanelItem.Items.Add(aPanelSubItem);
                                }
                                

                                aPanelBar.Items.Add(aPanelItem);
                            }

                            leftSlidingPane1.Controls.Add(aPanelBar);
                            SlidingZone1.Items.Add(leftSlidingPane1);
                            
                        }


                    }
                    
                }
            }
            
        }
        public void LoadSubscriptionsToUI()
        {
            

        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }

        protected void OnItemClick(object sender, RadMenuEventArgs e)
        {
            if (e.Item.Value == "AKLogout")
            {
                Context.GetOwinContext().Authentication.SignOut();
                Response.Redirect("~/");
            }
        }
        public bool LeftPaneAndSplitbarVisible
        {
            get
            {
                return LeftPane.Visible;
            }
            set
            {
                LeftPane.Visible = value;
                Radsplitbar1.Visible = value;
            }
        }

    }
}