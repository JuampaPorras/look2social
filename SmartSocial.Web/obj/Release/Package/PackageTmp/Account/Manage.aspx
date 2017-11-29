<%@ Page Title="Manage Account" Language="C#" MasterPageFile="../Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SmartSocial.Web.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <div class="login-page">
        <!-- Start login container -->
        <div class="container login-container">
            <div class="login-panel panel panel-default plain animated bounceIn">
                <!-- Start .panel -->
                <div class="panel-heading">
                    <h4 class="panel-title text-center">
                        Change your account settings
                    </h4>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal mt0" id="register-form" role="form">
                        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                            <p class="text-success"><%: SuccessMessage %></p>
                        </asp:PlaceHolder>
                        <div class="form-group">
                            <div class="col-lg-12">
                                <div class="input-group input-icon">
                                    <span class="input-group-addon"><i class="fa fa-list-alt"></i></span>
                                    <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" TextMode="SingleLine" placeholder="Type your first name ..." MaxLength="256" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12">
                                <div class="input-group input-icon">
                                    <span class="input-group-addon"><i class="fa fa-list-alt"></i></span>
                                    <asp:TextBox runat="server" ID="LastName" CssClass="form-control" TextMode="SingleLine" placeholder="Type your last name ..." MaxLength="256" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12">
                                <div class="input-group input-icon">
                                    <span class="input-group-addon"><i class="fa fa-building"></i></span>
                                    <asp:TextBox runat="server" ID="Company" CssClass="form-control" TextMode="SingleLine" placeholder="Type your company ..." MaxLength="256" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group mb0">
                            <div class="col-md-12">
                                <asp:Button runat="server" ID="UpdateProfile" Text="Update" CssClass="btn btn-default" OnClick="UpdateProfile_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer gray-lighter-bg bt">
                    <p class="text-center">
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" CssClass="btn btn-primary" Text="Change Password" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" CssClass="btn btn-primary" Text="Create Password" Visible="false" ID="CreatePassword" runat="server" />
                    </p>
                    <p class="text-center">
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" CssClass="btn btn-primary" Text="Manage External Logins" ID="HyperLink1" runat="server" />                        
                    </p>
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
