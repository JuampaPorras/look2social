using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using SmartSocial.Data;
using Telerik.Web.UI;

namespace SmartSocial.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LeftPane.Visible = Context.User.Identity.IsAuthenticated;
            FillLeftPane();

        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }

        protected void FillLeftPane()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                //CompanyHomeLink.HRef = "~/pages/Home";
                //Load Left Split data (ServicesSubscriptions, ServiceDeliveries and Reports)
                CompanyHomeLink.HRef = "~/pages/Home";
                using (SmartSocialdbDataContext myDB = new SmartSocialdbDataContext())
                {
                    var mySS = myDB.SpGetUserSubscriptions(Context.User.Identity.GetUserId());
                    var user = myDB.AspNetUsers.FirstOrDefault(x => x.Id == Context.User.Identity.GetUserId());
                    var companyImagePath = "~/images/CompanyImages/" + user.Company1.IdCompany + "/" + user.Company1.LogoFileName;
                    CompanyImage.Src = companyImagePath;
                    CompanyName.InnerText = user.Company1.CompanyName;
                    //Create a Sliding pane for each Subscription
                    RadPanelBar aPanelBar = new RadPanelBar();
                    aPanelBar.ItemClick += ReportClick;
                    aPanelBar.OnClientItemClicking = "PanelParentClicking";
                    aPanelBar.CssClass = "hidden-sm hidden-xs panel-margin";
                    aPanelBar.Width = Unit.Percentage(100);
                    aPanelBar.Skin = "Glow";

                    RadMenu suscriptionsMenu = new RadMenu();
                    suscriptionsMenu.Flow = ItemFlow.Vertical;
                    suscriptionsMenu.CssClass = "hidden-md hidden-lg hidden-xs";
                    suscriptionsMenu.Width = Unit.Percentage(100);
                    suscriptionsMenu.Skin = "Glow";


                    var menuExtraSmall = "<ul class='dropdown-menu multi-level dropdown-menu-left' role='menu' aria-labelledby='dropdownMenu'>";
                    foreach (var aSubscription in mySS)
                    {
                        var mySD = myDB.SpGetSubscriptionDeliveries(aSubscription.IdServiceSubscription);

                        RadPanelItem grandPanelItem = new RadPanelItem();
                        grandPanelItem.Text = "<div>&nbsp;&nbsp;<i class='l-ecommerce-graph1'></i>  " + aSubscription.SubscriptionName + "</div>";
                        grandPanelItem.Value = "";
                        grandPanelItem.Width = Unit.Percentage(100);
                        grandPanelItem.ToolTip = aSubscription.SubscriptionName;
                        grandPanelItem.Expanded = true;

                        RadMenuItem suscriptionItem = new RadMenuItem();
                        suscriptionItem.Text = "<i class='l-ecommerce-graph1'></i>";
                        suscriptionItem.ToolTip = aSubscription.SubscriptionName;

                        menuExtraSmall += "<li class='dropdown-submenu'><a tabindex='-1' href='#'><i class='l-ecommerce-graph1'></i>&nbsp;&nbsp;" + aSubscription.SubscriptionName + "</a>" +
                            "<ul class='dropdown-menu'>";

                        //Create a Panel Item under the current Subscription for each Delivery
                        foreach (var aDelivery in mySD)
                        {
                            RadPanelItem aPanelItem = new RadPanelItem();
                            aPanelItem.Text = "<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class='l-software-layout-header-3columns'></i> &nbsp;" + aDelivery.DateDelivered.Value.ToString("MMM, yyyy") + "</div>";
                            aPanelItem.Value = "";
                            aPanelItem.Width = Unit.Percentage(100);
                            aPanelItem.ToolTip = aDelivery.DateDelivered.Value.ToLongDateString();
                            aPanelItem.Expanded = true;

                            RadMenuItem deliveryItem = new RadMenuItem();
                            deliveryItem.Text = aDelivery.DateDelivered.Value.ToString("MMM, yyyy");

                            menuExtraSmall += "<li class='dropdown-submenu'>" +
                                "<li class='dropdown-submenu'>" +
                                    "<a href='#'>" + aDelivery.DateDelivered.Value.ToString("MMM, yyyy") + "</a>" +
                                    "<ul class='dropdown-menu'>";

                            var mySR = myDB.SpGetDeliveryReports(aDelivery.IdServiceDelivery);

                            //Create a Panel sub item for the current Delivery for each Report
                            foreach (var aReport in mySR)
                            {
                                RadPanelItem aPanelSubItem = new RadPanelItem();
                                aPanelSubItem.Text = aReport.ReportName;
                                aPanelSubItem.Value = aReport.IdSmartReport.ToString();
                                aPanelSubItem.Width = Unit.Percentage(100);
                                aPanelItem.Items.Add(aPanelSubItem);

                                RadMenuItem reportItem = new RadMenuItem();
                                reportItem.Text = aReport.ReportName;
                                reportItem.NavigateUrl = "pages/main.aspx?idSmartReport=" + aReport.IdSmartReport.ToString();
                                deliveryItem.Items.Add(reportItem);

                                menuExtraSmall += "<li><a href='http://" + HttpContext.Current.Request.Url.Authority + "/pages/main.aspx?idSmartReport=" + aReport.IdSmartReport.ToString() + "' aria-expanded='true' role='menuitem' tabindex='-1'>" + aReport.ReportName + "</a></li>";
                            }
                            menuExtraSmall += "</ul></li>";
                            suscriptionItem.Items.Add(deliveryItem);
                            grandPanelItem.Items.Add(aPanelItem);
                        }
                        menuExtraSmall += "</ul></li>";
                        aPanelBar.Items.Add(grandPanelItem);
                        suscriptionsMenu.Items.Add(suscriptionItem);
                        //SuscriptionsContainer);
                    }
                    menuExtraSmall += "</ul>";
                    MenuXs.Controls.Add(new LiteralControl(menuExtraSmall));
                    SuscriptionsContainer.Controls.Add(aPanelBar);
                    SuscriptionsContainer.Controls.Add(suscriptionsMenu);

                }

            }
            else
            {
                SuscriptionsContainer.Attributes.Add("class", "hidden");
                MainDiv.Attributes.Add("class", "col-lg-12 col-md-12 col-sm-12 col-xs-12");
                Toogler.Attributes.Add("class", "hidden");
            }
        }


        protected void ReportClick(object sender, RadPanelBarEventArgs e)
        {
            RadPanelItem ItemClicked = e.Item;
            if (e.Item.Value != "")
            {
                Response.Redirect("~/pages/main.aspx?idSmartReport=" + e.Item.Value);
            }
        }

        protected void OnItemClick(object sender, EventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
            Response.Redirect("~/");

        }
    }

}