<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChartBaseTesting.ascx.cs" Inherits="SmartSocial.Web.controls.ucChartBase" %>
<link href="../Content/smartsocialstyle.css" rel="stylesheet" />

<div class="ChartOutterDiv" >
    <div class="ChartHeaderDiv">
        <div class="HeaderTextDiv">CHART NAME</div>
        <div class="HeaderMenuDiv">                            
            <telerik:RadMenu ID="MenuID" runat="server" ClickToOpen="True" Skin="Default">
                <Items>
                    <telerik:RadMenuItem runat="server" EnableImageSprite="true" ImageUrl="../images/menubutton32.png">
                        <Items>
                            <telerik:RadMenuItem runat="server" Text="View as Chart" ImageUrl="http://icons.iconarchive.com/icons/iconshock/real-vista-text/16/chart-icon.png">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="View as Data Table" ImageUrl="http://icons.iconarchive.com/icons/yusuke-kamiyamane/fugue/16/table-icon.png">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Export to Excel" ImageUrl="http://icons.iconarchive.com/icons/ncrow/mega-pack-1/16/Excel-icon.png">
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem runat="server" Text="Export to PDF" ImageUrl="http://icons.iconarchive.com/icons/hopstarter/soft-scraps/16/Adobe-PDF-Document-icon.png">
                            </telerik:RadMenuItem>
                        </Items>
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenu>
        </div>
    </div>
    <div class="ChartInnerDiv">
    CHART ITSELF
    </div>
</div>

