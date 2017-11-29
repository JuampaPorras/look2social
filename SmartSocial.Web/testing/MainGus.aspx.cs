using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI;
using Telerik.Web.UI;
using Telerik.Web.UI.HtmlChart;

namespace SmartSocial.Web.masterpages
{
    public partial class MainGus : Page
    {
        public static List<ConversationStreamPost> currentConversation = new List<ConversationStreamPost>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Turn Left Pane and Splitbar ON. We've entered a Reports manager page
                ((Main)this.Master).LeftPaneAndSplitbarVisible = true;
                VolumeTrendLine();
                MentionVolumeBar();
                ReachTrendLine();
                ReachVolumeBar();
                ShareVoicePie();
                TopicSourceBar();
                RadTreeMap1.DataFieldID = "ID";
                RadTreeMap1.DataFieldParentID = "ParentID";
                RadTreeMap1.DataTextField = "Name";
                RadTreeMap1.DataValueField = "Value";
                RadTreeMap1.DataSource = TopicAnalysisTreeMap();
                RadTreeMap1.DataBind();

            }
        }
        public class ConversationStreamPost
        {
            public string SocialNetwork { get; set; }
            public string ScreenName { get; set; }
            public string ProfileImg { get; set; }
            public string MessagePost { get; set; }
            public string MessageMinimized { get; set; }
            public DateTime DatePost { get; set; }


        }

        protected void VolumeTrendLine()
        {
            var series = new List<ScatterLineSeries>();
            ScatterLineSeries aws = new ScatterLineSeries();
            aws.Name = "DX2015 Dev Cloud AWS";
            aws.LabelsAppearance.Visible = false;
            aws.TooltipsAppearance.ClientTemplate = "#= kendo.format(\"{0:MMM dd}\", new Date(value.x)) #,  #=value.y#";
            aws.TooltipsAppearance.Color = Color.White;
            var awsItems = new List<ScatterSeriesItem>(){
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/28/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1593),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/29/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,2639),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/30/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1849),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/31/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,633),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/01/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,787),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/02/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1286),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/03/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1150),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/04/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1005),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/05/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,968),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/06/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,852),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/07/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,616),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/08/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,693),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/09/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,877),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/10/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,935),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/11/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1716),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/12/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1203),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/13/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,996),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/14/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,615),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/15/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,649),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/16/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1081),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/17/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1027),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/18/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1549),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/19/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1024),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/20/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,938),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/21/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,591),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/22/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,672),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/23/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,916),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/24/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1131),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/25/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1071),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/26/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,773)
            };
            aws.SeriesItems.AddRange(awsItems);
            series.Add(aws);
            ScatterLineSeries azure = new ScatterLineSeries();
            azure.Name = "DX2015 Dev Cloud Azure";
            azure.LabelsAppearance.Visible = false;
            azure.TooltipsAppearance.ClientTemplate = "#= kendo.format(\"{0:MMM dd}\", new Date(value.x)) #,  #=value.y#";
            azure.TooltipsAppearance.Color = Color.White;
            var azureItems = new List<ScatterSeriesItem>(){
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/28/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,597),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/29/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,530),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/30/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,507),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/31/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,283),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/01/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,274),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/02/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,469),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/03/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,434),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/04/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,719),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/05/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,647),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/06/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,404),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/07/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,230),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/08/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,304),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/09/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,525),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/10/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,476),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/11/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,719),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/12/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,397),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/13/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,526),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/14/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,217),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/15/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,390),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/16/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,416),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/17/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,608),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/18/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1196),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/19/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,918),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/20/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,569),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/21/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,341),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/22/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,429),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/23/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,567),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/24/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,561),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/25/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,664),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/26/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,443)
            };
            azure.SeriesItems.AddRange(azureItems);
            series.Add(azure);
            ScatterLineSeries google = new ScatterLineSeries();
            google.Name = "DX2015 Dev Cloud Google";
            google.LabelsAppearance.Visible = false;
            google.TooltipsAppearance.ClientTemplate = "#= kendo.format(\"{0:MMM dd}\", new Date(value.x)) #,  #=value.y#";
            google.TooltipsAppearance.Color = Color.White;
            var googleItems = new List<ScatterSeriesItem>(){
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/28/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,82),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/29/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,202),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/30/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,57),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/31/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,43),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/01/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,202),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/02/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,57),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/03/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,43),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/04/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,34),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/05/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,96),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/06/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,68),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/07/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,66),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/08/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,52),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/09/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,55),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/10/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,42),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/11/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,28),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/12/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,52),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/13/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,62),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/14/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,127),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/15/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,55),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/16/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,123),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/17/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,38),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/18/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,112),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/19/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,54),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/20/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,144),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/21/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,34),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/22/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,240),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/23/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,89),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/24/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,99),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/25/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,135),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/26/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,63),
            };
            google.SeriesItems.AddRange(googleItems);
            series.Add(google);
            ScatterLineSeries vMware = new ScatterLineSeries();
            vMware.Name = "DX2015 Dev Cloud VMware";
            vMware.LabelsAppearance.Visible = false;
            vMware.TooltipsAppearance.ClientTemplate = "#= kendo.format(\"{0:MMM dd}\", new Date(value.x)) #,  #=value.y#";
            vMware.TooltipsAppearance.Color = Color.White;
            var vMwareItems = new List<ScatterSeriesItem>(){
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/28/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,29),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/29/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,139),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/30/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,20),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/31/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/01/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,3),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/02/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,39),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/03/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,42),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/04/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,42),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/05/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,43),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/06/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,16),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/07/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,11),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/08/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,3),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/09/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,13),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/10/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,9),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/11/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,10),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/12/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,24),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/13/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,18),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/14/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,4),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/15/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,3),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/16/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,17),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/17/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,22),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/18/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,42),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/19/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,15),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/20/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,12),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/21/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,4),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/22/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,5),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/23/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,18),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/24/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,10),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/25/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,14),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/26/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,17),
            };
            vMware.SeriesItems.AddRange(vMwareItems);
            series.Add(vMware);
            VolumeTrendlineChartControl.PlotArea.XAxis.Type = AxisType.Date;
            VolumeTrendlineChartControl.PlotArea.YAxis.TitleAppearance.Text = "Mentions";
            VolumeTrendlineChartControl.PlotArea.XAxis.LabelsAppearance.DataFormatString = "{0:MMM dd}";
            VolumeTrendlineChartControl.PlotArea.Series.AddRange(series);
        }
        protected DataTable TopicAnalysisTreeMap()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("ParentID");
            table.Columns.Add("Name");
            table.Columns.Add("Value");

            table.Rows.Add(new String[] { "1", null, "", "4000" });
            table.Rows.Add(new String[] { "2", "1", "Cloud Computing", "250" });
            table.Rows.Add(new String[] { "3", "2", "Image", "250" });
            table.Rows.Add(new String[] { "4", "2", "Windows", "250" });
            table.Rows.Add(new String[] { "5", "2", "Corporate Clients", "250" });
            table.Rows.Add(new String[] { "6", "2", "Azure", "250" });
            table.Rows.Add(new String[] { "7", "2", "WorkMail", "250" });
            table.Rows.Add(new String[] { "8", "2", "Office 360", "250" });

            table.Rows.Add(new String[] { "9", "1", "Amazon Workmail", "250" });
            table.Rows.Add(new String[] { "10", "9", "Tech", "250" });
            table.Rows.Add(new String[] { "11", "9", "Aims", "250" });
            table.Rows.Add(new String[] { "12", "9", "Forbes", "250" });
            table.Rows.Add(new String[] { "13", "9", "Google Apps", "250" });
            table.Rows.Add(new String[] { "14", "9", "Security", "250" });
            table.Rows.Add(new String[] { "15", "9", "Microsoft Outlock", "250" });

            table.Rows.Add(new String[] { "16", "1", "AWS", "250" });
            table.Rows.Add(new String[] { "17", "16", "EC2", "250" });
            table.Rows.Add(new String[] { "18", "16", "Build", "250" });
            table.Rows.Add(new String[] { "19", "16", "Ibm", "250" });
            table.Rows.Add(new String[] { "20", "16", "Data Center", "250" });
            table.Rows.Add(new String[] { "21", "16", "Exclusive Profile", "250" });
            table.Rows.Add(new String[] { "22", "16", "Workmail", "250" });

            table.Rows.Add(new String[] { "23", "1", "Business", "250" });
            table.Rows.Add(new String[] { "24", "23", "SQL Server", "250" });
            table.Rows.Add(new String[] { "25", "23", "IBM", "250" });
            table.Rows.Add(new String[] { "26", "23", "Data Center", "250" });
            table.Rows.Add(new String[] { "27", "23", "Google Apps", "250" });
            table.Rows.Add(new String[] { "28", "23", "Microsoft Outlock", "250" });
            table.Rows.Add(new String[] { "29", "23", "Workkmail Email", "250" });

            table.Rows.Add(new String[] { "30", "1", "Server", "250" });
            table.Rows.Add(new String[] { "31", "30", "Office 360", "250" });
            table.Rows.Add(new String[] { "32", "30", "Email", "250" });
            table.Rows.Add(new String[] { "33", "30", "Store", "250" });
            table.Rows.Add(new String[] { "34", "30", "Visual Studio", "250" });
            table.Rows.Add(new String[] { "35", "30", "SQL Server", "250" });
            table.Rows.Add(new String[] { "36", "30", "Azure", "250" });


            return table;
        }
        protected void ReachTrendLine()
        {
            var series = new List<ScatterLineSeries>();
            ScatterLineSeries aws = new ScatterLineSeries();
            aws.Name = "DX2015 Dev Cloud AWS";
            aws.LabelsAppearance.Visible = false;
            aws.TooltipsAppearance.ClientTemplate = "#= kendo.format(\"{0:MMM dd}\", new Date(value.x)) #,  #=value.y#";
            aws.TooltipsAppearance.Color = Color.White;
            var awsItems = new List<ScatterSeriesItem>(){
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/28/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,5430775),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/29/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,6445465),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/30/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,2159046),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/31/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,616612),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/01/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,925989),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/02/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1734181),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/03/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1548640),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/04/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,3051457),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/05/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,733088),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/06/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,779072),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/07/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,2467608),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/08/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1673027),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/09/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,947729),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/10/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,795156),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/11/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,3148370),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/12/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,2255397),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/13/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1920386),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/14/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,859256),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/15/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,519667),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/16/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,2303794),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/17/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,2758793),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/18/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,2719440),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/19/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1318816),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/20/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,968502),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/21/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,581645),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/22/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,653231),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/23/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,567872),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/24/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,858228),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/25/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,810447),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/26/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,881998)
            };
            aws.SeriesItems.AddRange(awsItems);
            series.Add(aws);
            ScatterLineSeries azure = new ScatterLineSeries();
            azure.Name = "DX2015 Dev Cloud Azure";
            azure.LabelsAppearance.Visible = false;
            azure.TooltipsAppearance.ClientTemplate = "#= kendo.format(\"{0:MMM dd}\", new Date(value.x)) #,  #=value.y#";
            azure.TooltipsAppearance.Color = Color.White;
            var azureItems = new List<ScatterSeriesItem>(){
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/28/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,886013),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/29/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,698322),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/30/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,308460),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/31/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,160797),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/01/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,330528),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/02/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,503822),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/03/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1144776),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/04/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,2894561),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/05/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1901765),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/06/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,267176),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/07/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1951132),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/08/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,315143),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/09/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1172553),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/10/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,429553),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/11/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,984138),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/12/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,922796),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/13/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,964533),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/14/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,494103),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/15/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,752506),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/16/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,549248),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/17/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1567532),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/18/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,2079808),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/19/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1641879),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/20/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,618082),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/21/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,353351),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/22/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,402355),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/23/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,396835),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/24/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1528301),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/25/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,3464792),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/26/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1717740)
            };
            azure.SeriesItems.AddRange(azureItems);
            series.Add(azure);
            ScatterLineSeries google = new ScatterLineSeries();
            google.Name = "DX2015 Dev Cloud Google";
            google.LabelsAppearance.Visible = false;
            google.TooltipsAppearance.ClientTemplate = "#= kendo.format(\"{0:MMM dd}\", new Date(value.x)) #,  #=value.y#";
            google.TooltipsAppearance.Color = Color.White;
            var googleItems = new List<ScatterSeriesItem>(){
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/28/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,209338),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/29/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,504372),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/30/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,29139),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/31/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,57551),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/01/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,46114),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/02/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,127227),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/03/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,83797),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/04/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,13837),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/05/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,52928),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/06/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,40981),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/07/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,28570),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/08/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,13187),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/09/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,34438),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/10/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,296096),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/11/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,35457),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/12/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,57568),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/13/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,47293),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/14/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,38385),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/15/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,25257),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/16/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,78168),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/17/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,265014),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/18/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,70299),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/19/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,353589),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/20/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,74004),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/21/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,63910),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/22/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,81598),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/23/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,50709),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/24/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,167037),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/25/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,20348),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/26/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,8542),
            };
            google.SeriesItems.AddRange(googleItems);
            series.Add(google);
            ScatterLineSeries vMware = new ScatterLineSeries();
            vMware.Name = "DX2015 Dev Cloud VMware";
            vMware.LabelsAppearance.Visible = false;
            vMware.TooltipsAppearance.ClientTemplate = "#= kendo.format(\"{0:MMM dd}\", new Date(value.x)) #,  #=value.y#";
            vMware.TooltipsAppearance.Color = Color.White;
            var vMwareItems = new List<ScatterSeriesItem>(){
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/28/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,6478),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/29/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,283678),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/30/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,9674),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("01/31/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,50),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/01/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1069),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/02/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,96714),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/03/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,111126),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/04/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,37128),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/05/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,32858),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/06/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,114228),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/07/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1940),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/08/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,6007),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/09/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,8372),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/10/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,4272),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/11/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,2255),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/12/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,85289),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/13/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,19120),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/14/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1332),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/15/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,590),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/16/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,14445),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/17/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,19883),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/18/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,81424),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/19/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,39215),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/20/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,457),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/21/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,187),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/22/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,1409),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/23/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,20940),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/24/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,7479),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/25/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,20739),
                new ScatterSeriesItem((decimal)Convert.ToDateTime("02/26/2015 00:00:00").Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,71307)
            };
            vMware.SeriesItems.AddRange(vMwareItems);
            series.Add(vMware);
            ReachTrend.PlotArea.XAxis.Type = AxisType.Date;
            ReachTrend.PlotArea.YAxis.TitleAppearance.Text = "Reach";
            ReachTrend.PlotArea.XAxis.LabelsAppearance.DataFormatString = "{0:MMM dd}";
            ReachTrend.PlotArea.Series.AddRange(series);
        }

        protected void MentionVolumeBar()
        {
            var serie = new BarSeries();
            serie.Name = "Dev Cloud Compete Mention Volume";
            serie.SeriesItems.AddRange(new List<CategorySeriesItem>(){
                new CategorySeriesItem(){
                Y=31835
                },
                new CategorySeriesItem(){
                Y=15360
                },
                new CategorySeriesItem(){
                Y=2455
                },
                new CategorySeriesItem(){
                Y=645
                }
            });
            serie.LabelsAppearance.Visible = false;
            MentionVolumeChartControl.PlotArea.Series.Add(serie);
            MentionVolumeChartControl.PlotArea.YAxis.TitleAppearance.Text = "Mentions";
            MentionVolumeChartControl.PlotArea.XAxis.Items.AddRange(new List<AxisItem>(){
                new AxisItem(){
                LabelText="DX2015 Dev Cloud AWS"
                },
                new AxisItem(){
                LabelText="DX2015 Dev Cloud Azure"
                },
                new AxisItem(){
                LabelText="DX2015 Dev Cloud Google"
                },
                new AxisItem(){
                LabelText="DX2015 Dev Cloud VMware"
                }
            });

        }

        protected void ReachVolumeBar()
        {
            var serie = new BarSeries();
            serie.Name = "Dev Cloud Compete Reach Volume";
            serie.SeriesItems.AddRange(new List<CategorySeriesItem>(){
                new CategorySeriesItem(){
                Y=52433687
                },
                new CategorySeriesItem(){
                Y=31402600
                },
                new CategorySeriesItem(){
                Y=2974753
                },
                new CategorySeriesItem(){
                Y=1099665
                }
            });
            serie.LabelsAppearance.Visible = false;
            ReachVolume.PlotArea.Series.Add(serie);
            ReachVolume.PlotArea.YAxis.TitleAppearance.Text = "Reach";
            ReachVolume.PlotArea.XAxis.Items.AddRange(new List<AxisItem>(){
                new AxisItem(){
                LabelText="DX2015 Dev Cloud AWS"
                },
                new AxisItem(){
                LabelText="DX2015 Dev Cloud Azure"
                },
                new AxisItem(){
                LabelText="DX2015 Dev Cloud Google"
                },
                new AxisItem(){
                LabelText="DX2015 Dev Cloud VMware"
                }
            });

        }

        protected void TopicSourceBar()
        {
            var series = new List<BarSeries>();
            var twitterSerie = new BarSeries();
            twitterSerie.Name = "Twitter";
            twitterSerie.SeriesItems.AddRange(new List<CategorySeriesItem>(){
                new CategorySeriesItem(){
                Y=16852
                },
                new CategorySeriesItem(){
                Y=9290
                },
                new CategorySeriesItem(){
                Y=1021
                },
                new CategorySeriesItem(){
                Y=454
                }
            });
            twitterSerie.LabelsAppearance.Visible = false;
            twitterSerie.Stacked = true;
            series.Add(twitterSerie);
            var wordSerie = new BarSeries();
            wordSerie.Name = "Wordpress";
            wordSerie.SeriesItems.AddRange(new List<CategorySeriesItem>(){
                new CategorySeriesItem(){
                Y=6813
                },
                new CategorySeriesItem(){
                Y=1055
                },
                new CategorySeriesItem(){
                Y=456
                },
                new CategorySeriesItem(){
                Y=140
                }
            });
            wordSerie.LabelsAppearance.Visible = false;
            wordSerie.Stacked = true;
            series.Add(wordSerie);
            var blogsWebSerie = new BarSeries();
            blogsWebSerie.Name = "Blogs/Websites";
            blogsWebSerie.SeriesItems.AddRange(new List<CategorySeriesItem>(){
                new CategorySeriesItem(){
                Y=4630
                },
                new CategorySeriesItem(){
                Y=2125
                },
                new CategorySeriesItem(){
                Y=0
                },
                new CategorySeriesItem(){
                Y=0
                }
            });
            blogsWebSerie.LabelsAppearance.Visible = false;
            blogsWebSerie.Stacked = true;
            series.Add(blogsWebSerie);
            var faceSerie = new BarSeries();
            faceSerie.Name = "Facebook";
            faceSerie.SeriesItems.AddRange(new List<CategorySeriesItem>(){
                new CategorySeriesItem(){
                Y=2259
                },
                new CategorySeriesItem(){
                Y=1272
                },
                new CategorySeriesItem(){
                Y=655
                },
                new CategorySeriesItem(){
                Y=16
                }
            });
            faceSerie.LabelsAppearance.Visible = false;
            faceSerie.Stacked = true;
            series.Add(faceSerie);
            var forumsSerie = new BarSeries();
            forumsSerie.Name = "Forums";
            forumsSerie.SeriesItems.AddRange(new List<CategorySeriesItem>(){
                new CategorySeriesItem(){
                Y=1074
                },
                new CategorySeriesItem(){
                Y=1516
                },
                new CategorySeriesItem(){
                Y=290
                },
                new CategorySeriesItem(){
                Y=140
                }
            });
            forumsSerie.LabelsAppearance.Visible = false;
            forumsSerie.Stacked = true;
            series.Add(forumsSerie);
            var redditSerie = new BarSeries();
            redditSerie.Name = "Reddit";
            redditSerie.SeriesItems.AddRange(new List<CategorySeriesItem>(){
                new CategorySeriesItem(){
                Y=150
                },
                new CategorySeriesItem(){
                Y=63
                },
                new CategorySeriesItem(){
                Y=25
                },
                new CategorySeriesItem(){
                Y=2
                }
            });
            redditSerie.LabelsAppearance.Visible = false;
            redditSerie.Stacked = true;
            series.Add(redditSerie);
            var googlePlusSerie = new BarSeries();
            googlePlusSerie.Name = "Google Plus";
            googlePlusSerie.SeriesItems.AddRange(new List<CategorySeriesItem>(){
                new CategorySeriesItem(){
                Y=35
                },
                new CategorySeriesItem(){
                Y=28
                },
                new CategorySeriesItem(){
                Y=4
                },
                new CategorySeriesItem(){
                Y=0
                }
            });
            googlePlusSerie.LabelsAppearance.Visible = false;
            googlePlusSerie.Stacked = true;
            series.Add(googlePlusSerie);
            var youtubeSerie = new BarSeries();
            youtubeSerie.Name = "You Tube";
            youtubeSerie.SeriesItems.AddRange(new List<CategorySeriesItem>(){
                new CategorySeriesItem(){
                Y=13
                },
                new CategorySeriesItem(){
                Y=11
                },
                new CategorySeriesItem(){
                Y=4
                },
                new CategorySeriesItem(){
                Y=0
                }
            });
            youtubeSerie.LabelsAppearance.Visible = false;
            youtubeSerie.Stacked = true;
            series.Add(youtubeSerie);
            var instagramSerie = new BarSeries();
            instagramSerie.Name = "Instagram";
            instagramSerie.SeriesItems.AddRange(new List<CategorySeriesItem>(){
                new CategorySeriesItem(){
                Y=9
                },
                new CategorySeriesItem(){
                Y=0
                },
                new CategorySeriesItem(){
                Y=0
                },
                new CategorySeriesItem(){
                Y=0
                }
            });
            instagramSerie.LabelsAppearance.Visible = false;
            instagramSerie.Stacked = true;
            series.Add(instagramSerie);
            TopicSource.PlotArea.Series.AddRange(series);
            TopicSource.PlotArea.YAxis.TitleAppearance.Text = "Mentions";
            TopicSource.PlotArea.XAxis.Items.AddRange(new List<AxisItem>(){
                new AxisItem(){
                LabelText="DX2015 Dev Cloud AWS"
                },
                new AxisItem(){
                LabelText="DX2015 Dev Cloud Azure"
                },
                new AxisItem(){
                LabelText="DX2015 Dev Cloud Google"
                },
                new AxisItem(){
                LabelText="DX2015 Dev Cloud VMware"
                }
            });

        }

        protected void ShareVoicePie()
        {
            var serie = new PieSeries();
            serie.Name = "Share Voice";
            serie.SeriesItems.AddRange(new List<PieSeriesItem>(){
                new PieSeriesItem(){
                    Name="DX2015 Dev Cloud AWS",
                Y=31835
                },
                new PieSeriesItem(){
                    Name="DX2015 Dev Cloud Azure",
                Y=15360
                },
                new PieSeriesItem(){
                    Name="DX2015 Dev Cloud Google",
                Y=2455
                },
                new PieSeriesItem(){
                    Name="DX2015 Dev Cloud VMware",
                Y=645
                }
            });
            serie.LabelsAppearance.Position = PieAndDonutLabelsPosition.OutsideEnd;
            serie.LabelsAppearance.ClientTemplate = "#= category #: #= value # (#=Math.round(percentage * 100)#%)  ";
            ShareVoice.PlotArea.Series.Add(serie);

        }


        protected void ConversationStream(object sender, EventArgs e)
        {
            var conversationStreamPosts = new List<ConversationStreamPost>(){new ConversationStreamPost (){ 
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/TaleTechPRO/statuses/571148113248788480' target='_blank'>TaleTechPRO</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/1125123214/TaleTechPRO-vert_normal.jpg",
            MessagePost = "Visual Studio 2015 スペシャル ツアー ～ RTM に向けて全国セミナー開催します http://t.co/WiGBFZzIxr #TechPro #DevPro #azure #visualstudio2015",
            MessageMinimized ="",
            DatePost = Convert.ToDateTime("02/27/2015 03:21:36")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/SakeNoda/statuses/571147318327554048' target='_blank'>SakeNoda</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/534653367989960704/iMjKYZb6_normal.jpeg",
            MessagePost = "ペルーのお守り牛 アンデスのシーサー 屋根の上から家族を見守ってます☆ http://t.co/RLR6nVsCRv #お守り #ペルー雑貨 #ペルー ペルー雑貨ＡＺＵＲＥ http://t.co/ZGjHoSR7Aw http://t.co/e6RwGdAig9",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 03:18:26")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/gwgm16/statuses/571146621389418497' target='_blank'>gwgm16</a>",
            ProfileImg = "http://abs.twimg.com/sticky/default_profile_images/default_profile_6_normal.png",
            MessagePost = "Exam Ref 70-487 Developing Windows Azure and Web Services (MCSD) http://t.co/n2i2Du5NRf 2224 http://t.co/VNKio3mhpM",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 03:15:40")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/jwarner_tx/statuses/571146550279172096' target='_blank'>jwarner_tx</a>",
            ProfileImg = "http://abs.twimg.com/sticky/default_profile_images/default_profile_2_normal.png",
            MessagePost = "New Links for Windows Server, Hyper-V, Azure, vNext http://t.co/UtJjaeE4Qs",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 03:15:23")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/sbykov_work/statuses/571143973328199680' target='_blank'>sbykov_work</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/498554653127479296/Tpj_vuT4_normal.jpeg",
            MessagePost = ".NET is not the only serious OS project at MSFT: the Roslyn compiler, F#, the Azure SDKs, TypeScript, TouchDevelop, Project Orleans, Bond",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 03:05:09")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='https://twitter.com/show/status/571142559474589696' target='_blank'>ZohraTech</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/555061879911882752/Gyw0cDPq_normal.jpeg",
            MessagePost = "﻿Storage for Body Camera Video #CJIS capable #Cloud solution for #government on #Azure   http://t.co/5upKQo2yIU",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 02:59:32")
            },
            new ConversationStreamPost(){
            SocialNetwork = "WORDPRESS",
            ScreenName = "<a href='http://justthunkit.com/2015/02/27/could-flipkarts-big-billion-day-fiasco-been-avoided/' target='_blank'>Jose Gauravselvam Kagoo</a>",
            ProfileImg = "",
            MessagePost = "Indian online shoppers who remember the aftermath of the 'Big Billion Day' would recall how Flipkart apologized for the glitches by blaming their improper planning on sufficient number of servers. I really wonder if Flipkart missed a trick.Was Flipkart unaware of the on-demand provisioning of servers feature available in Amazon Web Services (AWS) or Microsoft Azure? If Flipkart was not aware of these services,they need a serious re-think on the technological front. Also Read <a title='Flipkart’s “The Billion Day” is more than a Million Dollar Idea' href='http://justthunkit.com/2014/10/07/flipkarts-the-billion-day-is-more-than-a-million-dollar-idea/'><strong>Flipkart’s “The Billion Day” is more than a Million Dollar Idea</strong></a>",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 02:49:22")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/AdnanCartwright/statuses/571139578599485440' target='_blank'>AdnanCartwright</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/482478405342871552/h9VqwUlY_normal.jpeg",
            MessagePost = "Amazon Web Services leads, but Microsoft Azure catching up - http://t.co/AoAOt78Sv1... http://t.co/zmjnG0fjMb",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 02:47:41")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='https://twitter.com/show/status/571139449528197120' target='_blank'>OpenSourceAgent</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/415003820775583744/i7qsaArp_normal.jpeg",
            MessagePost = "Microsoft Ups Open Source Ante on Azure Data Services - Visual Studio Magazine http://t.co/5wA6mggOIU #opensource",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 02:47:10")
            },};
            foreach (var conversationStreamPost in conversationStreamPosts)
            {
                if (conversationStreamPost.MessagePost.Length > 150)
                {
                    conversationStreamPost.MessageMinimized = conversationStreamPost.MessagePost.Substring(0, 250) + " <a href='#' class='displayMore' onclick='ShowMore(this)' >... Show More</a>";
                    conversationStreamPost.MessagePost += " <a href='#' class='displayLess' onclick='ShowLess(this)' >Show less</a>";
                }
                else
                {
                    conversationStreamPost.MessageMinimized = conversationStreamPost.MessagePost;
                }
            }
            currentConversation = conversationStreamPosts;
            RadListView1.DataSource = currentConversation;
            RadListView1.Rebind();
        }

        public void UpdateConversationStream(object sender, EventArgs e)
        {
            var conversationStreamPosts = new List<ConversationStreamPost>(){new ConversationStreamPost (){ 
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/TaleTechPRO/statuses/571148113248788480' target='_blank'>TaleTechPRO</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/1125123214/TaleTechPRO-vert_normal.jpg",
            MessagePost = "Visual Studio 2015 スペシャル ツアー ～ RTM に向けて全国セミナー開催します http://t.co/WiGBFZzIxr #TechPro #DevPro #azure #visualstudio2015",
            MessageMinimized ="",
            DatePost = Convert.ToDateTime("02/27/2015 03:21:36")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/SakeNoda/statuses/571147318327554048' target='_blank'>SakeNoda</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/534653367989960704/iMjKYZb6_normal.jpeg",
            MessagePost = "ペルーのお守り牛 アンデスのシーサー 屋根の上から家族を見守ってます☆ http://t.co/RLR6nVsCRv #お守り #ペルー雑貨 #ペルー ペルー雑貨ＡＺＵＲＥ http://t.co/ZGjHoSR7Aw http://t.co/e6RwGdAig9",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 03:18:26")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/gwgm16/statuses/571146621389418497' target='_blank'>gwgm16</a>",
            ProfileImg = "http://abs.twimg.com/sticky/default_profile_images/default_profile_6_normal.png",
            MessagePost = "Exam Ref 70-487 Developing Windows Azure and Web Services (MCSD) http://t.co/n2i2Du5NRf 2224 http://t.co/VNKio3mhpM",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 03:15:40")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/jwarner_tx/statuses/571146550279172096' target='_blank'>jwarner_tx</a>",
            ProfileImg = "http://abs.twimg.com/sticky/default_profile_images/default_profile_2_normal.png",
            MessagePost = "New Links for Windows Server, Hyper-V, Azure, vNext http://t.co/UtJjaeE4Qs",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 03:15:23")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/sbykov_work/statuses/571143973328199680' target='_blank'>sbykov_work</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/498554653127479296/Tpj_vuT4_normal.jpeg",
            MessagePost = ".NET is not the only serious OS project at MSFT: the Roslyn compiler, F#, the Azure SDKs, TypeScript, TouchDevelop, Project Orleans, Bond",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 03:05:09")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='https://twitter.com/show/status/571142559474589696' target='_blank'>ZohraTech</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/555061879911882752/Gyw0cDPq_normal.jpeg",
            MessagePost = "﻿Storage for Body Camera Video #CJIS capable #Cloud solution for #government on #Azure   http://t.co/5upKQo2yIU",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 02:59:32")
            },
            new ConversationStreamPost(){
            SocialNetwork = "WORDPRESS",
            ScreenName = "<a href='http://justthunkit.com/2015/02/27/could-flipkarts-big-billion-day-fiasco-been-avoided/' target='_blank'>Jose Gauravselvam Kagoo</a>",
            ProfileImg = "",
            MessagePost = "Indian online shoppers who remember the aftermath of the 'Big Billion Day' would recall how Flipkart apologized for the glitches by blaming their improper planning on sufficient number of servers. I really wonder if Flipkart missed a trick.Was Flipkart unaware of the on-demand provisioning of servers feature available in Amazon Web Services (AWS) or Microsoft Azure? If Flipkart was not aware of these services,they need a serious re-think on the technological front. Also Read <a title='Flipkart’s “The Billion Day” is more than a Million Dollar Idea' href='http://justthunkit.com/2014/10/07/flipkarts-the-billion-day-is-more-than-a-million-dollar-idea/'><strong>Flipkart’s “The Billion Day” is more than a Million Dollar Idea</strong></a>",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 02:49:22")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='http://twitter.com/AdnanCartwright/statuses/571139578599485440' target='_blank'>AdnanCartwright</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/482478405342871552/h9VqwUlY_normal.jpeg",
            MessagePost = "Amazon Web Services leads, but Microsoft Azure catching up - http://t.co/AoAOt78Sv1... http://t.co/zmjnG0fjMb",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 02:47:41")
            },
            new ConversationStreamPost(){
            SocialNetwork = "TWITTER",
            ScreenName = "<a href='https://twitter.com/show/status/571139449528197120' target='_blank'>OpenSourceAgent</a>",
            ProfileImg = "http://pbs.twimg.com/profile_images/415003820775583744/i7qsaArp_normal.jpeg",
            MessagePost = "Microsoft Ups Open Source Ante on Azure Data Services - Visual Studio Magazine http://t.co/5wA6mggOIU #opensource",
            MessageMinimized = "",
            DatePost = Convert.ToDateTime("02/27/2015 02:47:10")
            },};
            foreach (var conversationStreamPost in conversationStreamPosts)
            {
                if (conversationStreamPost.MessagePost.Length > 150)
                {
                    conversationStreamPost.MessageMinimized = conversationStreamPost.MessagePost.Substring(0, 250) + " <a href='#' class='displayMore' onclick='ShowMore(this)' >... Show More</a>";
                    conversationStreamPost.MessagePost += " <a href='#' class='displayLess' onclick='ShowLess(this)' >Show less</a>";
                }
                else
                {
                    conversationStreamPost.MessageMinimized = conversationStreamPost.MessagePost;
                }
            }
            currentConversation.AddRange(conversationStreamPosts);
            RadListView1.DataSource = currentConversation;
            RadListView1.Rebind();
        }




    }
}