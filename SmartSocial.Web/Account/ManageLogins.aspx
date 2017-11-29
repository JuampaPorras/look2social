<%@ Page Title="Manage your external logins." Language="C#" MasterPageFile="../Site.Master" AutoEventWireup="true" CodeBehind="ManageLogins.aspx.cs" Inherits="SmartSocial.Web.Account.ManageLogins" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <div class="login-page">
        <!-- Start login container -->
        <div class="container login-container">
            <div class="login-panel panel panel-default plain animated bounceIn">
                <!-- Start .panel -->
                <div class="panel-heading">
                    <h4 class="panel-title text-center">
                        <strong>Manage your external logins.</strong>
                    </h4>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal mt0" id="login-form" role="form">
                        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                            <p class="text-success"><%: SuccessMessage %></p>
                        </asp:PlaceHolder>
                        <asp:ListView runat="server"
                            ItemType="Microsoft.AspNet.Identity.UserLoginInfo"
                            SelectMethod="GetLogins" DeleteMethod="RemoveLogin" DataKeyNames="LoginProvider,ProviderKey">

                            <LayoutTemplate>
                                <h4>Registered Logins</h4>
                                <table class="table">
                                    <tbody>
                                        <tr runat="server" id="itemPlaceholder"></tr>
                                    </tbody>
                                </table>

                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#: Item.LoginProvider %></td>
                                    <td>
                                        <asp:Button runat="server" Text="Remove" CommandName="Delete" CausesValidation="false"
                                            ToolTip='<%# "Remove this " + Item.LoginProvider + " login from your account" %>'
                                            Visible="<%# CanRemoveExternalLogins %>" CssClass="btn btn-default" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" ReturnUrl="~/Account/ManageLogins" />
                </div>
            </div>
            <!-- End .panel -->
        </div>
        <!-- End login container -->
        <div class="container">
            <div class="footer">
                <p class="text-center">&copy;2015 Copyright Smart Social Reporting. All right reserved!</p>
            </div>
        </div>
    </div>
    <script src="../Scripts/pages/login.js"></script>
</asp:Content>
