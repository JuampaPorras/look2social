<%@ Page Title="Log in" Language="C#" MasterPageFile="../Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SmartSocial.Web.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContentPlaceholder">
    
    <div class="login-page">
        <!-- Start login container -->
        <div class="container login-container">
            <div class="login-panel panel panel-default plain animated bounceIn">
                <!-- Start .panel -->
                <div class="panel-heading">
                    <h4 class="panel-title text-center">
                        <strong>Login with your local account</strong>
                    </h4>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal mt0" id="login-form" role="form">
                        <div class="form-group">
                            <div class="col-lg-12">
                                <div class="input-group input-icon">
                                    <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                                    <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" placeholder="Your email ..." runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="txtEmail" ErrorMessage="Please, enter your e-mail."></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="emailValidator" runat="server" Display="Dynamic"
                                        ErrorMessage="Please, enter a valid e-mail address." ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
                                        ControlToValidate="txtEmail">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12">
                                <div class="input-group input-icon">
                                    <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" Text="somepass" placeholder="Your password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" Display="Dynamic"
                                        ControlToValidate="txtPassword" ErrorMessage="Please, enter your password."></asp:RequiredFieldValidator>
                                </div>
                                <span class="help-block text-right"><asp:HyperLink NavigateUrl="Forgot.aspx" runat="server">Forgot password ?</asp:HyperLink></span> 
                            </div>
                        </div>
                        <div class="form-group mb0">
                            <div class="col-lg-7 col-md-7 col-sm-7 col-xs-9">
                                <div class="checkbox-custom">
                                    <asp:CheckBox runat="server" ID="chkRememberMe"/>
                                    <asp:Label runat="server" AssociatedControlID="chkRememberMe">Remember me ?</asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-3 mb25">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-default pull-right"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <div class="seperator">
                        <strong>or</strong>
                        <hr />
                    </div>
                    <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
                </div>
                <div class="panel-footer gray-lighter-bg bt">
                    <h4 class="text-center"><strong>Don`t have an account ?</strong>
                    </h4>
                    <p class="text-center">
                        <asp:HyperLink ID="RegisterHyperLink" NavigateUrl="Register.aspx" CssClass="btn btn-primary" runat="server">Create account</asp:HyperLink>
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="Default"></telerik:RadWindowManager>
    <script src="../Scripts/pages/login.js"></script>
</asp:Content>
