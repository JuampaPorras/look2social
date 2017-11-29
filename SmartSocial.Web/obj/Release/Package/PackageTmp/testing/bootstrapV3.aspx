<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bootstrapV3.aspx.cs" Inherits="SmartSocial.Web.testing.bootstrapV3" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
<!-- Latest compiled and minified CSS -->

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
<link rel="stylesheet" href="../Content/bootstrapCustomized.css">


<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
<style>

.nopadding {
   padding: 0px !important;
}
.sidebar {
    position: fixed;
    top: 50px;
    bottom: 0;
    left: 0;
    z-index: 1000;
    overflow-y:auto;
    overflow-x:hidden;
    display: block;
    background-color: #808080;
  }
@media(max-width:767px){
    #divLeft {
        display:none;
    }
    .sidebar {
        position:initial;
        overflow-y:visible;
        overflow-x:visible;
    }

}
@media(min-width:768px){
    .sidebar {
        position: fixed;
        overflow-y:visible;
        overflow-x:visible;
    }
}
@media(min-width:992px){
    .sidebar {
        position: fixed;
        overflow-y:auto;
        overflow-x:hidden;
    }
}
@media(min-width:1200px){
    .sidebar {
        position: fixed;
        overflow-y:auto;
        overflow-x:hidden;
    }
} 
</style>
</head>
<body style="padding-top:50px;">
    <form id="form1" runat="server">    
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>

       <div class="navbar navbar-default navbar-fixed-top" style="width:100%;height:50px;border-bottom:solid 1px #808080;z-index:9999;" >
            <input style="position:fixed; float:left; padding:13px 13px 13px 13px" type="image" src="http://jasonrbriggs.com/resources/dropdown-menu.png"  value="Toggle Visibility" onclick="ToggleLeftVisibility(); return false;"/>
            
        </div>
        <div class="container-fluid">
            <div class="row">
                <div id="divLeft" class="col-lg-2 col-md-3 col-sm-1 col-xs-12 sidebar nopadding">
                    <div class="row">
                        <div class="col-md-12">
                                    <telerik:RadPanelBar runat="server" ID="RadPanelBar1" ClientIDMode="Static" Width="100%" Skin="Glow" CssClass="hidden-sm">
                                        <Items>
                                            <telerik:RadPanelItem Text="Subscription #1" Expanded="true">
                                                <Items>
                                                    <telerik:RadPanelItem Text="Delivery #1" Expanded="true">
                                                        <Items>
                                                            <telerik:RadPanelItem Text="Report #1"  />
                                                            <telerik:RadPanelItem Text="Report #2"  />
                                                            <telerik:RadPanelItem Text="Report #3"  />
                                                        </Items>
                                                    </telerik:RadPanelItem>
                                                    
                                                </Items>
                                            </telerik:RadPanelItem>
                                            <telerik:RadPanelItem Text="Subscription #2" Expanded="true">
                                                <Items>
                                                    <telerik:RadPanelItem Text="Delivery #1" Expanded="true">
                                                        <Items>
                                                            <telerik:RadPanelItem Text="Report #1"  />
                                                            <telerik:RadPanelItem Text="Report #2"  />
                                                            <telerik:RadPanelItem Text="Report #3"  />
                                                        </Items>
                                                    </telerik:RadPanelItem>
                                                    
                                                </Items>
                                            </telerik:RadPanelItem>
                                            <telerik:RadPanelItem Text="Subscription #3" Expanded="true">
                                                <Items>
                                                    <telerik:RadPanelItem Text="Delivery #1" Expanded="true">
                                                        <Items>
                                                            <telerik:RadPanelItem Text="Report #1"  />
                                                            <telerik:RadPanelItem Text="Report #2" />
                                                            <telerik:RadPanelItem Text="Report #3"  />
                                                        </Items>
                                                    </telerik:RadPanelItem>
                                                    
                                                </Items>
                                            </telerik:RadPanelItem>
                                        </Items>
                                        <ExpandAnimation Type="None" />
                                    </telerik:RadPanelBar>

                                    <telerik:RadMenu ID="RadMenu1" ClientIDMode="Static" runat="server" Skin="Glow" Flow="Vertical" CssClass="hidden-md hidden-lg hidden-xs">
                                        <Items>
                                            <telerik:RadMenuItem Text="<span class='hidden-sm'>Subscription #1</span>" ImageUrl="http://icons.iconarchive.com/icons/graphicloads/100-flat/16/chart-icon.png">
                                                <Items>
                                                    <telerik:RadMenuItem Text="Delivery #1">
                                                        <Items>
                                                            <telerik:RadMenuItem Text="Report #1" ImageUrl="images/41worddoc.gif" />
                                                            <telerik:RadMenuItem Text="Report #2" ImageUrl="images/41worddoc.gif" />
                                                            <telerik:RadMenuItem Text="Report #3" ImageUrl="images/41worddoc.gif" />
                                                        </Items>
                                                    </telerik:RadMenuItem>
                                                    
                                                </Items>
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="<span class='hidden-sm'>Subscription #2</span>" ImageUrl="http://icons.iconarchive.com/icons/graphicloads/100-flat/16/chart-icon.png">
                                                <Items>
                                                    <telerik:RadMenuItem Text="Delivery #1">
                                                        <Items>
                                                            <telerik:RadMenuItem Text="Report #1" ImageUrl="images/41worddoc.gif" />
                                                            <telerik:RadMenuItem Text="Report #2" ImageUrl="images/41worddoc.gif" />
                                                            <telerik:RadMenuItem Text="Report #3" ImageUrl="images/41worddoc.gif" />
                                                        </Items>
                                                    </telerik:RadMenuItem>
                                                    
                                                </Items>
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem Text="<span class='hidden-sm'>Subscription #3</span>" ImageUrl="http://icons.iconarchive.com/icons/graphicloads/100-flat/16/chart-icon.png">
                                                <Items>
                                                    <telerik:RadMenuItem Text="Delivery #1">
                                                        <Items>
                                                            <telerik:RadMenuItem Text="Report #1" ImageUrl="images/41worddoc.gif" />
                                                            <telerik:RadMenuItem Text="Report #2" ImageUrl="images/41worddoc.gif" />
                                                            <telerik:RadMenuItem Text="Report #3" ImageUrl="images/41worddoc.gif" />
                                                        </Items>
                                                    </telerik:RadMenuItem>
                                                    
                                                </Items>
                                            </telerik:RadMenuItem>
                                        </Items>
                                        <ExpandAnimation Type="None" />
                                        <CollapseAnimation Type="None" />
                                    </telerik:RadMenu>

                        </div>
                    </div>
                </div>
                <div id="DivMain" class="col-lg-10 col-lg-offset-2 col-md-9 col-md-offset-3 col-sm-11 col-sm-offset-1 col-xs-12">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" >
                            <div style="border:solid 1px #000000; height:141px;width:100%;margin-top:20px; background-color:#29b6d8">Chart Container</div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" >
                            <div style="border:solid 1px #000000; height:141px;width:100%;margin-top:20px; background-color:#66c796" >Chart Container</div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                                <!-- .col-md-3 -->
                                <div class="panel panel-info tile" id="dyn_1">
                                    <!-- Start .panel -->
                                    <div class="panel-heading">
                                        <h4 class="panel-title">Today Sales</h4>
                                    </div>
                                    <div class="panel-body pt0">
                                        <div class="progressbar-stats-1">
                                            <div class="stats">
                                                <i class="l-ecommerce-cart-content"></i> 
                                                <div class="stats-number" data-from="0" data-to="76">76</div>
                                            </div>
                                            <div class="progress animated-bar flat transparent progress-bar-xs mb10 mt0">
                                                <div class="progress-bar progress-bar-white" role="progressbar" data-transitiongoal="63" aria-valuenow="63" style="width: 63%;"></div>
                                            </div>
                                            <div class="comparison">
                                                <p class="mb0"><i class="fa fa-arrow-circle-o-up s20 mr5 pull-left"></i> 10% up from last month</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- End .panel -->
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                                <!-- .col-md-3 -->
                                <div class="panel panel-info tile panelClose panelRefresh" id="dyn_0">
                                    <!-- Start .panel -->
                                    <div class="panel-heading">
                                        <h4 class="panel-title">Today Sales</h4>
                                    <div class="panel-controls panel-controls-right"><a href="#" class="panel-refresh"><i class="fa fa-circle-o"></i></a><a href="#" class="panel-close"><i class="fa fa-times"></i></a></div></div>
                                    <div class="panel-body pt0">
                                        <div class="progressbar-stats-1">
                                            <div class="stats">
                                                <i class="l-ecommerce-cart-content"></i> 
                                                <div class="stats-number" data-from="0" data-to="76">76</div>
                                            </div>
                                            <div class="progress animated-bar flat transparent progress-bar-xs mb10 mt0">
                                                <div class="progress-bar progress-bar-white" role="progressbar" data-transitiongoal="63" aria-valuenow="63" style="width: 63%;"></div>
                                            </div>
                                            <div class="comparison">
                                                <p class="mb0"><i class="fa fa-arrow-circle-o-up s20 mr5 pull-left"></i> 10% up from last month</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- End .panel -->
                            </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div style="border:solid 1px #000000; height:300px;width:100%;margin-top:20px">Chart Container</div>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12" >
                            <div style="border:solid 1px #000000; height:300px;width:100%;margin-top:20px">Chart Container</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
<script type="text/javascript">
    function ToggleLeftVisibility() {
        if ((divLeft.style.display == "none") || (divLeft.style.display == "")) {
            divLeft.style.display = "block";
            DivMain.className = "col-lg-10 col-lg-offset-2 col-md-9 col-md-offset-3 col-sm-11 col-sm-offset-1 col-xs-12";
        }
        else {
            divLeft.style.display = "none";
            DivMain.className = "col-lg-12 col-md-12 col-sm-12 col-xs-12";
        }
    }
</script>
    
</body>
</html>
