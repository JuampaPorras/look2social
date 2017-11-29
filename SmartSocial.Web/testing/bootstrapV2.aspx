<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bootstrapV2.aspx.cs" Inherits="SmartSocial.Web.testing.bootstrapV2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
<!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">


<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
<style>
html,body, form {
    height:100%;
}
.nopadding {
   padding: 0px;
}

@media(max-width:767px){
    #divLeft {
        height:auto !important;
    }
}
@media(min-width:768px){}
@media(min-width:992px){}
@media(min-width:1200px){} 
</style>
</head>
<body>
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

        <div style="width:100%;height:50px;border-bottom:solid 1px #d7d7d7;">
            <input style="float:left; padding:13px 13px 13px 13px" type="image" src="http://jasonrbriggs.com/resources/dropdown-menu.png"  value="Toggle Visibility" onclick="ToggleLeftVisibility(); return false;"/>
            
        </div>
        <div class="container-fluid" style="height: calc(100% - 51px);">
            <div class="row" style="height:100%">
                <div id="divLeft" class="col-lg-2 col-md-3 col-sm-1 col-xs-12 nopadding" style="height:100%;background-color:black;">
                    <div class="row" style="height:100%">
                        <div class="col-md-12" style="position:fixed;">
                                    <telerik:RadPanelBar runat="server" ID="RadPanelBar1" ClientIDMode="Static" Width="100%" Skin="Glow" CssClass="hidden-sm hidden-xs">
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

                                    <telerik:RadMenu ID="RadMenu1" ClientIDMode="Static" runat="server" Skin="Glow" Flow="Vertical" CssClass="hidden-md hidden-lg">
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
                <div id="DivMain" class="col-lg-10 col-md-9 col-sm-11 col-xs-12">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" >
                            <div style="border:solid 1px #000000; height:141px;width:100%;margin-top:20px; background-color:#29b6d8">Chart Container</div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" >
                            <div style="border:solid 1px #000000; height:141px;width:100%;margin-top:20px; background-color:#66c796" >Chart Container</div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" >
                            <div style="border:solid 1px #000000; height:141px;width:100%;margin-top:20px; background-color:#df6a78">Chart Container</div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12" >
                            <div style="border:solid 1px #000000; height:141px;width:100%;margin-top:20px; background-color:#e3e3e3">Chart Container</div>
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
        if (divLeft.style.display == "none") {
            divLeft.style.display = "inline";
            DivMain.className = "col-lg-10 col-md-9 col-sm-11 col-xs-12";
        }
        else {
            divLeft.style.display = "none";
            DivMain.className = "col-lg-12 col-md-12 col-sm-12 col-xs-12";
        }
    }
</script>
    
</body>
</html>
