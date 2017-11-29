<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintingToPDF.aspx.cs" Inherits="SmartSocial.Web.testing.PrintingToPDF" %>

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
        <telerik:RadClientExportManager ID="RadClientExportManager1" runat="server">
        </telerik:RadClientExportManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
    <div>
    
        <telerik:RadHtmlChart ID="RadHtmlChart1" ClientIDMode="Static" runat="server" Height="400px" Width="500px">
            <ChartTitle Text="Hola">
                <Appearance Visible="True">
                </Appearance>
            </ChartTitle>
            <Legend>
                <Appearance Visible="True">
                </Appearance>
            </Legend>

<PlotArea>
    <XAxis Visible="True">
    </XAxis>
    <YAxis Visible="True">
    </YAxis>
    <Series>
        <telerik:ScatterLineSeries Name="ScatterLineSeries1">
            <SeriesItems>
                <telerik:ScatterSeriesItem X="1" Y="1" />
                <telerik:ScatterSeriesItem X="2" Y="2" />
                <telerik:ScatterSeriesItem X="3" Y="3" />
            </SeriesItems>
        </telerik:ScatterLineSeries>
        <telerik:ScatterLineSeries Name="ScatterLineSeries2">
            <SeriesItems>
                <telerik:ScatterSeriesItem X="1" Y="1" />
                <telerik:ScatterSeriesItem X="2" Y="1" />
                <telerik:ScatterSeriesItem X="3" Y="1" />
            </SeriesItems>
        </telerik:ScatterLineSeries>
    </Series>
</PlotArea>

        </telerik:RadHtmlChart>
    
    </div>
    </form>
    <p>
        <input id="Button1" type="button" value="button" onclick="exportPDF();" /></p>

    <script>
        function exportPDF() {
            $find('<%=RadClientExportManager1.ClientID %>').exportPDF($telerik.$("#RadHtmlChart1"));
        }

        


    </script>
</body>
</html>
