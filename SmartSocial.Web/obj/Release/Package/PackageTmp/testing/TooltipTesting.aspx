<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TooltipTesting.aspx.cs" Inherits="SmartSocial.Web.testing.TooltipTesting" %>

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
    
        <telerik:RadHtmlChart ID="RadHtmlChart1" runat="server" Height="350px" Width="500px" >
            <PlotArea>
                <Series>
                    <telerik:ScatterLineSeries Name="ScatterLineSeries1">
                        <SeriesItems>
                            <telerik:ScatterSeriesItem X="1" Y="10" />
                            <telerik:ScatterSeriesItem X="2" Y="8" />
                            <telerik:ScatterSeriesItem X="3" Y="12" />
                        </SeriesItems>
                    </telerik:ScatterLineSeries>
                    <telerik:ScatterLineSeries Name="ScatterLineSeries2">
                        <SeriesItems>
                            <telerik:ScatterSeriesItem X="1" Y="12" />
                            <telerik:ScatterSeriesItem X="2" Y="13" />
                            <telerik:ScatterSeriesItem X="3" Y="14" />
                        </SeriesItems>
                    </telerik:ScatterLineSeries>
                </Series>
            </PlotArea>
        </telerik:RadHtmlChart>
    
    </div>
        <img id="Image1"  src="http://icons.iconarchive.com/icons/custom-icon-design/flatastic-1/24/comment-icon.png" style="position:absolute" />
    </form>
<script>
    function SetCommentPlacement()
    {
        Image1.style.top= 50;
        Image1.style.left= 50;
    }

</script>
</body>
    
</html>
