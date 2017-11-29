using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CodeSmith.Data.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using SmartSocial.Data;
using SmartSocial.Web.Models;
using Telerik.Web.UI;
using Telerik.Web.UI.HtmlChart;

namespace SmartSocial.Web.pages
{
    public partial class main : Page
    {
        public static int currentConversation = 0;
        public static string Charts = "";
        public static List<WordCloudModel> wordsInClouds = new List<WordCloudModel>();
        public static string UserId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                using (SmartSocialdbDataContext myDb = new SmartSocialdbDataContext())
                {
                    var smartReportId = Convert.ToInt32(Request.QueryString["idSmartReport"]);
                    if (smartReportId != 0)
                    {
                        var userDb = myDb.AspNetUsers.FirstOrDefault(x => x.Email == Context.User.Identity.Name);
                        var userId = userDb.Id;
                        Session["UserId"] = userDb.Id;
                        UserId = userDb.Id;
                        if (User.IsInRole("Admin"))
                        {
                            IsAdmin.Value = "true";
                        }
                        var suscriptionsByUser = myDb.SpGetUserSubscriptions(userId).ToList();
                        SmartReportID.Value = smartReportId.ToString();
                        var smartReport = myDb.SpGetReportDataXID(smartReportId).First();
                        if (suscriptionsByUser.Any(x => x.IdServiceSubscription == smartReport.IdServiceSubscription))
                        {
                            userDb.IdLastReport = smartReportId;
                            myDb.SubmitChanges();
                            //((SmartSocial.Web.testing.SiteTesting)this.Master).ExportPDFReportVisible = true;
                            KPIInsigthsTxt.Controls.Add(new LiteralControl(smartReport.Insights));
                            if (smartReport.DateCreated != null)
                            {
                                AnalysisPeriod.Text = smartReport.DateCreated.Value.ToString("MMM, yyyy");
                            }
                            else
                            {
                                AnalysisPeriod.Text = "";
                            }
                            //SubscriptionName.Text = smartReport.SubscriptionName;
                            ReportName.Text = smartReport.ReportName;
                            var smartReportCharts = myDb.SpGetChartsByReportXID(smartReportId);
                            Charts = "";
                            foreach (var smartChart in smartReportCharts.OrderBy(x => x.ChartOrder))
                            {
                                switch (smartChart.ChartTypeName)
                                {
                                    case "Columns":
                                        ColumnCharts(smartChart.IdSmartchart, myDb, smartChart.ChartName,
                                            smartChart.AxisSeriesTitle, smartChart.AxisValuesTitle,
                                            smartChart.CssClasses, smartChart.HtmlStyles);
                                        Charts += smartChart.ChartName.Replace(" ", "") + "|";
                                        break;
                                    case "Linear":
                                        LineCharts(smartChart.IdSmartchart, myDb, smartChart.ChartName,
                                            smartChart.AxisValuesTitle, smartChart.CssClasses, smartChart.HtmlStyles);
                                        Charts += smartChart.ChartName.Replace(" ", "") + "|";
                                        break;
                                    case "Pie":
                                        PieCharts(smartChart.IdSmartchart, myDb, smartChart.ChartName,
                                            smartChart.CssClasses, smartChart.HtmlStyles);
                                        Charts += smartChart.ChartName.Replace(" ", "") + "|";
                                        break;
                                    case "StackedColumns":
                                        StackedColumnCharts(smartChart.IdSmartchart, myDb, smartChart.ChartName,
                                            smartChart.AxisValuesTitle, smartChart.CssClasses, smartChart.HtmlStyles);
                                        Charts += smartChart.ChartName.Replace(" ", "") + "|";
                                        break;
                                    case "TreeMap":
                                        //TreeMapString(smartChart.IdSmartchart, parentRow, myDb, smartChart.ChartName);
                                        break;
                                    case "WordCloud":
                                        WordCloudCharts(smartChart.IdSmartchart, myDb, smartChart.ChartName,
                                            smartChart.CssClasses, smartChart.HtmlStyles);
                                        break;
                                    case "MostProlificUsers":
                                        AudienceCharts(smartChart.IdSmartchart, myDb, smartChart.ChartName,
                                            smartChart.CssClasses, smartChart.HtmlStyles);
                                        break;
                                    case "LocationAnalysis":
                                        LocationCharts(smartChart.IdSmartchart, myDb, smartChart.ChartName,
                                            smartChart.CssClasses, smartChart.HtmlStyles);
                                        break;
                                    case "ReachSummary":
                                        SummaryReach(smartChart.IdSmartchart, myDb, smartChart.ChartName,
                                            smartChart.CssClasses, smartChart.HtmlStyles);
                                        break;
                                    case "MentionSummary":
                                        SummaryMentions(smartChart.IdSmartchart, myDb, smartChart.ChartName,
                                            smartChart.CssClasses, smartChart.HtmlStyles);
                                        break;
                                    case "BestDaySummary":
                                        SummaryBestDay(smartChart.IdSmartchart, myDb, smartChart.ChartName,
                                            smartChart.CssClasses, smartChart.HtmlStyles);
                                        break;
                                    case "TopUserSummary":
                                        SummaryTopUser(smartChart.IdSmartchart, myDb, smartChart.ChartName,
                                            smartChart.CssClasses, smartChart.HtmlStyles);
                                        break;
                                }
                            }
                            Charts = Charts.Substring(0, Charts.Length - 1);
                        }
                    }
                }
            }


        }

        protected void SummaryReach(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName, string cssClasses, string styles)
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            var htmlStyles = new List<string>();
            if (styles != null)
            {
                htmlStyles.AddRange(styles.Split('|').ToList());
            }
            else
            {
                htmlStyles = config.AppSettings.Settings["DefaultHtmlStyles"].Value.ToString().Split('|').ToList();
            }            //Whole Divs
            var smartChartDivContainer = new Panel();
            //smartChartDivContainer.CssClass = "col-lg-6 col-md-6 col-sm-6 col-xs-12 SmartChartDivContainer";
            if (cssClasses != null)
            {
                smartChartDivContainer.CssClass = cssClasses;

            }
            else
            {
                smartChartDivContainer.CssClass = config.AppSettings.Settings["DefaultCssClasses"].Value.ToString();
            }
            ChartsContainer.Controls.Add(smartChartDivContainer);
            var mainPanel = new Panel();
            mainPanel.CssClass = "panel panel-success  tile";
            smartChartDivContainer.Controls.Add(mainPanel);
            var titleBar = new Panel();
            titleBar.CssClass = "panel-heading";
            var chartNamePanel = new Panel();
            chartNamePanel.CssClass = "panel-title";
            var chartId = new HtmlInputHidden();
            chartId.Value = idSmartChart.ToString();
            chartNamePanel.Controls.Add(new LiteralControl(chartName));
            chartNamePanel.Controls.Add(chartId);
            titleBar.Controls.Add(chartNamePanel);
            var menuContainer = new Panel();
            menuContainer.CssClass = "panel-controls panel-controls-right";
            menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
            titleBar.Controls.Add(menuContainer);
            mainPanel.Controls.Add(titleBar);
            var chartPanel = new Panel();
            chartPanel.CssClass = "panel-body";
            chartPanel.ID = chartName.Replace(" ", "") + "Container";
            chartPanel.ClientIDMode = ClientIDMode.Static;
            mainPanel.Controls.Add(chartPanel);
            //Chart menu with bootstrap
            var chartMenu = "<div class='dropdown'>" +
             "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
              "<i class=' l-basic-gear'></i>" +
             "</a>" +
                            "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
                //"<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;Columns&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
              "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +
           "</div>";
            var data = myDbContext.SpGetChartDataTermXCount(idSmartChart).FirstOrDefault();
            var chartBody = "<div class='progressbar-stats-1'>" +
                                            "<div class='stats'>" +
                                                "<i class=' l-ecommerce-graph3'></i> " +
                                                "<div class='stats-number' data-from='0' data-to='" + data.TheCount + "'>" + data.TheCount + "</div>" +
                                            "</div>" +
                                            "<div class='progress animated-bar flat transparent progress-bar-xs mb10 mt0'>" +
                                                "<div class='progress-bar progress-bar-white' role='progressbar' data-transitiongoal='100' aria-valuenow='100' style='width: 100%;'></div>" +
                                            "</div>" +
                                            "<div class='comparison'>" +
                //"<p class='mb0'><i class='fa fa-arrow-circle-o-down s20 mr5 pull-left'></i> Total reach from last month 391240, 11% down</p>" +
                "<p class='mb0'>No previous data for comparison</p>" +
                                            "</div>" +
                                        "</div>";
            chartPanel.Controls.Add(new LiteralControl(chartBody));
            menuContainer.Controls.Add(new LiteralControl(chartMenu));
        }

        protected void SummaryMentions(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName, string cssClasses, string styles)
        {
            try
            {
                var config = WebConfigurationManager.OpenWebConfiguration("~");
                var htmlStyles = new List<string>();
                if (styles != null)
                {
                    htmlStyles.AddRange(styles.Split('|').ToList());
                }
                else
                {
                    htmlStyles = config.AppSettings.Settings["DefaultHtmlStyles"].Value.ToString().Split('|').ToList();
                }            //Whole Divs
                var smartChartDivContainer = new Panel();
                //smartChartDivContainer.CssClass = "col-lg-6 col-md-6 col-sm-6 col-xs-12 SmartChartDivContainer";
                if (cssClasses != null)
                {
                    smartChartDivContainer.CssClass = cssClasses;

                }
                else
                {
                    smartChartDivContainer.CssClass = config.AppSettings.Settings["DefaultCssClasses"].Value.ToString();
                }
                ChartsContainer.Controls.Add(smartChartDivContainer);
                var mainPanel = new Panel();
                mainPanel.CssClass = "panel panel-info  tile";
                smartChartDivContainer.Controls.Add(mainPanel);
                var titleBar = new Panel();
                titleBar.CssClass = "panel-heading";
                var chartNamePanel = new Panel();
                chartNamePanel.CssClass = "panel-title";
                var chartId = new HtmlInputHidden();
                chartId.Value = idSmartChart.ToString();
                chartNamePanel.Controls.Add(new LiteralControl(chartName));
                chartNamePanel.Controls.Add(chartId);
                titleBar.Controls.Add(chartNamePanel);
                var menuContainer = new Panel();
                menuContainer.CssClass = "panel-controls panel-controls-right";
                menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
                titleBar.Controls.Add(menuContainer);
                mainPanel.Controls.Add(titleBar);
                var chartPanel = new Panel();
                chartPanel.CssClass = "panel-body";
                chartPanel.ID = chartName.Replace(" ", "") + "Container";
                chartPanel.ClientIDMode = ClientIDMode.Static;
                mainPanel.Controls.Add(chartPanel);
                //Chart menu with bootstrap
                var chartMenu = " <div class='dropdown'>" +
                 "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
                  "<i class=' l-basic-gear'></i>" +
                 "</a>" +
                 "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
                   "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
                    //"<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;Columns&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
                  "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +
               "</div>";
                var data = myDbContext.SpGetChartDataTermXCount(idSmartChart).FirstOrDefault();
                var chartBody = "<div class='progressbar-stats-1'>" +
                                                "<div class='stats'>" +
                                                    "<i class=' l-ecommerce-megaphone'></i> " +
                                                    "<div class='stats-number' data-from='0' data-to='" + data.TheCount + "'>" + data.TheCount + "</div>" +
                                                "</div>" +
                                                "<div class='progress animated-bar flat transparent progress-bar-xs mb10 mt0'>" +
                                                    "<div class='progress-bar progress-bar-white' role='progressbar' data-transitiongoal='100' aria-valuenow='100' style='width: 100%;'></div>" +
                                                "</div>" +
                                                "<div class='comparison'>" +
                    //"<p class='mb0'><i class='fa fa-arrow-circle-o-down s20 mr5 pull-left'></i> Total mentions from last month 24078, 6% down</p>" +
                    "<p class='mb0'>No previous data for comparison</p>" +
                                                "</div>" +
                                            "</div>";
                chartPanel.Controls.Add(new LiteralControl(chartBody));
                menuContainer.Controls.Add(new LiteralControl(chartMenu));
            }
            catch (Exception ex)
            {
                Console.Write("Error:" + ex.Message);
            }

        }

        protected void SummaryBestDay(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName, string cssClasses, string styles)
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            var htmlStyles = new List<string>();
            if (styles != null)
            {
                htmlStyles.AddRange(styles.Split('|').ToList());
            }
            else
            {
                htmlStyles = config.AppSettings.Settings["DefaultHtmlStyles"].Value.ToString().Split('|').ToList();
            }            //Whole Divs
            var smartChartDivContainer = new Panel();
            //smartChartDivContainer.CssClass = "col-lg-6 col-md-6 col-sm-6 col-xs-12 SmartChartDivContainer";
            if (cssClasses != null)
            {
                smartChartDivContainer.CssClass = cssClasses;

            }
            else
            {
                smartChartDivContainer.CssClass = config.AppSettings.Settings["DefaultCssClasses"].Value.ToString();
            }
            ChartsContainer.Controls.Add(smartChartDivContainer);
            var mainPanel = new Panel();
            mainPanel.CssClass = "panel panel-danger  tile";
            smartChartDivContainer.Controls.Add(mainPanel);
            var titleBar = new Panel();
            titleBar.CssClass = "panel-heading";
            var chartNamePanel = new Panel();
            chartNamePanel.CssClass = "panel-title";
            var chartId = new HtmlInputHidden();
            chartId.Value = idSmartChart.ToString();
            chartNamePanel.Controls.Add(new LiteralControl(chartName));
            chartNamePanel.Controls.Add(chartId);
            titleBar.Controls.Add(chartNamePanel);
            var menuContainer = new Panel();
            menuContainer.CssClass = "panel-controls panel-controls-right";
            menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
            titleBar.Controls.Add(menuContainer);
            mainPanel.Controls.Add(titleBar);
            var chartPanel = new Panel();
            chartPanel.CssClass = "panel-body";
            chartPanel.ID = chartName.Replace(" ", "") + "Container";
            chartPanel.ClientIDMode = ClientIDMode.Static;
            mainPanel.Controls.Add(chartPanel);
            //Chart menu with bootstrap
            var chartMenu = "<div class='dropdown'>" +
             "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
              "<i class=' l-basic-gear'></i>" +
             "</a>" +
             "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
                //"<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;Columns&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
              "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +
           "</div>";
            var data = myDbContext.SpGetChartDataTermXCount(idSmartChart).FirstOrDefault();
            var chartBody = "<div class='progressbar-stats-1'>" +
                                            "<div class='stats'>" +
                                                "<i class=' l-basic-calendar'></i> " +
                                                "<div class='stats-number' data-from='0' data-to='7565'>" + Convert.ToDateTime(data.Term).ToString("MMM dd, yyyy") + "</div>" +
                                            "</div>" +
                                            "<div class='progress animated-bar flat transparent progress-bar-xs mb10 mt0'>" +
                                                "<div class='progress-bar progress-bar-white' role='progressbar' data-transitiongoal='100' aria-valuenow='100' style='width: 100%;'></div>" +
                                            "</div>" +
                                            "<div class='comparison'>" +
                //"<p class='mb0'><i class='fa fa-arrow-circle-o-up s20 mr5 pull-left'></i> Best day of last month April 12, 7565</p>" +
                "<p class='mb0'>No previous data for comparison</p>" +
                                            "</div>" +
                                        "</div>";
            chartPanel.Controls.Add(new LiteralControl(chartBody));
            menuContainer.Controls.Add(new LiteralControl(chartMenu));
        }

        protected void SummaryTopUser(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName, string cssClasses, string styles)
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            var htmlStyles = new List<string>();
            if (styles != null)
            {
                htmlStyles.AddRange(styles.Split('|').ToList());
            }
            else
            {
                htmlStyles = config.AppSettings.Settings["DefaultHtmlStyles"].Value.ToString().Split('|').ToList();
            }            //Whole Divs
            var smartChartDivContainer = new Panel();
            //smartChartDivContainer.CssClass = "col-lg-6 col-md-6 col-sm-6 col-xs-12 SmartChartDivContainer";
            if (cssClasses != null)
            {
                smartChartDivContainer.CssClass = cssClasses;

            }
            else
            {
                smartChartDivContainer.CssClass = config.AppSettings.Settings["DefaultCssClasses"].Value.ToString();
            }
            ChartsContainer.Controls.Add(smartChartDivContainer);
            var mainPanel = new Panel();
            mainPanel.CssClass = "panel panel-default  tile";
            smartChartDivContainer.Controls.Add(mainPanel);
            var titleBar = new Panel();
            titleBar.CssClass = "panel-heading";
            var chartNamePanel = new Panel();
            chartNamePanel.CssClass = "panel-title";
            var chartId = new HtmlInputHidden();
            chartId.Value = idSmartChart.ToString();
            chartNamePanel.Controls.Add(new LiteralControl(chartName));
            chartNamePanel.Controls.Add(chartId);
            titleBar.Controls.Add(chartNamePanel);
            var menuContainer = new Panel();
            menuContainer.CssClass = "panel-controls panel-controls-right";
            menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
            titleBar.Controls.Add(menuContainer);
            mainPanel.Controls.Add(titleBar);
            var chartPanel = new Panel();
            chartPanel.CssClass = "panel-body";
            chartPanel.ID = chartName.Replace(" ", "") + "Container";
            chartPanel.ClientIDMode = ClientIDMode.Static;
            mainPanel.Controls.Add(chartPanel);
            //Chart menu with bootstrap
            var chartMenu = "<div class='dropdown'>" +
             "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
              "<i class=' l-basic-gear'></i>" +
             "</a>" +
             "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
                //"<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;Columns&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
              "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +
           "</div>";
            var data = myDbContext.SpGetChartDataTermXCount(idSmartChart).FirstOrDefault();
            var chartBody = "<div class='progressbar-stats-1 dark'>" +
                                            "<div class='stats'>" +
                                                "<i class=' l-weather-star'></i> " +
                                                "<div class='stats-number' data-from='0' data-to='76'>" + data.Term + ":<span style='font-size: 20px;'> " + data.TheCount + " </span></div>" +
                                            "</div>" +
                                            "<div class='progress animated-bar flat transparent progress-bar-xs mb10 mt0'>" +
                                                "<div class='progress-bar progress-bar-white' role='progressbar' data-transitiongoal='100' aria-valuenow='100' style='width: 100%;'></div>" +
                                            "</div>" +
                                            "<div class='comparison'>" +
                //"<p class='mb0'><i class='fa fa-arrow-circle-o-down s20 mr5 pull-left'></i> Last month's, opal_cloud: 3822 Followers</p>" +
                "<p class='mb0'>No previous data for comparison</p>" +
                                            "</div>" +
                                        "</div>";
            chartPanel.Controls.Add(new LiteralControl(chartBody));
            menuContainer.Controls.Add(new LiteralControl(chartMenu));
        }
        public string ProcessScreenName(object myValue)
        {
            if (myValue == "")
            {
                return "User";
            }

            return myValue.ToString();
        }

        public string ProcessImage(string myValue)
        {
            if (myValue == "")
            {
                return "../images/userPlaceHolder.jpg";
            }

            return myValue.ToString();
        }

        public void ExportExcel_Click(object sender, EventArgs args)
        {
            ExcelGrid.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), "Xlsx");
            ExcelGrid.ExportSettings.IgnorePaging = true;
            //ExcelGrid.ExportSettings.ExportOnlyData = true;
            ExcelGrid.ExportSettings.OpenInNewWindow = true;
            ExcelGrid.MasterTableView.ExportToExcel();
        }

        public void DeleteWord(object sender, EventArgs args)
        {
            var word = WordToDelete.Value.Split('|').ElementAt(1);
            var chartId = WordToDelete.Value.Split('|').ElementAt(0);
            using (SmartSocialdbDataContext myDb = new SmartSocialdbDataContext())
            {
                var series = myDb.ChartSeries.Where(x => x.IdSmartChart == Convert.ToInt32(chartId)).ToList();
                var wordToDelete = myDb.SeriesValue.FirstOrDefault(x => x.Value == word && series.Contains(x.ChartSeries));
                var seriesToDelete = myDb.SeriesValue.Where(x => x.RowPosition == wordToDelete.RowPosition && x.IdChartSeries == wordToDelete.IdChartSeries);
                myDb.SeriesValue.Delete(seriesToDelete);
            }
        }

        public string ProcessSocialNetwork(object socialNetwork)
        {
            switch (socialNetwork.ToString())
            {
                case "TWITTER":
                    return "../images/SocialNetworkIcons/twitter-icon.png";
                case "WORDPRESS":
                    return "../images/SocialNetworkIcons/wordpress-icon.png";
                case "WEB":
                    return "../images/SocialNetworkIcons/blog-icon.jpg";
                case "FACEBOOK":
                    return "../images/SocialNetworkIcons/facebook-icon.jpg";
                case "FORUMS":
                    return "../images/SocialNetworkIcons/forum-icon.png";
                case "REDDIT":
                    return "../images/SocialNetworkIcons/reddit-icon.png";
                case "GOOGLE_PLUS":
                    return "../images/SocialNetworkIcons/google-plus-icon.png";
                case "INSTAGRAM":
                    return "../images/SocialNetworkIcons/Instagram-icon.png";
                case "YOUTUBE":
                    return "../images/SocialNetworkIcons/youtube-icon.png";
                default:
                    return "../images/SocialNetworkIcons/blog-icon.jpg";
            }
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            switch (e.Argument)
            {
                case "DatasourceExcel":
                    LoadingImageExcel.Visible = false;
                    ExcelGrid.Visible = true;
                    UpdateExcelDatasource(null, null);
                    break;
                case "CleanExcelGrid":
                    ExcelGrid.Visible = false;
                    LoadingImageExcel.Visible = true;
                    break;
                case "WordCloudsDeleter":
                    //Done
                    foreach (var word in wordsInClouds)
                    {
                        WordCloudContextMenu.Targets.Add(new ContextMenuElementTarget()
                        {
                            ElementID = word.Id
                        });
                    }
                    WordCloudContextMenu.DataBind();
                    break;
            }


        }

        protected void UpdateExcelDatasource(object source, GridNeedDataSourceEventArgs e)
        {
            if (ExcelType.Value != "")
            {
                using (SmartSocialdbDataContext myDb = new SmartSocialdbDataContext())
                {

                    switch (ExcelType.Value)
                    {
                        case "Linear":
                            ExcelGrid.DataSource = myDb.SpGetChartDataTermXTimeXCount(Convert.ToInt32(ExcelId.Value));
                            break;
                        case "Columns":
                            ExcelGrid.DataSource = myDb.SpGetChartDataTermXCount(Convert.ToInt32(ExcelId.Value));
                            break;
                        case "Pie":
                            ExcelGrid.DataSource = myDb.SpGetChartDataTermXCount(Convert.ToInt32(ExcelId.Value));
                            break;
                        case "StackedColumnCharts":
                            ExcelGrid.DataSource = myDb.SpGetChartDataTermXGroupedTermXCount(Convert.ToInt32(ExcelId.Value));
                            break;
                        case "TreeMap":
                            ExcelGrid.DataSource = myDb.SpGetChartDataParentTopicXTopicXWeight(Convert.ToInt32(ExcelId.Value));
                            break;
                        case "WordCloud":
                            ExcelGrid.DataSource = myDb.SpGetChartDataTermXCount(Convert.ToInt32(ExcelId.Value));
                            break;
                        case "MostProlificUsers":
                            ExcelGrid.DataSource = myDb.SpGetChartDataAudienceStream(Convert.ToInt32(ExcelId.Value));
                            break;
                        case "LocationAnalysis":
                            ExcelGrid.DataSource = myDb.SpGetChartDataTermXGroupedTermXCount(Convert.ToInt32(ExcelId.Value));
                            break;

                    }
                    ExcelGrid.DataBind();
                }
            }
        }

        protected void ExportWholePDF(object sender, EventArgs args)
        {
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                String htmlText = HtmlString.Value;
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, new StringReader(htmlText));
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;" +
                                               "filename=ExportReport.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            {
            }
        }


        //Here goes the summaries methods
        protected void AudienceCharts(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName, string cssClasses, string styles)
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            var htmlStyles = new List<string>();
            if (styles != null)
            {
                htmlStyles.AddRange(styles.Split('|').ToList());
            }
            else
            {
                htmlStyles = config.AppSettings.Settings["DefaultHtmlStyles"].Value.ToString().Split('|').ToList();
            }
            var smartChartDivContainer = new Panel();
            //smartChartDivContainer.CssClass = "col-lg-6 col-md-6 col-sm-6 col-xs-12 SmartChartDivContainer";
            smartChartDivContainer.ID = idSmartChart.ToString();
            if (cssClasses != null)
            {
                smartChartDivContainer.CssClass = cssClasses;

            }
            else
            {
                smartChartDivContainer.CssClass = config.AppSettings.Settings["DefaultCssClasses"].Value.ToString();
            }
            ChartsContainer.Controls.Add(smartChartDivContainer);
            var mainPanel = new Panel();
            mainPanel.CssClass = "panel panel-default plain btrr0 bbrr0";
            smartChartDivContainer.Controls.Add(mainPanel);
            var titleBar = new Panel();
            titleBar.CssClass = "panel-heading";
            var chartNamePanel = new Panel();
            chartNamePanel.CssClass = "panel-title";
            var chartId = new HtmlInputHidden();
            chartId.Value = idSmartChart.ToString();
            chartNamePanel.Controls.Add(new LiteralControl(chartName));
            chartNamePanel.Controls.Add(chartId);
            titleBar.Controls.Add(chartNamePanel);
            var menuContainer = new Panel();
            menuContainer.CssClass = "panel-controls panel-controls-right";
            menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
            titleBar.Controls.Add(menuContainer);
            mainPanel.Controls.Add(titleBar);
            var chartPanel = new Panel();
            chartPanel.CssClass = "panel-body costumersContainer";
            chartPanel.ID = chartName.Replace(" ", "") + "Container";
            chartPanel.ClientIDMode = ClientIDMode.Static;
            mainPanel.Controls.Add(chartPanel);
            var chartData = myDbContext.SpGetChartDataAudienceStream(idSmartChart);
            var costumersList = "<ul class='list-group recent-comments'>";
            foreach (var post in chartData.OrderByDescending(x => Convert.ToInt32(x.Followers)))
            {
                if (post.ProfileUrl != "")
                {
                    costumersList += "<li class='list-group-item clearfix comment-info'>" +
                                                    "<div class='avatar pull-left mr15'>" +
                                                        "<img src='" + ProcessImage(post.ProfileImageUrl) + "' alt='avatar' style='width:48px;height:48px'>" +
                                                    "</div>" +
                                                    "<p class='text-ellipsis'><span class='name strong'>" + ProcessScreenName(post.UserName) + ": </span>" + post.Bio + " </p>" +
                                                    "<span class='date text-muted small pull-left'><img style='width:16px;height:16px' src='" +
                            ProcessSocialNetwork(post.SocialNetwork) + "'/> " + post.Followers + " Followers | " + post.Statuses + " Total Posts</span>" +
                                                    "<a href='" + post.ProfileUrl + "' class='see-more small pull-right' target='_blanc' >View profile</a>" +
                                                "</li>";
                }
                else
                {
                    costumersList += "<li class='list-group-item clearfix comment-info'>" +
                                                "<div class='avatar pull-left mr15'>" +
                                                    "<img src='" + ProcessImage(post.ProfileImageUrl) + "' alt='avatar' style='width:48px;height:48px'>" +
                                                "</div>" +
                                                "<p class='text-ellipsis'><span class='name strong'>" + ProcessScreenName(post.UserName) + ": </span>" + post.Bio + " </p>" +
                                                "<span class='date text-muted small pull-left'><img style='width:16px;height:16px' src='" +
                    ProcessSocialNetwork(post.SocialNetwork) + "'/> " + post.Followers + " Followers | " + post.Statuses + " Total Posts</span>" +
                                            "</li>";
                }

            }
            costumersList += "</ul>";

            var chartMenu = "<div class='dropdown'>" +
              "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
               "<i class='fa fa-gear'></i>" +
              "</a>" +
              "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
                "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
                "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;MostProlificUsers&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
               "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +

            "</div>";
            chartPanel.Controls.Add(new LiteralControl(costumersList));
            menuContainer.Controls.Add(new LiteralControl(chartMenu));
        }

        protected void LineCharts(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName, string axisValuesTitle, string cssClasses, string styles)
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            var htmlStyles = new List<string>();
            if (styles != null)
            {
                htmlStyles.AddRange(styles.Split('|').ToList());
            }
            else
            {
                htmlStyles = config.AppSettings.Settings["DefaultHtmlStyles"].Value.ToString().Split('|').ToList();
            }            //Whole Divs
            var smartChartDivContainer = new Panel();
            smartChartDivContainer.ID = idSmartChart.ToString();
            if (cssClasses != null)
            {
                smartChartDivContainer.CssClass = cssClasses;

            }
            else
            {
                smartChartDivContainer.CssClass = config.AppSettings.Settings["DefaultCssClasses"].Value.ToString();
            }
            ChartsContainer.Controls.Add(smartChartDivContainer);
            var mainPanel = new Panel();
            mainPanel.CssClass = "panel panel-default plain btrr0 bbrr0";
            smartChartDivContainer.Controls.Add(mainPanel);
            var titleBar = new Panel();
            titleBar.CssClass = "panel-heading";
            var chartNamePanel = new Panel();
            chartNamePanel.CssClass = "panel-title";
            var chartId = new HtmlInputHidden();
            chartId.Value = idSmartChart.ToString();
            chartNamePanel.Controls.Add(new LiteralControl(chartName));
            chartNamePanel.Controls.Add(chartId);
            titleBar.Controls.Add(chartNamePanel);
            var menuContainer = new Panel();
            menuContainer.CssClass = "panel-controls panel-controls-right";
            menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
            titleBar.Controls.Add(menuContainer);
            mainPanel.Controls.Add(titleBar);
            var chartPanel = new Panel();
            chartPanel.CssClass = "panel-body";
            chartPanel.ID = chartName.Replace(" ", "") + "Container";
            chartPanel.ClientIDMode = ClientIDMode.Static;
            mainPanel.Controls.Add(chartPanel);
            var chartData = myDbContext.SpGetChartDataTermXTimeXCount(idSmartChart);
            RadHtmlChart multipleLineChart = new RadHtmlChart();
            var series = new List<ScatterLineSeries>();
            var minorValue = (decimal)0.00;
            var maxValue = (decimal)0.00;
            foreach (var termGroup in chartData.GroupBy(cust => cust.Term))
            {
                ScatterLineSeries serie = new ScatterLineSeries();
                serie.Name = termGroup.First().Term;
                serie.LabelsAppearance.Visible = false;
                serie.TooltipsAppearance.ClientTemplate = "#= kendo.format(\"{0:MMM dd}\", new Date(value.x)) #,  #=value.y#";
                serie.TooltipsAppearance.Color = Color.White;
                foreach (var result in termGroup)
                {
                    var dateInDecimal = (decimal)Convert.ToDateTime(result.TheTime + " 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                    if (dateInDecimal > maxValue)
                    {
                        maxValue = dateInDecimal;
                    }
                    if (dateInDecimal < minorValue || minorValue < 1)
                    {
                        minorValue = dateInDecimal;
                    }
                    serie.SeriesItems.Add(new ScatterSeriesItem(dateInDecimal, (decimal)Convert.ToInt32(result.TheCount)));
                }
                series.Add(serie);
            }
            multipleLineChart.PlotArea.Series.AddRange(series);
            multipleLineChart.PlotArea.XAxis.MajorGridLines.Visible = true;
            multipleLineChart.PlotArea.XAxis.MinorGridLines.Visible = false;
            multipleLineChart.PlotArea.XAxis.MaxValue = maxValue + 345600000;
            multipleLineChart.PlotArea.XAxis.MinValue = minorValue;
            multipleLineChart.PlotArea.XAxis.Type = AxisType.Date;
            multipleLineChart.PlotArea.XAxis.LabelsAppearance.DataFormatString = "{0:MMM dd}";
            multipleLineChart.ClientIDMode = ClientIDMode.Static;
            multipleLineChart.Legend.Appearance.BackgroundColor = Color.White;
            multipleLineChart.Legend.Appearance.Position = ChartLegendPosition.Bottom;
            if (htmlStyles.Any(x => x.StartsWith("Height")))
            {
                var height = htmlStyles.FirstOrDefault(x => x.StartsWith("Height")).Split(':').ElementAt(1);
                if (height.EndsWith("px"))
                {
                    multipleLineChart.Height = Unit.Pixel(Convert.ToInt32(height.Replace("px", "")));
                }
                else if (height.EndsWith("%"))
                {
                    multipleLineChart.Height = Unit.Percentage(Convert.ToInt32(height.Replace("%", "")));
                }
            }

            //Chart menu with bootstrap
            var chartMenu = "<div class='dropdown'>" +
             "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
              "<i class='fa fa-gear'></i>" +
             "</a>" +
             "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;Linear&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
              "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +
           "</div>";
            multipleLineChart.PlotArea.YAxis.TitleAppearance.Text = axisValuesTitle;
            multipleLineChart.ID = chartName.Replace(" ", "");
            multipleLineChart.OnClientSeriesClicked = "ConversationStreamTrendlineOpen";
            chartPanel.Controls.Add(multipleLineChart);
            menuContainer.Controls.Add(new LiteralControl(chartMenu));

        }

        protected void ColumnCharts(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName, string axisSeriesTitle, string axisValuesTitle, string cssClasses, string styles)
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            var htmlStyles = new List<string>();
            if (styles != null)
            {
                htmlStyles.AddRange(styles.Split('|').ToList());
            }
            else
            {
                htmlStyles = config.AppSettings.Settings["DefaultHtmlStyles"].Value.ToString().Split('|').ToList();
            }            //Whole Divs
            var smartChartDivContainer = new Panel();
            //smartChartDivContainer.CssClass = "col-lg-6 col-md-6 col-sm-6 col-xs-12 SmartChartDivContainer";
            smartChartDivContainer.ID = idSmartChart.ToString();
            if (cssClasses != null)
            {
                smartChartDivContainer.CssClass = cssClasses;

            }
            else
            {
                smartChartDivContainer.CssClass = config.AppSettings.Settings["DefaultCssClasses"].Value.ToString();
            }
            ChartsContainer.Controls.Add(smartChartDivContainer);
            var mainPanel = new Panel();
            mainPanel.CssClass = "panel panel-default plain btrr0 bbrr0";
            smartChartDivContainer.Controls.Add(mainPanel);
            var titleBar = new Panel();
            titleBar.CssClass = "panel-heading";
            var chartNamePanel = new Panel();
            chartNamePanel.CssClass = "panel-title";
            var chartId = new HtmlInputHidden();
            chartId.Value = idSmartChart.ToString();
            chartNamePanel.Controls.Add(new LiteralControl(chartName));
            chartNamePanel.Controls.Add(chartId);
            titleBar.Controls.Add(chartNamePanel);
            var menuContainer = new Panel();
            menuContainer.CssClass = "panel-controls panel-controls-right";
            menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
            titleBar.Controls.Add(menuContainer);
            mainPanel.Controls.Add(titleBar);
            var chartPanel = new Panel();
            chartPanel.CssClass = "panel-body";
            chartPanel.ID = chartName.Replace(" ", "") + "Container";
            chartPanel.ClientIDMode = ClientIDMode.Static;
            mainPanel.Controls.Add(chartPanel);
            RadHtmlChart barChart = new RadHtmlChart();
            var chartData = myDbContext.SpGetChartDataTermXCount(idSmartChart);
            var serie = new BarSeries();
            serie.LabelsAppearance.Visible = false;
            var maxiValue = Convert.ToDecimal(0);
            foreach (var data in chartData.OrderBy(x => x.Term))
            {
                if (maxiValue < Convert.ToDecimal(data.TheCount))
                {
                    maxiValue = Convert.ToDecimal(data.TheCount);
                }
                serie.SeriesItems.Add(new CategorySeriesItem()
                {
                    Y = Convert.ToInt32(data.TheCount)
                });
                barChart.PlotArea.XAxis.Items.Add(new AxisItem()
                {
                    LabelText = data.Term
                });

            }
            //Chart menu with bootstrap
            var chartMenu = "<div class='dropdown'>" +
             "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
              "<i class='fa fa-gear'></i>" +
             "</a>" +
             "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;Columns&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
             "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +
           "</div>";
            serie.Name = axisSeriesTitle;
            barChart.PlotArea.YAxis.TitleAppearance.Text = axisValuesTitle;
            barChart.PlotArea.YAxis.MaxValue = maxiValue;
            barChart.PlotArea.YAxis.MinValue = 0;
            barChart.PlotArea.YAxis.Step = Math.Round(maxiValue / 2);
            barChart.PlotArea.Series.Add(serie);
            barChart.ID = chartName.Replace(" ", "");
            barChart.Legend.Appearance.BackgroundColor = Color.White;
            barChart.Legend.Appearance.Position = ChartLegendPosition.Bottom;
            barChart.OnClientSeriesClicked = "ConversationColumPie";
            barChart.ClientIDMode = ClientIDMode.Static;
            barChart.Appearance.FillStyle.BackgroundColor = Color.Transparent;
            if (htmlStyles.Any(x => x.StartsWith("Height")))
            {
                var height = htmlStyles.FirstOrDefault(x => x.StartsWith("Height")).Split(':').ElementAt(1);
                if (height.EndsWith("px"))
                {
                    barChart.Height = Unit.Pixel(Convert.ToInt32(height.Replace("px", "")));
                }
                else if (height.EndsWith("%"))
                {
                    barChart.Height = Unit.Percentage(Convert.ToInt32(height.Replace("%", "")));
                }
            }
            chartPanel.Controls.Add(barChart);
            menuContainer.Controls.Add(new LiteralControl(chartMenu));


        }

        protected void StackedColumnCharts(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName, string axisValuesTitle, string cssClasses, string styles)
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            var htmlStyles = new List<string>();
            if (styles != null)
            {
                htmlStyles.AddRange(styles.Split('|').ToList());
            }
            else
            {
                htmlStyles = config.AppSettings.Settings["DefaultHtmlStyles"].Value.ToString().Split('|').ToList();
            }
            //Whole Divs
            var smartChartDivContainer = new Panel();
            smartChartDivContainer.ID = idSmartChart.ToString();
            if (cssClasses != null)
            {
                smartChartDivContainer.CssClass = cssClasses;

            }
            else
            {
                smartChartDivContainer.CssClass = config.AppSettings.Settings["DefaultCssClasses"].Value.ToString();
            }
            ChartsContainer.Controls.Add(smartChartDivContainer);
            var mainPanel = new Panel();
            mainPanel.CssClass = "panel panel-default plain btrr0 bbrr0";
            smartChartDivContainer.Controls.Add(mainPanel);
            var titleBar = new Panel();
            titleBar.CssClass = "panel-heading";
            var chartNamePanel = new Panel();
            chartNamePanel.CssClass = "panel-title";
            var chartId = new HtmlInputHidden();
            chartId.Value = idSmartChart.ToString();
            chartNamePanel.Controls.Add(new LiteralControl(chartName));
            chartNamePanel.Controls.Add(chartId);
            titleBar.Controls.Add(chartNamePanel);
            var menuContainer = new Panel();
            menuContainer.CssClass = "panel-controls panel-controls-right";
            menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
            titleBar.Controls.Add(menuContainer);
            mainPanel.Controls.Add(titleBar);
            var chartPanel = new Panel();
            chartPanel.CssClass = "panel-body";
            chartPanel.ID = chartName.Replace(" ", "") + "Container";
            chartPanel.ClientIDMode = ClientIDMode.Static;
            mainPanel.Controls.Add(chartPanel);

            var chartData = myDbContext.SpGetChartDataTermXGroupedTermXCount(idSmartChart);
            RadHtmlChart multipleBarChart = new RadHtmlChart();
            var series = new List<BarSeries>();
            var terms = new List<string>();
            foreach (var termGroup in chartData.GroupBy(cust => cust.TheGroup))
            {
                BarSeries serie = new BarSeries();
                serie.Name = termGroup.First().TheGroup;
                serie.LabelsAppearance.Visible = false;
                serie.Stacked = true;
                foreach (var result in termGroup.OrderBy(x => x.Term))
                {
                    serie.SeriesItems.Add(new CategorySeriesItem((decimal)Convert.ToInt32(result.TheCount)));
                    if (!terms.Any(x => x == result.Term))
                    {
                        terms.Add(result.Term);
                    }
                }
                series.Add(serie);
            }
            multipleBarChart.PlotArea.Series.AddRange(series);
            multipleBarChart.ClientIDMode = ClientIDMode.Static;
            multipleBarChart.Legend.Appearance.BackgroundColor = Color.White;
            multipleBarChart.Legend.Appearance.Position = ChartLegendPosition.Bottom;
            multipleBarChart.PlotArea.YAxis.TitleAppearance.Text = axisValuesTitle;
            foreach (var term in terms)
            {
                multipleBarChart.PlotArea.XAxis.Items.Add(new AxisItem()
                {
                    LabelText = term
                });
            }
            if (htmlStyles.Any(x => x.StartsWith("Height")))
            {
                var height = htmlStyles.FirstOrDefault(x => x.StartsWith("Height")).Split(':').ElementAt(1);
                if (height.EndsWith("px"))
                {
                    multipleBarChart.Height = Unit.Pixel(Convert.ToInt32(height.Replace("px", "")));
                }
                else if (height.EndsWith("%"))
                {
                    multipleBarChart.Height = Unit.Percentage(Convert.ToInt32(height.Replace("%", "")));
                }
            }
            multipleBarChart.ID = chartName.Replace(" ", "");
            multipleBarChart.OnClientSeriesClicked = "ConversationStreamTopicSourceOpen";
            chartPanel.Controls.Add(multipleBarChart);
            //Chart menu with bootstrap
            var chartMenu = "<div class='dropdown'>" +
             "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
              "<i class='fa fa-gear'></i>" +
             "</a>" +
             "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;StackedColumnCharts&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
              "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +
           "</div>";
            menuContainer.Controls.Add(new LiteralControl(chartMenu));
        }

        protected void PieCharts(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName, string cssClasses, string styles)
        {
            //Whole Divs
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            var htmlStyles = new List<string>();
            if (styles != null)
            {
                htmlStyles.AddRange(styles.Split('|').ToList());
            }
            else
            {
                htmlStyles = config.AppSettings.Settings["DefaultHtmlStyles"].Value.ToString().Split('|').ToList();
            } var smartChartDivContainer = new Panel();
            smartChartDivContainer.ID = idSmartChart.ToString();

            if (cssClasses != null)
            {
                smartChartDivContainer.CssClass = cssClasses;

            }
            else
            {
                smartChartDivContainer.CssClass = config.AppSettings.Settings["DefaultCssClasses"].Value.ToString();
            }
            ChartsContainer.Controls.Add(smartChartDivContainer);
            var mainPanel = new Panel();
            mainPanel.CssClass = "panel panel-default plain btrr0 bbrr0";
            smartChartDivContainer.Controls.Add(mainPanel);
            var titleBar = new Panel();
            titleBar.CssClass = "panel-heading";
            var chartNamePanel = new Panel();
            chartNamePanel.CssClass = "panel-title";
            var chartId = new HtmlInputHidden();
            chartId.Value = idSmartChart.ToString();
            chartNamePanel.Controls.Add(new LiteralControl(chartName));
            chartNamePanel.Controls.Add(chartId);
            titleBar.Controls.Add(chartNamePanel);
            var menuContainer = new Panel();
            menuContainer.CssClass = "panel-controls panel-controls-right";
            menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
            titleBar.Controls.Add(menuContainer);
            mainPanel.Controls.Add(titleBar);
            var chartPanel = new Panel();
            chartPanel.CssClass = "panel-body";
            chartPanel.ID = chartName.Replace(" ", "") + "Container";
            chartPanel.ClientIDMode = ClientIDMode.Static;
            mainPanel.Controls.Add(chartPanel);

            RadHtmlChart pieChart = new RadHtmlChart();
            var chartData = myDbContext.SpGetChartDataTermXCount(idSmartChart);
            var serie = new PieSeries();
            serie.Name = "Share Voice";
            var counter = 0;
            foreach (var data in chartData.OrderByDescending(x => Convert.ToInt32(x.TheCount)))
            {
                counter++;
                if (counter > 10)
                {
                    break;
                }
                serie.SeriesItems.Add(new PieSeriesItem()
                {
                    Name = data.Term,
                    Y = Convert.ToInt32(data.TheCount)
                });
            }
            serie.LabelsAppearance.Position = PieAndDonutLabelsPosition.OutsideEnd;
            serie.LabelsAppearance.ClientTemplate = "#= category #: #= value # (#=Math.round(percentage * 100)#%)  ";
            pieChart.PlotArea.Series.Add(serie);
            pieChart.ID = chartName.Replace(" ", "");
            pieChart.Legend.Appearance.BackgroundColor = Color.White;
            pieChart.Legend.Appearance.Position = ChartLegendPosition.Bottom;
            pieChart.OnClientSeriesClicked = "ConversationColumPie";
            pieChart.ClientIDMode = ClientIDMode.Static;
            pieChart.Appearance.FillStyle.BackgroundColor = Color.Transparent;
            if (htmlStyles.Any(x => x.StartsWith("Height")))
            {
                var height = htmlStyles.FirstOrDefault(x => x.StartsWith("Height")).Split(':').ElementAt(1);
                if (height.EndsWith("px"))
                {
                    pieChart.Height = Unit.Pixel(Convert.ToInt32(height.Replace("px", "")));
                }
                else if (height.EndsWith("%"))
                {
                    pieChart.Height = Unit.Percentage(Convert.ToInt32(height.Replace("%", "")));
                }
            }
            chartPanel.Controls.Add(pieChart);
            var chartMenu = "<div class='dropdown'>" +
             "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
              "<i class='fa fa-gear'></i>" +
             "</a>" +
             "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;Pie&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
             "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +
           "</div>";
            menuContainer.Controls.Add(new LiteralControl(chartMenu));

        }

        protected void TreeMapString(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName)
        {
            //Whole Divs
            var smartChartDivContainer = new Panel();
            smartChartDivContainer.ID = idSmartChart.ToString();
            smartChartDivContainer.CssClass = "col-lg-6 col-md-6 col-sm-6 col-xs-12 SmartChartDivContainer";
            ChartsContainer.Controls.Add(smartChartDivContainer);
            var mainPanel = new Panel();
            mainPanel.CssClass = "panel panel-default plain btrr0 bbrr0";
            smartChartDivContainer.Controls.Add(mainPanel);
            var titleBar = new Panel();
            titleBar.CssClass = "panel-heading";
            var chartNamePanel = new Panel();
            chartNamePanel.CssClass = "panel-title";
            chartNamePanel.Controls.Add(new LiteralControl(chartName));
            titleBar.Controls.Add(chartNamePanel);
            var menuContainer = new Panel();
            menuContainer.CssClass = "panel-controls panel-controls-right";
            menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
            titleBar.Controls.Add(menuContainer);
            mainPanel.Controls.Add(titleBar);
            var chartPanel = new Panel();
            chartPanel.CssClass = "chartPanel row";
            chartPanel.ID = chartName.Replace(" ", "") + "Container";
            chartPanel.ClientIDMode = ClientIDMode.Static;
            var chartData = myDbContext.SpGetChartDataParentTopicXTopicXWeight(idSmartChart);
            //Test treeview with wordcloud
            var treeMapPanel = new Panel();
            treeMapPanel.CssClass = "col-sm-5";
            treeMapPanel.ID = "TreeMapContainer";
            treeMapPanel.ClientIDMode = ClientIDMode.Static;
            treeMapPanel.Height = Unit.Percentage(100);
            var wordCloudPanel = new Panel();
            wordCloudPanel.CssClass = "col-sm-7";
            wordCloudPanel.ID = "wordCloudTree";
            wordCloudPanel.ClientIDMode = ClientIDMode.Static;
            wordCloudPanel.Height = Unit.Percentage(100);


            RadTreeView treeChart = new RadTreeView();
            treeChart.Height = Unit.Percentage(100);
            treeChart.Width = Unit.Percentage(100);
            treeChart.OnClientNodeClicked = "TreeViewWordCloud";
            treeChart.EnableDragAndDrop = false;
            var words = "";
            foreach (var parentTopicInfo in chartData.GroupBy(x => x.ParentTopic))
            {
                var parentNode = new RadTreeNode()
                {
                    Text = parentTopicInfo.First().ParentTopic,
                    Expanded = false,
                };
                foreach (var childTopicInfo in parentTopicInfo)
                {
                    words += childTopicInfo.TheTopic + ",," + childTopicInfo.ParentTopic + ",," + childTopicInfo.TheWeight + "|";
                }

                treeChart.Nodes.Add(parentNode);
            }
            words = words.Substring(0, words.Length - 1);
            TreeViewWordString.Value = words;
            treeMapPanel.Controls.Add(treeChart);
            chartPanel.Controls.Add(treeMapPanel);
            chartPanel.Controls.Add(wordCloudPanel);
            mainPanel.Controls.Add(chartPanel);
            var chartMenu = "<div class='dropdown'>" +
             "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
              "<i class='fa fa-gear'></i>" +
             "</a>" +
             "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;TreeMap&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
             "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +
           "</div>";
            menuContainer.Controls.Add(new LiteralControl(chartMenu));
        }

        protected void WordCloudCharts(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName, string cssClasses, string styles)
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            var htmlStyles = new List<string>();
            if (styles != null)
            {
                htmlStyles.AddRange(styles.Split('|').ToList());
            }
            else
            {
                htmlStyles = config.AppSettings.Settings["DefaultHtmlStyles"].Value.ToString().Split('|').ToList();
            }            //Whole Divs
            var smartChartDivContainer = new Panel();
            smartChartDivContainer.ID = idSmartChart.ToString();
            if (cssClasses != null)
            {
                smartChartDivContainer.CssClass = cssClasses;

            }
            else
            {
                smartChartDivContainer.CssClass = config.AppSettings.Settings["DefaultCssClasses"].Value.ToString();
            }
            ChartsContainer.Controls.Add(smartChartDivContainer);
            var mainPanel = new Panel();
            mainPanel.CssClass = "panel panel-default plain btrr0 bbrr0";
            smartChartDivContainer.Controls.Add(mainPanel);
            var titleBar = new Panel();
            titleBar.CssClass = "panel-heading";
            var chartNamePanel = new Panel();
            chartNamePanel.CssClass = "panel-title";
            var chartId = new HtmlInputHidden();
            chartId.Value = idSmartChart.ToString();
            chartNamePanel.Controls.Add(new LiteralControl(chartName));
            chartNamePanel.Controls.Add(chartId);
            titleBar.Controls.Add(chartNamePanel);
            var menuContainer = new Panel();
            menuContainer.CssClass = "panel-controls panel-controls-right";
            menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
            titleBar.Controls.Add(menuContainer);
            mainPanel.Controls.Add(titleBar);
            var chartPanel = new Panel();
            chartPanel.CssClass = "panel-body";
            chartPanel.ID = chartName.Replace(" ", "") + "Container";
            chartPanel.ClientIDMode = ClientIDMode.Static;
            var wordCloudTag = new Panel();
            wordCloudTag.ID = chartName.Replace(" ", "");
            if (htmlStyles.Any(x => x.StartsWith("Height")))
            {
                var height = htmlStyles.FirstOrDefault(x => x.StartsWith("Height")).Split(':').ElementAt(1);
                if (height.EndsWith("px"))
                {
                    wordCloudTag.Height = Unit.Pixel(Convert.ToInt32(height.Replace("px", "")));
                }
                else if (height.EndsWith("%"))
                {
                    wordCloudTag.Height = Unit.Percentage(Convert.ToInt32(height.Replace("%", "")));
                }
            }
            if (htmlStyles.Any(x => x.StartsWith("Width")))
            {
                var height = htmlStyles.FirstOrDefault(x => x.StartsWith("Width")).Split(':').ElementAt(1);
                if (height.EndsWith("px"))
                {
                    wordCloudTag.Width = Unit.Pixel(Convert.ToInt32(height.Replace("px", "")));
                }
                else if (height.EndsWith("%"))
                {
                    wordCloudTag.Width = Unit.Percentage(Convert.ToInt32(height.Replace("%", "")));
                }
            }
            wordCloudTag.ClientIDMode = ClientIDMode.Static;
            chartPanel.Controls.Add(wordCloudTag);
            var chartData = myDbContext.SpGetChartDataTermXCount(idSmartChart);
            var words = "";
            var counter = 0;
            foreach (var word in chartData.OrderByDescending(x => Convert.ToInt32(x.TheCount)))
            {

                wordsInClouds.Add(new WordCloudModel()
                {
                    Id = chartName.Replace(" ", "") + "_word_" + counter,
                    Name = word.Term
                });
                words += word.Term + "," + word.TheCount + "|";
                counter++;
            }
            words = words.Substring(0, words.Length - 1);
            var inputCloud = new HtmlInputHidden();
            inputCloud.Value = words;
            inputCloud.ID = chartName.Replace(" ", "") + "Input";
            inputCloud.ClientIDMode = ClientIDMode.Static;
            WordClouds.Value += wordCloudTag.ID + "|" + inputCloud.ID + ",";
            mainPanel.Controls.Add(inputCloud);
            mainPanel.Controls.Add(chartPanel);

            var chartMenu = "<div class='dropdown'>" +
             "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
              "<i class='fa fa-gear'></i>" +
             "</a>" +
             "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
               "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;WordCloud&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
              "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +
           "</div>";
            menuContainer.Controls.Add(new LiteralControl(chartMenu));
        }

        protected void LocationCharts(int idSmartChart, SmartSocialdbDataContext myDbContext, string chartName, string cssClasses, string styles)
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~");
            var htmlStyles = new List<string>();
            if (styles != null)
            {
                htmlStyles.AddRange(styles.Split('|').ToList());
            }
            else
            {
                htmlStyles = config.AppSettings.Settings["DefaultHtmlStyles"].Value.ToString().Split('|').ToList();
            }
            //Whole Divs
            var smartChartDivContainer = new Panel();
            smartChartDivContainer.ID = idSmartChart.ToString();
            if (cssClasses != null)
            {
                smartChartDivContainer.CssClass = cssClasses;

            }
            else
            {
                smartChartDivContainer.CssClass = config.AppSettings.Settings["DefaultCssClasses"].Value.ToString();
            }
            ChartsContainer.Controls.Add(smartChartDivContainer);
            var mainPanel = new Panel();
            mainPanel.CssClass = "panel panel-default plain btrr0 bbrr0";
            smartChartDivContainer.Controls.Add(mainPanel);
            var titleBar = new Panel();
            titleBar.CssClass = "panel-heading";
            var chartNamePanel = new Panel();
            chartNamePanel.CssClass = "panel-title";
            var chartId = new HtmlInputHidden();
            chartId.Value = idSmartChart.ToString();
            chartNamePanel.Controls.Add(new LiteralControl(chartName));
            chartNamePanel.Controls.Add(chartId);
            titleBar.Controls.Add(chartNamePanel);
            var menuContainer = new Panel();
            menuContainer.CssClass = "panel-controls panel-controls-right";
            menuContainer.ID = chartName.Replace(" ", "") + "MenuContainer";
            titleBar.Controls.Add(menuContainer);
            mainPanel.Controls.Add(titleBar);
            var chartPanel = new Panel();
            chartPanel.CssClass = "panel-body";
            chartPanel.ID = chartName.Replace(" ", "") + "Container";
            chartPanel.ClientIDMode = ClientIDMode.Static;
            mainPanel.Controls.Add(chartPanel);
            var chartData = myDbContext.SpGetChartDataTermXGroupedTermXCount(idSmartChart);
            RadGrid locationChart = new RadGrid();
            locationChart.ID = chartName.Replace(" ", "");
            locationChart.ClientIDMode = ClientIDMode.Static;
            if (htmlStyles.Any(x => x.StartsWith("Height")))
            {
                var height = htmlStyles.FirstOrDefault(x => x.StartsWith("Height")).Split(':').ElementAt(1);
                if (height.EndsWith("px"))
                {
                    locationChart.Height = Unit.Pixel(Convert.ToInt32(height.Replace("px", "")));
                }
                else if (height.EndsWith("%"))
                {
                    locationChart.Height = Unit.Percentage(Convert.ToInt32(height.Replace("%", "")));
                }
            }
            if (htmlStyles.Any(x => x.StartsWith("Width")))
            {
                var height = htmlStyles.FirstOrDefault(x => x.StartsWith("Width")).Split(':').ElementAt(1);
                if (height.EndsWith("px"))
                {
                    locationChart.Width = Unit.Pixel(Convert.ToInt32(height.Replace("px", "")));
                }
                else if (height.EndsWith("%"))
                {
                    locationChart.Width = Unit.Percentage(Convert.ToInt32(height.Replace("%", "")));
                }
            } var datasourceGrid = new List<LocationModel>();
            //new LocationModel(){
            //LocationName="<img src='../images/us.png' style='width:20px;height:16px' />United States",
            //Mentions="1.1k",
            //SentimentBar="<div style='display: inline-block;background-color:#9ACD32;width:90%;height: 100%;'></div><div style='display: inline-block;background-color:#FF6347;width:10%;height:100%'></div>"
            foreach (var location in chartData.GroupBy(x => x.Term))
            {
                var country = myDbContext.Country.FirstOrDefault(x => x.CountryName == location.FirstOrDefault().Term);
                var locationModel = new LocationModel()
                {
                    LocationName = "<img src='../images/Flags/" + country.FlagImageFilename + "' style='margin-bottom: 3px;'/> " + country.CountryName
                };
                var counter = 0.00;
                var positive = 0.00;
                var negative = 0.00;
                var neutral = 0.00;
                var unknow = 0.00;
                foreach (var locationProps in location)
                {
                    counter += (double)Convert.ToInt32(locationProps.TheCount);
                    switch (locationProps.TheGroup)
                    {
                        case "Positive":
                            positive = (double)Convert.ToInt32(locationProps.TheCount);
                            break;
                        case "Neutral":
                            neutral = (double)Convert.ToInt32(locationProps.TheCount);
                            break;
                        case "Negative":
                            negative = (double)Convert.ToInt32(locationProps.TheCount);
                            break;
                        case "-":
                            unknow = (double)Convert.ToInt32(locationProps.TheCount);
                            break;
                    }
                }
                //locationModel.SentimentBar = "<div style='display:inline-block;background-color:#9ACD32;width:" + (positive > 0 ? positive / ((counter - unknow) / 100) : 0) + "%;height: 100%;'></div><div style='display:inline-block;background-color:#C0C0C0;width:" + (neutral > 0 ? neutral / ((counter - unknow) / 100) : 0) + "%;height: 100%;'></div><div style='display: inline-block;background-color:#FF0000 ;width:" + (negative > 0 ? negative / ((counter - unknow) / 100) : 0) + "%;height:100%'></div>";
                locationModel.Mentions = Convert.ToInt32(counter).ToString();
                datasourceGrid.Add(locationModel);
            }
            locationChart.DataSource = datasourceGrid;
            var chartMenu = "<div class='dropdown'>" +
 "<a href='javascript:void' class='btn dropdown-toggle' type='button' id='" + chartName.Replace(" ", "") + "Menu' data-toggle='dropdown' aria-expanded='true' >" +
  "<i class='fa fa-gear'></i>" +
 "</a>" +
 "<ul class='dropdown-menu dropdown-menu-right' role='menu' aria-labelledby='" + chartName.Replace(" ", "") + "Menu' style='margin-top:30px'>" +
   "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ExportIndividualPDF(&quot;" + chartPanel.ID + "&quot;)'><i class='fa fa-file-pdf-o'></i>  Export to PDF</a></li>" +
   "<li role='presentation'><a href='javascript:void' style='padding:3px 20px;' role='menuitem' tabindex='-1' onclick='ViewAsExcel(&quot;" + idSmartChart.ToString() + "&quot;,&quot;LocationAnalysis&quot;)'><i class='fa fa-file-excel-o'></i>  Table View</a></li>" +
 "</ul>" + GeneratePopHtml(chartName, idSmartChart.ToString()) +
