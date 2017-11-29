<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadMoreTesting.aspx.cs" Inherits="SmartSocial.Web.testing.LoadMoreTesting" %>

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
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="btnLoadMore">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadListView1" UpdatePanelCssClass="" />
                        <telerik:AjaxUpdatedControl ControlID="SqlDataSource1" UpdatePanelCssClass="" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
    <div>
    <div style="width:500px;height:170px;overflow:auto;border:solid 1px black">
        <telerik:RadListView ID="RadListView1" runat="server" AllowPaging="True" DataKeyNames="idSeriesValue" DataSourceID="SqlDataSource1" PageSize="5" Skin="Office2010Blue">
            <LayoutTemplate>
                <div class="RadListView RadListView_Office2010Blue">
                    <table cellspacing="0" style="width:100%;">
                        <thead>
                            <tr class="rlvHeader">
                                <th>idSeriesValue</th>
                                <th>Value</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </tbody>
                    </table>
                </div>
</LayoutTemplate>
            <ItemTemplate>
                <tr class="rlvI">
                    <td>
                        <asp:Label ID="idSeriesValueLabel" runat="server" Text='<%# Eval("idSeriesValue") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ValueLabel" runat="server" Text='<%# Eval("Value") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="rlvA">
                    <td>
                        <asp:Label ID="idSeriesValueLabel" runat="server" Text='<%# Eval("idSeriesValue") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ValueLabel" runat="server" Text='<%# Eval("Value") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr class="rlvIEdit">
                    <td colspan="2">
                        <table cellspacing="0" class="rlvEditTable">
                            <tr>
                                <td>
                                    <asp:Label ID="idSeriesValueLabel2" runat="server" Text="idSeriesValue"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="idSeriesValueLabel1" runat="server" Text='<%# Eval("idSeriesValue") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="ValueLabel2" runat="server" AssociatedControlID="ValueTextBox" Text="Value"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ValueTextBox" runat="server" CssClass="rlvInput" Text='<%# Bind("Value") %>' />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </EditItemTemplate>
            <InsertItemTemplate>
                <tr class="rlvIEdit">
                    <td colspan="2">
                        <table cellspacing="0" class="rlvEditTable">
                            <tr>
                                <td>
                                    <asp:Label ID="ValueLabel2" runat="server" AssociatedControlID="ValueTextBox" Text="Value"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ValueTextBox" runat="server" CssClass="rlvInput" Text='<%# Bind("Value") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="PerformInsertButton" runat="server" CommandName="PerformInsert" CssClass="rlvBAdd" Text=" " ToolTip="Insert" />
                                    <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" CssClass="rlvBCancel" Text=" " ToolTip="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </InsertItemTemplate>
            <EmptyDataTemplate>
                <div class="RadListView RadListView_Office2010Blue">
                    <div class="rlvEmpty">
                        There are no items to be displayed.</div>
                </div>
            </EmptyDataTemplate>
            <SelectedItemTemplate>
                <tr class="rlvISel">
                    <td>
                        <asp:Label ID="idSeriesValueLabel" runat="server" Text='<%# Eval("idSeriesValue") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ValueLabel" runat="server" Text='<%# Eval("Value") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </telerik:RadListView>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EspriellaSmartSocialConnectionString %>" SelectCommand="SELECT [idSeriesValue], [Value] FROM [SeriesValue]"></asp:SqlDataSource>
    
    </div>
        <asp:Button ID="btnLoadMore" runat="server" OnClick="btnLoadMore_Click" Text="Load More..." />
    </form>
</body>
</html>
