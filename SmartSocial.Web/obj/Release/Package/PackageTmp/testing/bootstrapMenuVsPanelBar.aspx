<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bootstrapMenuVsPanelBar.aspx.cs" Inherits="SmartSocial.Web.testing.bootstrapMenuVsPanelBar" %>

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

<div style="width:100%;height:100%">
    <div style="width:100%;height:50px;border-bottom:solid 1px #d7d7d7;">
        <input style="float:left; padding:13px 13px 13px 13px" type="image" src="http://jasonrbriggs.com/resources/dropdown-menu.png" class="hidden-xs" value="Toggle Visibility" onclick="ToggleLeftVisibility(); return false;"/>
        <input style="float:left; padding:13px 13px 13px 13px" type="image" src="http://jasonrbriggs.com/resources/dropdown-menu.png" class="hidden-lg hidden-md hidden-sm" value="Toggle XS Class" onclick="ToggleLeftVisibilityXS(); return false;"/>
        
        
        <input style="float:right; padding:13px 13px 13px 13px" type="image" src="http://icons.iconarchive.com/icons/rafiqul-hassan/blogger/24/Chat-4-icon.png" class="hidden-xs" value="Toggle Visibility" onclick="ToggleRightVisibility(); return false;"/>
        <input style="float:right; padding:13px 13px 13px 13px" type="image" src="http://icons.iconarchive.com/icons/rafiqul-hassan/blogger/24/Chat-4-icon.png" class="hidden-lg hidden-md hidden-sm" value="Toggle XS Class" onclick="ToggleRightVisibilityXS(); return false;"/>
    </div>

    <div id="divLeft" style="float:left;height: calc(100% - 51px);background-color:#303946">
        <telerik:RadPanelBar runat="server" ID="RadPanelBar1" ClientIDMode="Static" Width="210px" Skin="Glow" CssClass="hidden-sm hidden-xs">
            <Items>
                <telerik:RadPanelItem Expanded="True" Text="Corporate">
                    <Items>
                        <telerik:RadPanelItem Expanded="True" Text="About us">
                            <Items>
                                <telerik:RadPanelItem Text="News" />
                                <telerik:RadPanelItem Text="Team" />
                            </Items>
                        </telerik:RadPanelItem>
                        <telerik:RadPanelItem Text="Careers" />
                    </Items>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Services">
                    <Items>
                        <telerik:RadPanelItem Text="Products" />
                        <telerik:RadPanelItem Text="Solutions" />
                        <telerik:RadPanelItem Text="Certifications" />
                    </Items>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Work">
                    <Items>
                        <telerik:RadPanelItem Text="Clients" />
                        <telerik:RadPanelItem Text="Testimonials" />
                        <telerik:RadPanelItem Text="FAQ" />
                    </Items>
                </telerik:RadPanelItem>
            </Items>
            <ExpandAnimation Type="None" />
        </telerik:RadPanelBar>

        <telerik:RadMenu ID="RadMenu1" ClientIDMode="Static" runat="server" Skin="Glow" Flow="Vertical" style="" CssClass="hidden-md hidden-lg hidden-xs">
            <Items>
                <telerik:RadMenuItem Text="<span class='hidden-xs'>Save As</span>" ImageUrl="images/14SaveAs.gif" GroupSettings-Flow="Vertical"
                    GroupSettings-OffsetY="-1">
                    <Items>
                        <telerik:RadMenuItem Text="Word Document" ImageUrl="images/41worddoc.gif" />
                        <telerik:RadMenuItem Text="Word Template" ImageUrl="images/42wordtmpl.gif" />
                        <telerik:RadMenuItem Text="Adobe PDF" ImageUrl="images/44pdf.gif" />
                        <telerik:RadMenuItem Text="Other formats" ImageUrl="images/45other.gif" />
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem Text="<span class='hidden-xs'>Print</span>" ImageUrl="images/16print.gif" GroupSettings-Flow="Vertical"
                    GroupSettings-OffsetY="-25">
                    <Items>
                        <telerik:RadMenuItem Text="Print" ImageUrl="images/16print.gif" />
                        <telerik:RadMenuItem Text="Quick Print" ImageUrl="images/16print.gif" />
                        <telerik:RadMenuItem Text="Print Preview" ImageUrl="images/15printPreview.gif" />
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem Text="<span class='hidden-xs'>Publish</span>" ImageUrl="images/16publish.gif" GroupSettings-Flow="Vertical"
                    GroupSettings-OffsetY="-49">
                    <Items>
                        <telerik:RadMenuItem Text="Run Compatibility Checker" ImageUrl="images/07compatibility.gif" />
                        <telerik:RadMenuItem Text="Blog" ImageUrl="images/31blog.gif" />
                        <telerik:RadMenuItem Text="Document Management Server" ImageUrl="images/32docmngr.gif" />
                        <telerik:RadMenuItem Text="Create Document Workspace" ImageUrl="images/33docwspc.gif" />
                    </Items>
                </telerik:RadMenuItem>
            </Items>
            <ExpandAnimation Type="None" />
            <CollapseAnimation Type="None" />
        </telerik:RadMenu>
    </div>
    <div id="divRight" style="display:none;float:right;height: calc(100% - 51px);background-color:gray">
        <div id="ChatList" style="width:210px;background-color:gray;" class="hidden-sm hidden-xs">CHAT</div>
    </div>
    <div id="MainDiv" style="width:auto;">HOLA</div>
</div>
    </form>
    <script type="text/javascript">
        function ToggleLeftVisibility() {
            var bdisplay;
            bdisplay = divLeft.style.display;
            if (bdisplay == "none") {
                divLeft.style.display = "inline";
            }
            else {
                divLeft.style.display = "none";
            }

        }
        function ToggleLeftVisibilityXS() {
            divLeft.style.display = "inline";
            $("#RadPanelBar1").toggleClass("hidden-xs");

        }
        function ToggleRightVisibility() {
            var bdisplay;
            bdisplay = divRight.style.display;
            if (bdisplay == "none") {
                divRight.style.display = "inline";
            }
            else {
                divRight.style.display = "none";
            }

        }
        function ToggleRightVisibilityXS() {
            divRight.style.display = "inline";
            $("#ChatList").toggleClass("hidden-xs");

        }
</script>
</body>
</html>