"</div>";
            menuContainer.Controls.Add(new LiteralControl(chartMenu));
            chartPanel.Controls.Add(locationChart);

        }


        public string GeneratePopHtml(string chartName, string idSmartChart)
        {
            return "<a href='javascript:void(0)' type='button' id='" + chartName.Replace(" ", "") + 1 +
                   "Menu' onClick='lunchPopOver(this," + idSmartChart.ToString() + ")' aria-expanded='true' >" +
                   "<i class='fa fa-comments-o'></i>" +
                   "</a><div id=\"" + idSmartChart.ToString() + "_PopUp\"  class=\"popover-markup\"><div class=\"head head-popup_" + idSmartChart.ToString() + " hide\">Comments</div>" +
                   "<div class=\"content content-popup_" + idSmartChart.ToString() + " hide\"><div class=\"row\"><div class=\"col-lg-12 commentsField\" id=\"commentsField_" + idSmartChart.ToString() + "\"></div></div><div class=\"row\"><div class=\"col-lg-12\">" +
                   "<div class=\"input-group\"><input type=\"text\" name=\"" + idSmartChart.ToString() + "_" + idSmartChart.ToString() + "\" onKeyDown=\"if(event.keyCode==13) postComment(" + idSmartChart.ToString() + ");\" class=\"form-control\" id=\"txtComment_" + idSmartChart.ToString() + "\" placeholder=\"New Comment\" />" +
                   "<span class=\"input-group-btn\"><button class=\"btn btn-default\" onClick=\"postComment(" + idSmartChart.ToString() + ")\" type=\"button\"><i class=\"fa fa-chevron-right\"></i></button>" +
                   "</span></div></div></div></div></div>";

        }


    }


}