<%@ Page Title="" Language="C#" MasterPageFile="../masterpages/Main.Master" AutoEventWireup="true" CodeBehind="MainGus.aspx.cs" Inherits="SmartSocial.Web.masterpages.MainGus" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style>
        .maximized {
            display: none;
        }
        .rwWindowContent > div {
            overflow-x: hidden !important;
        }
    </style>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server"></telerik:RadAjaxManagerProxy>
    <telerik:RadClientExportManager ID="RadClientExportManager1" runat="server" RenderMode="Classic">
        <PdfSettings  MarginTop="20mm" MarginLeft="20mm" Title="Chart" Landscape="true" FileName="Exported Chart" Creator="Smart Social Reporting" />
    </telerik:RadClientExportManager>
    <div id="ReportHeader" style="background-color:#e9f2f6; width:100%;padding:15px; display:block;">


                        <div style="text-align: left; height: 40px; color: #000;">
                             <div style="float:left; width:570px">
                                <div style="float: left; margin-right: 5px;">
                                    <img style="height: 40px; width: 40px" src="../Images/niccage.jpg" />
                                </div>
                                <div style="float: left; width: 170px;">
                                    Report Customer:<br />
                                    <span style="font-size: 100%; font-weight: bold">Nicolas Cage</span>
                                </div>
                            
                                <div style="float: left; width: 170px;">
                                    Analysis Period:<br />
                                    <span style="font-size: 100%; font-weight: bold">1/26/2015 - 2/26/2015</span>
                                </div>
                                
                                <div style="float: left; width: 170px;">
                                    Social Report Name:<br />
                                    <span style="font-size: 100%; font-weight: bold">Competitors Report</span>
                                </div>
                            </div>
                            <div style="float: right;">
                                <telerik:RadMenu ID="RadMenu1" runat="server" Skin="Default" ClickToOpen="False" OnClientItemClicked="MenuClicked">
                                    <Items>
                                        <telerik:RadMenuItem EnableImageSprite="true" Value="MainContainer" ImageUrl="../images/menubutton32.png">
                                            <Items>
                                                <telerik:RadMenuItem Value="PDF" Text="Export Report to PDF" EnableImageSprite="true" ImageUrl="http://icons.iconarchive.com/icons/hopstarter/soft-scraps/16/Adobe-PDF-Document-icon.png"></telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Export Report to Excel" EnableImageSprite="true" ImageUrl="http://icons.iconarchive.com/icons/ncrow/mega-pack-1/16/Excel-icon.png"></telerik:RadMenuItem>
                                                <telerik:RadMenuItem Text="Report Settings" EnableImageSprite="true" ImageUrl="http://icons.iconarchive.com/icons/hopstarter/soft-scraps/16/Gear-icon.png"></telerik:RadMenuItem>
                                            </Items>
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadMenu>
                            </div>
                             
                        </div>
    </div>        
    <div id="MainContainer" class="container"">
            <!-- Projects Row -->
        <div class="row" style="display:none">
            <div class="col-lg-12" style="margin-top:30px;"><strong>KPI</strong>
            </div>
        </div>
        <div class="row">
            <div id="FirstDiv" class="col-lg-6 SmartChartDivContainer">
                <div style="width:100%; height:450px; border:solid 1px black;" >
                    <div style="width:100%; height:35px; border-bottom:solid 1px black;">
                        <div style="float:left;padding:7px;font-weight:bold;">Volume Trendline</div>
                        <div style="float:right;height:35px;width:35px;border-left:solid 1px black;">                            
                            <telerik:RadMenu runat="server" ClickToOpen="False" Skin="Default" OnClientItemClicked="MenuClicked">
                                <Items>
                                    <telerik:RadMenuItem EnableImageSprite="true" Value="VolumeTrendlineChartControl" ImageUrl="../images/menubutton32.png">
                                        <Items>
                                            <telerik:RadMenuItem Text="View as Chart"  ImageUrl="http://icons.iconarchive.com/icons/iconshock/real-vista-text/16/chart-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="View as Data Table" ImageUrl="http://icons.iconarchive.com/icons/yusuke-kamiyamane/fugue/16/table-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to Excel" ImageUrl="http://icons.iconarchive.com/icons/ncrow/mega-pack-1/16/Excel-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Value="PDF" Text="Export to PDF" ImageUrl="http://icons.iconarchive.com/icons/hopstarter/soft-scraps/16/Adobe-PDF-Document-icon.png">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenu>
                        </div>
                    </div>
                    <div style="width:100%; height:415px; padding:10px">

                        <telerik:RadHtmlChart runat="server" ID="VolumeTrendlineChartControl" ClientIDMode="Static">
                            <Legend>
                                <Appearance BackgroundColor="White" Position="Bottom">
                                </Appearance>
                            </Legend>
                        </telerik:RadHtmlChart>

                    </div>
                </div>

            </div>
            <div class="col-lg-6 SmartChartDivContainer">
                <div style="width:100%; height:450px; border:solid 1px black;" >
                    <div style="width:100%; height:35px; border-bottom:solid 1px black;">
                        <div style="float:left;padding:7px;font-weight:bold;">Mention Volume</div>
                        <div style="float:right;height:35px;width:35px;border-left:solid 1px black;">                            
                            <telerik:RadMenu runat="server" ClickToOpen="False" Skin="Default" OnClientItemClicked="MenuClicked">
                                <Items>
                                    <telerik:RadMenuItem EnableImageSprite="true" Value="MentionVolumeChartControl" ImageUrl="../images/menubutton32.png">
                                        <Items>
                                            <telerik:RadMenuItem Text="View as Chart" ImageUrl="http://icons.iconarchive.com/icons/iconshock/real-vista-text/16/chart-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="View as Data Table" ImageUrl="http://icons.iconarchive.com/icons/yusuke-kamiyamane/fugue/16/table-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to Excel" ImageUrl="http://icons.iconarchive.com/icons/ncrow/mega-pack-1/16/Excel-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Value="PDF" Text="Export to PDF" ImageUrl="http://icons.iconarchive.com/icons/hopstarter/soft-scraps/16/Adobe-PDF-Document-icon.png">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenu>
                        </div>
                    </div>
                    <div style="width:100%; height:415px; padding:10px">

                        <telerik:RadHtmlChart runat="server" ID="MentionVolumeChartControl" ClientIDMode="Static" >
                            <Legend>
                                <Appearance BackgroundColor="White" Position="Bottom">
                                </Appearance>
                            </Legend>
                        </telerik:RadHtmlChart>

                    </div>
                </div>

            </div>
        </div>
        <!-- /.row -->

        <!-- Projects Row -->
        <div class="row">
            <div class="col-lg-6 SmartChartDivContainer">
                <div style="width:100%; height:450px; border:solid 1px black;" >
                    <div style="width:100%; height:35px; border-bottom:solid 1px black;">
                        <div style="float:left;padding:7px;font-weight:bold;">Reach Trend</div>
                        <div style="float:right;height:35px;width:35px;border-left:solid 1px black;">                            
                            <telerik:RadMenu runat="server" ClickToOpen="False" Skin="Default" OnClientItemClicked="MenuClicked">
                                <Items>
                                    <telerik:RadMenuItem EnableImageSprite="true" Value="ReachTrend" ImageUrl="../images/menubutton32.png">
                                        <Items>
                                            <telerik:RadMenuItem Text="View as Chart" ImageUrl="http://icons.iconarchive.com/icons/iconshock/real-vista-text/16/chart-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="View as Data Table" ImageUrl="http://icons.iconarchive.com/icons/yusuke-kamiyamane/fugue/16/table-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to Excel" ImageUrl="http://icons.iconarchive.com/icons/ncrow/mega-pack-1/16/Excel-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to PDF" Value="PDF" ImageUrl="http://icons.iconarchive.com/icons/hopstarter/soft-scraps/16/Adobe-PDF-Document-icon.png">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenu>
                        </div>
                    </div>
                    <div style="width:100%; height:415px; padding:10px">

                        <telerik:RadHtmlChart runat="server" ID="ReachTrend" ClientIDMode="Static">
                            <Legend>
                                <Appearance BackgroundColor="White" Position="Bottom">
                                </Appearance>
                            </Legend>
                        </telerik:RadHtmlChart>

                    </div>
                </div>

            </div>
            <div class="col-lg-6 SmartChartDivContainer">
                <div style="width:100%; height:450px; border:solid 1px black;" >
                    <div style="width:100%; height:35px; border-bottom:solid 1px black;">
                        <div style="float:left;padding:7px;font-weight:bold;">Reach Volume</div>
                        <div style="float:right;height:35px;width:35px;border-left:solid 1px black;">                            
                            <telerik:RadMenu runat="server" ClickToOpen="False" Skin="Default" OnClientItemClicked="MenuClicked">
                                <Items>
                                    <telerik:RadMenuItem EnableImageSprite="true" Value="ReachVolume" ImageUrl="../images/menubutton32.png">
                                        <Items>
                                            <telerik:RadMenuItem Text="View as Chart" ImageUrl="http://icons.iconarchive.com/icons/iconshock/real-vista-text/16/chart-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="View as Data Table" ImageUrl="http://icons.iconarchive.com/icons/yusuke-kamiyamane/fugue/16/table-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to Excel" ImageUrl="http://icons.iconarchive.com/icons/ncrow/mega-pack-1/16/Excel-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to PDF" Value="PDF" ImageUrl="http://icons.iconarchive.com/icons/hopstarter/soft-scraps/16/Adobe-PDF-Document-icon.png">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenu>
                        </div>
                    </div>
                    <div style="width:100%; height:415px; padding:10px">

                        <telerik:RadHtmlChart runat="server" ID="ReachVolume" ClientIDMode="Static">
                            <Legend>
                                <Appearance BackgroundColor="White" Position="Bottom">
                                </Appearance>
                            </Legend>
                        </telerik:RadHtmlChart>

                    </div>
                </div>

            </div>
        </div>
        <!-- /.row -->

        <!-- Projects Row -->
        <div class="row">
            <div class="col-lg-6 SmartChartDivContainer">
                <div style="width:100%; height:450px; border:solid 1px black;" >
                    <div style="width:100%; height:35px; border-bottom:solid 1px black;">
                        <div style="float:left;padding:7px;font-weight:bold;">Share of Voice</div>
                        <div style="float:right;height:35px;width:35px;border-left:solid 1px black;">                            
                            <telerik:RadMenu runat="server" ClickToOpen="False" Skin="Default" OnClientItemClicked="MenuClicked">
                                <Items>
                                    <telerik:RadMenuItem EnableImageSprite="true" Value="ShareVoice" ImageUrl="../images/menubutton32.png">
                                        <Items>
                                            <telerik:RadMenuItem Text="View as Chart" ImageUrl="http://icons.iconarchive.com/icons/iconshock/real-vista-text/16/chart-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="View as Data Table" ImageUrl="http://icons.iconarchive.com/icons/yusuke-kamiyamane/fugue/16/table-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to Excel" ImageUrl="http://icons.iconarchive.com/icons/ncrow/mega-pack-1/16/Excel-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to PDF" Value="PDF" ImageUrl="http://icons.iconarchive.com/icons/hopstarter/soft-scraps/16/Adobe-PDF-Document-icon.png">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenu>
                        </div>
                    </div>
                    <div style="width:100%; height:415px; padding:10px">

                       <telerik:RadHtmlChart runat="server" ID="ShareVoice" ClientIDMode="Static">
                            <Legend>
                                <Appearance BackgroundColor="White" Position="Bottom">
                                </Appearance>
                            </Legend>
                        </telerik:RadHtmlChart>

                    </div>
                </div>

            </div>
            <div class="col-lg-6 SmartChartDivContainer">
                <div style="width:100%; height:450px; border:solid 1px black;" >
                    <div style="width:100%; height:35px; border-bottom:solid 1px black;">
                        <div style="float:left;padding:7px;font-weight:bold;">Topic Source</div>
                        <div style="float:right;height:35px;width:35px;border-left:solid 1px black;">                            
                            <telerik:RadMenu runat="server" ClickToOpen="False" Skin="Default" OnClientItemClicked="MenuClicked">
                                <Items>
                                    <telerik:RadMenuItem EnableImageSprite="true" Value="TopicSource" ImageUrl="../images/menubutton32.png">
                                        <Items>
                                            <telerik:RadMenuItem Text="View as Chart" ImageUrl="http://icons.iconarchive.com/icons/iconshock/real-vista-text/16/chart-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="View as Data Table" ImageUrl="http://icons.iconarchive.com/icons/yusuke-kamiyamane/fugue/16/table-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to Excel" ImageUrl="http://icons.iconarchive.com/icons/ncrow/mega-pack-1/16/Excel-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to PDF" Value="PDF" ImageUrl="http://icons.iconarchive.com/icons/hopstarter/soft-scraps/16/Adobe-PDF-Document-icon.png">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenu>
                        </div>
                    </div>
                    <div style="width:100%; height:415px; padding:10px">

                        <telerik:RadHtmlChart runat="server" ID="TopicSource" ClientIDMode="Static">
                            <Legend>
                                <Appearance BackgroundColor="White" Position="Bottom">
                                </Appearance>
                            </Legend>
                        </telerik:RadHtmlChart>

                    </div>
                </div>

            </div>
        </div>
            <!-- /.row -->


            <!-- Projects Row -->
        <div class="row">
            <div class="col-lg-6 SmartChartDivContainer">
                <div style="width:100%; height:450px; border:solid 1px black;" >
                    <div style="width:100%; height:35px; border-bottom:solid 1px black;">
                        <div style="float:left;padding:7px;font-weight:bold;">Topic Analysis</div>
                        <div style="float:right;height:35px;width:35px;border-left:solid 1px black;">                            
                            <telerik:RadMenu runat="server" ClickToOpen="False" Skin="Default" OnClientItemClicked="MenuClicked">
                                <Items>
                                    <telerik:RadMenuItem EnableImageSprite="true" Value="RadTreeMap1" ImageUrl="../images/menubutton32.png">
                                        <Items>
                                            <telerik:RadMenuItem Text="View as Chart" ImageUrl="http://icons.iconarchive.com/icons/iconshock/real-vista-text/16/chart-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="View as Data Table" ImageUrl="http://icons.iconarchive.com/icons/yusuke-kamiyamane/fugue/16/table-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to Excel" ImageUrl="http://icons.iconarchive.com/icons/ncrow/mega-pack-1/16/Excel-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to PDF" Value="PDF" ImageUrl="http://icons.iconarchive.com/icons/hopstarter/soft-scraps/16/Adobe-PDF-Document-icon.png">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenu>
                        </div>
                    </div>
                    <div style="width:100%; height:415px; padding:10px; text-align:center;">
                        <telerik:RadTreeMap ID="RadTreeMap1" ClientIDMode="Static" AlgorithmType="Squarified" runat="server" Width="500" Font-Bold="true"></telerik:RadTreeMap>
                        
                    </div>
                </div>

            </div>
            <div class="col-lg-6 SmartChartDivContainer">
                <div style="width:100%; height:450px; border:solid 1px black;" >
                    <div style="width:100%; height:35px; border-bottom:solid 1px black;">
                        <div style="float:left;padding:7px;font-weight:bold;">Word Cloud</div>
                        <div style="float:right;height:35px;width:35px;border-left:solid 1px black;">                            
                            <telerik:RadMenu runat="server" ClickToOpen="False" Skin="Default" OnClientItemClicked="MenuClicked">
                                <Items>
                                    <telerik:RadMenuItem EnableImageSprite="true" Value="WordCloud" ImageUrl="../images/menubutton32.png">
                                        <Items>
                                            <telerik:RadMenuItem Text="View as Chart" ImageUrl="http://icons.iconarchive.com/icons/iconshock/real-vista-text/16/chart-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="View as Data Table" ImageUrl="http://icons.iconarchive.com/icons/yusuke-kamiyamane/fugue/16/table-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to Excel" ImageUrl="http://icons.iconarchive.com/icons/ncrow/mega-pack-1/16/Excel-icon.png">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="Export to PDF" Value="PDF" ImageUrl="http://icons.iconarchive.com/icons/hopstarter/soft-scraps/16/Adobe-PDF-Document-icon.png">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenuItem>
                                </Items>
                            </telerik:RadMenu>
                        </div>
                    </div>
                    <div style="width:100%; height:415px; padding:10px">

                       
                        <telerik:RadTagCloud ID="WordCloud" runat="server" ClientIDMode="Static" OnClientItemClicked="ConversationStreamWordCloud"  MinFontSize="10px" BorderWidth="0px" MaxFontSize="35px" MinColor="#00def4" MaxColor="#0000a4" Sorting="AlphabeticAsc" Height="100%">
                            <Items>
                                <telerik:RadTagCloudItem Text="Web" Weight="20638" />
                                <telerik:RadTagCloudItem Text="services" Weight="19293" />
                                <telerik:RadTagCloudItem Text="amazon" Weight="18493" />
                                <telerik:RadTagCloudItem Text="cloud" Weight="13746" />
                                <telerik:RadTagCloudItem Text="azure" Weight="8251" />
                                <telerik:RadTagCloudItem Text="server" Weight="7583" />
                                <telerik:RadTagCloudItem Text="business" Weight="7353" />
                                <telerik:RadTagCloudItem Text="aws" Weight="6647" />
                                <telerik:RadTagCloudItem Text="technology" Weight="6309" />
                                <telerik:RadTagCloudItem Text="solutions" Weight="5612" />
                                <telerik:RadTagCloudItem Text="check" Weight="5082" />
                                <telerik:RadTagCloudItem Text="service" Weight="4776" />
                                <telerik:RadTagCloudItem Text="microsoft" Weight="4677" />
                                <telerik:RadTagCloudItem Text="conference" Weight="4439" />
                                <telerik:RadTagCloudItem Text="google" Weight="4317" />
                                <telerik:RadTagCloudItem Text="27" Weight="4088" />
                                <telerik:RadTagCloudItem Text="discussing" Weight="3984" />
                                <telerik:RadTagCloudItem Text="absolute" Weight="3970" />
                                <telerik:RadTagCloudItem Text="transformation" Weight="3968" />
                                <telerik:RadTagCloudItem Text="tony" Weight="3890" />
                                <telerik:RadTagCloudItem Text="2557" Weight="3874" />
                                <telerik:RadTagCloudItem Text="awsamazon" Weight="3874" />
                                <telerik:RadTagCloudItem Text="willem" Weight="3832" />
                                <telerik:RadTagCloudItem Text="ผูใหบริการ" Weight="3832" />
                                <telerik:RadTagCloudItem Text="สิงหาคม" Weight="3832" />
                                <telerik:RadTagCloudItem Text="เวลา" Weight="3832" />
                                <telerik:RadTagCloudItem Text="แก" Weight="3832" />
                                <telerik:RadTagCloudItem Text="ในวันที" Weight="3832" />
                                <telerik:RadTagCloudItem Text="ไดจัดงานสัมนา" Weight="3832" />
                                <telerik:RadTagCloudItem Text="api" Weight="3519" />
                                <telerik:RadTagCloudItem Text="service" Weight="3533" />
                                <telerik:RadTagCloudItem Text="development" Weight="3393" />
                                <telerik:RadTagCloudItem Text="software" Weight="3302" />
                                <telerik:RadTagCloudItem Text="platform" Weight="3165" />
                                <telerik:RadTagCloudItem Text="years" Weight="3050" />
                                <telerik:RadTagCloudItem Text="experience" Weight="2933" />
                                <telerik:RadTagCloudItem Text="working" Weight="2871" />
                                <telerik:RadTagCloudItem Text="work" Weight="2850" />
                                <telerik:RadTagCloudItem Text="management" Weight="2757" />
                                <telerik:RadTagCloudItem Text="#aws" Weight="2752" />
                                <telerik:RadTagCloudItem Text="applications" Weight="2684" />
                                <telerik:RadTagCloudItem Text="windows" Weight="2652" />
                                <telerik:RadTagCloudItem Text="net" Weight="2635" />
                                <telerik:RadTagCloudItem Text="application" Weight="2598" />
                                <telerik:RadTagCloudItem Text="time" Weight="2562" />
                                <telerik:RadTagCloudItem Text="company" Weight="2543" />
                                <telerik:RadTagCloudItem Text="html" Weight="2374" />
                                <telerik:RadTagCloudItem Text="#cloudcomputing" Weight="2324" />
                                <telerik:RadTagCloudItem Text="big" Weight="2320" />
                                <telerik:RadTagCloudItem Text="customers" Weight="2320" />
                                <telerik:RadTagCloudItem Text="tools" Weight="2261" />
                                <telerik:RadTagCloudItem Text="technologies" Weight="2163" />
                                <telerik:RadTagCloudItem Text="security" Weight="2162" />
                                <telerik:RadTagCloudItem Text="support" Weight="2118" />
                                <telerik:RadTagCloudItem Text="build" Weight="2096" />
                                <telerik:RadTagCloudItem Text="internet" Weight="2058" />
                                <telerik:RadTagCloudItem Text="access" Weight="2046" />
                                <telerik:RadTagCloudItem Text="infrastructure" Weight="2041" />
                                <telerik:RadTagCloudItem Text="public" Weight="2032" />
                                <telerik:RadTagCloudItem Text="code" Weight="2003" />
                                <telerik:RadTagCloudItem Text="developer" Weight="1975" />
                                <telerik:RadTagCloudItem Text="team" Weight="1975" />
                                <telerik:RadTagCloudItem Text="good" Weight="1962" />
                                <telerik:RadTagCloudItem Text="javascript" Weight="1961" />
                                <telerik:RadTagCloudItem Text="create" Weight="1959" />
                                <telerik:RadTagCloudItem Text="2015" Weight="1949" />
                                <telerik:RadTagCloudItem Text="platforms" Weight="1915" />
                                <telerik:RadTagCloudItem Text="#azure" Weight="1913" />
                                <telerik:RadTagCloudItem Text="building" Weight="1911" />
                                <telerik:RadTagCloudItem Text="skills" Weight="1900" />
                                <telerik:RadTagCloudItem Text="mobile" Weight="1896" />
                                <telerik:RadTagCloudItem Text="key" Weight="1890" />
                                <telerik:RadTagCloudItem Text="users" Weight="1890" />
                                <telerik:RadTagCloudItem Text="today" Weight="1869" />
                                <telerik:RadTagCloudItem Text="apps" Weight="1798" />
                                <telerik:RadTagCloudItem Text="problem" Weight="1798" />
                                <telerik:RadTagCloudItem Text="set" Weight="1790" />
                                <telerik:RadTagCloudItem Text="storage" Weight="1789" />
                                <telerik:RadTagCloudItem Text="#cloud" Weight="1753" />
                                <telerik:RadTagCloudItem Text="דרישות" Weight="1749" />
                                <telerik:RadTagCloudItem Text="התפקיד" Weight="1749" />
                                <telerik:RadTagCloudItem Text="מיקום" Weight="1749" />
                                <telerik:RadTagCloudItem Text="running" Weight="1747" />
                                <telerik:RadTagCloudItem Text="project" Weight="1714" />
                                <telerik:RadTagCloudItem Text="post" Weight="1690" />
                                <telerik:RadTagCloudItem Text="sql" Weight="1679" />
                                <telerik:RadTagCloudItem Text="source" Weight="1667" />
                                <telerik:RadTagCloudItem Text="enterprise" Weight="1659" />
                                <telerik:RadTagCloudItem Text="open" Weight="1639" />
                                <telerik:RadTagCloudItem Text="linux" Weight="1629" />
                                <telerik:RadTagCloudItem Text="test" Weight="1628" />
                                <telerik:RadTagCloudItem Text="computing" Weight="1626" />
                                <telerik:RadTagCloudItem Text="ability" Weight="1620" />
                                <telerik:RadTagCloudItem Text="managing" Weight="1565" />
                                <telerik:RadTagCloudItem Text="studio" Weight="1550" />
                                <telerik:RadTagCloudItem Text="design" Weight="1548" />
                                <telerik:RadTagCloudItem Text="things" Weight="1547" />
                                <telerik:RadTagCloudItem Text="visual" Weight="1547" />
                                <telerik:RadTagCloudItem Text="java" Weight="1525" />
                                <telerik:RadTagCloudItem Text="rest" Weight="1504" />
                            </Items>
                        </telerik:RadTagCloud>
                         

                    </div>
                </div>

            </div>
            <!-- /.row -->
        </div>
   </div> 



    <telerik:RadWindowManager ID="RadWindowManager2" runat="server" EnableShadow="true"
        ShowContentDuringLoad="false" Behaviors="Resize,Move,Close" Skin="Silk" Height="550" Width="650" Style="z-index: 7001" ReloadOnShow="true" OnClientShow="AddScrollEvent" DestroyOnClose="true">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Title="Conversation Stream" Modal="false" OnLoad="ConversationStream">
                <ContentTemplate>
                    <telerik:RadListView ID="RadListView1" runat="server">
                        <ItemTemplate>
                            <fieldset class="itemFieldset">
                                <table>
                                    <tr>
                                        <td class="contactPhoto" style="min-width: 50px; padding-top: 0px">
                                            <img src="<%#Eval("ProfileImg")%>" />
                                        </td>
                                        <td>
                                            <div class="row-fluid">
                                                <div class="col-sm-6" style="font-weight: bolder;">
                                                    <%#Eval("ScreenName")%>
                                                </div>
                                                <div class="col-sm-6" style="font-weight: bolder;">
                                                    <%#Eval("DatePost")%>
                                                </div>
                                                <div class="col-sm-12 messageContainer">
                                                    <div class="minimized">
                                                        <%#Eval("MessageMinimized")%>
                                                    </div>
                                                    <div class="maximized">
                                                        <%#Eval("MessagePost")%>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </ItemTemplate>
                    </telerik:RadListView>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <script type="text/javascript">
        function ConversationStreamOpen() {
            var wnd = $find("<%=RadWindow1.ClientID%>");
            wnd.show()
        }

        function ConversationStreamWordCloud(sender, args) {
            var wnd = $find("<%=RadWindow1.ClientID%>");
            if (wnd != null) {
                wnd.show()
            }
        }

        function AddScrollEvent(sender, args) {
            var wndContent = $($find("<%=RadWindow1.ClientID%>")._contentElement);
            wndContent.on("scroll", function () {
                if (wndContent.scrollTop() == (wndContent.prop('scrollHeight') - wndContent.height())) {
                    //TODO connect to the server to load more conversations
                    //var btn = $("#=Button1.ClientID%>")
                    //btn.trigger("click");
                }
            });
        }

        function ShowLess(link) {
            var textToDisplay = $(link).closest(".messageContainer").find(".minimized");
            var textToHide = $(link).closest(".maximized");
            textToHide.hide();
            textToDisplay.show();
        }

        function ShowMore(link) {
            var textToDisplay = $(link).closest(".messageContainer").find(".maximized");
            var textToHide = $(link).closest(".minimized");
            textToHide.hide();
            textToDisplay.show();
        }

        function exportPDF(theClientId) {
            //Exports the Chart linked to the clicked Menu by the Parent Item Value. to PDF
            $find('<%=RadClientExportManager1.ClientID %>').exportPDF($telerik.$(theClientId));
        }

        function MenuClicked(sender, args) {
            
            var itemValue = args.get_item().get_value();
            
            if (itemValue == "PDF") {
                sender.close(true);
                //The clicked item parent has the Chart's client id as Value
                exportPDF('#' + args.get_item().get_parent().get_value());
                
            }
            
        }
        
    </script>
    
</asp:Content>
