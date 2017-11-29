<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelBarHTMLTest.aspx.cs" Inherits="SmartSocial.Web.testing.PanelBarHTMLTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <div>
    <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Width="100%" Height="278px"
            Skin="Telerik" ExpandMode="FullExpandedItem">
            <Items>
                <telerik:RadPanelItem  Text="<div style='float:left; width:20px'><img style='margin-top:3px;margin-bottom:-3px;' src='http://icons.iconarchive.com/icons/iynque/flurry-cameras/16/MacBook-Active-icon.png'/></div> <div style='float:left;margin-right:5px;'><b>UserName</b></div><div style='float:right; font-size:11px; color: green;margin-right:4px'>Followers:1200</div><div style='white-space:nowrap;text-overflow:ellipsis;overflow:hidden;'>Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio</div>" Expanded="false">
                    <ContentTemplate>
                        BLA BLA BLA!
                    </ContentTemplate>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem  Text="<div style='float:left; width:20px'><img style='margin-top:3px;margin-bottom:-3px;' src='http://icons.iconarchive.com/icons/iynque/flurry-cameras/16/MacBook-Active-icon.png'/></div> <div style='float:left;margin-right:5px;'><b>UserName2Gustavo</b></div><div style='float:right; font-size:11px; color: green;margin-right:4px'>12/12/2015</div><div style='white-space:nowrap;text-overflow:ellipsis;overflow:hidden;'>gsdfgsdfgsdfgsdfgsdgfs fgsdfgsdfgsdfgsdfgsdfgsdfgsd</div>" Expanded="false">
                    <ContentTemplate>
                        BLA BLA BLA!
                    </ContentTemplate>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem  Text="<div style='float:left; width:20px'><img style='margin-top:3px;margin-bottom:-3px;' src='http://icons.iconarchive.com/icons/iynque/flurry-cameras/16/MacBook-Active-icon.png'/></div> <div style='float:left;margin-right:5px;'><b>UserName3</b></div><div style='float:right; font-size:11px; color: green;margin-right:4px'>12/12/2015</div><div style='white-space:nowrap;text-overflow:ellipsis;overflow:hidden;'>Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio</div>" Expanded="false">
                    <ContentTemplate>
                        BLA BLA BLA!
                    </ContentTemplate>
                </telerik:RadPanelItem>
                <telerik:RadPanelItem  Text="<div style='float:left; width:20px'><img style='margin-top:3px;margin-bottom:-3px;' src='http://icons.iconarchive.com/icons/iynque/flurry-cameras/16/MacBook-Active-icon.png'/></div> <div style='float:left;margin-right:5px;'><b>UserName4</b></div><div style='float:right; font-size:11px; color: green;margin-right:4px'>12/12/2015</div><div style='white-space:nowrap;text-overflow:ellipsis;overflow:hidden;'>Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio Bio</div>" Expanded="false">
                    <ContentTemplate>
                        BLA BLA BLA!
                    </ContentTemplate>
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelBar>
    </div>
    </form>
</body>
</html>
