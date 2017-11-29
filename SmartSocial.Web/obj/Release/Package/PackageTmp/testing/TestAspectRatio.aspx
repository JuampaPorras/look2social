<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestAspectRatio.aspx.cs" Inherits="SmartSocial.Web.testing.AspectRatioTest" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrapCustomized.css" rel="stylesheet" />
<style type="text/css">
     
    html, body, form
    {
       height: 100%;
       margin: 0px;
       padding: 0px;
       
    }
     
     
    </style>
</head>
<body style="overflow:hidden;">
       <form id="form1" runat="server">
           <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
           </telerik:RadStyleSheetManager>
           <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
           </telerik:RadAjaxManager>
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" Skin="Bootstrap"/>
           <telerik:RadPageLayout ID="RadPageLayout1" runat="server" GridType="Fluid" CssClass="borderCssClass">
          <Rows>
              <telerik:LayoutRow >
                           <Columns>
                      <telerik:LayoutColumn Span="8">
                          
                <telerik:RadHtmlChart ID="RadHtmlChart1" runat="server" BorderStyle="Solid" BorderWidth="1px">
                    <ChartTitle Text="The Title">
                        <Appearance Visible="True">
                        </Appearance>
                    </ChartTitle>
                    <Legend>
                        <Appearance Position="Bottom" Visible="True">
                        </Appearance>
                    </Legend>
                    <PlotArea>
                        <Series>
                            <telerik:ColumnSeries Name="In 2010 (Markup)">
                        <TooltipsAppearance DataFormatString="{0}%"></TooltipsAppearance>
                        <LabelsAppearance Visible="false">
                        </LabelsAppearance>
                        <TooltipsAppearance Color="White" />
                        <SeriesItems>
                            <telerik:CategorySeriesItem Y="46.3"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="46.5"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="46.2"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="46.4"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="46.9"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="46.6"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="46.4"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="45.8"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="45.1"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="44.1"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="44.0"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="43.5"></telerik:CategorySeriesItem>
                        </SeriesItems>
                    </telerik:ColumnSeries>
                    <telerik:ColumnSeries Name="In 2011 (Markup and DataSource)" DataFieldY="DummyData">
                        <TooltipsAppearance Color="White" DataFormatString="{0}%"></TooltipsAppearance>
                        <LabelsAppearance Visible="false">
                        </LabelsAppearance>
                        <SeriesItems>
                            <telerik:CategorySeriesItem Y="42.8"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="42.4"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="42.2"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="42.9"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="42.4"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="42.2"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="42.0"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="40.6"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="39.7"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="38.7"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="38.1"></telerik:CategorySeriesItem>
                            <telerik:CategorySeriesItem Y="37.7"></telerik:CategorySeriesItem>
                        </SeriesItems>
                    </telerik:ColumnSeries>
                        </Series>
                    </PlotArea>
                </telerik:RadHtmlChart>





                      </telerik:LayoutColumn>
                      <telerik:CompositeLayoutColumn Span="4">
                          <Rows>
                              <telerik:LayoutRow>
                                  <Content>additional content 1</Content>
                              </telerik:LayoutRow>
                              <telerik:LayoutRow>
                                  <Content> additional content 2</Content>
                              </telerik:LayoutRow>
                          </Rows>

                      </telerik:CompositeLayoutColumn>
                  </Columns>
              </telerik:LayoutRow>
         </Rows>
      </telerik:RadPageLayout>
    <div style="width:100%;height: calc(100% - 34px);">
        
        

    </div>
    </form>
</body>
</html>
