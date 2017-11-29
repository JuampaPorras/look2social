<%@ Page Title="Register" Language="C#" MasterPageFile="../Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SmartSocial.Web.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContentPlaceholder" >
    <div class="login-page">
        <!-- Start login container -->
        <div class="container login-container">
            <div class="login-panel panel panel-default plain animated bounceIn">
                <!-- Start .panel -->
                <div class="panel-heading">
                    <h4 class="panel-title text-center">
                        Create a new account
                    </h4>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal mt0" id="register-form" role="form">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="ErrorMessage" />
                        </p>
                        <div class="form-group">
                            <div class="col-lg-12">
                                <div class="input-group input-icon">
                                    <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Type your email ..." />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" Display="Dynamic"
                                        CssClass="text-danger" ErrorMessage="The email field is required." />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12">
                                <div class="input-group input-icon">
                                    <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Your password" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" Display="Dynamic"
                                        CssClass="text-danger" ErrorMessage="The password field is required." />
                                </div>
                                <div class="input-group input-icon">
                                    <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Repeat password" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                    <asp:CompareValidator runat="server" ControlToCompare="ConfirmPassword" ControlToValidate="Password"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                                </div>
                            </div>
                        </div>
                        <div class="form-group mb0">
                            <div class="col-md-12">
                                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer gray-lighter-bg bt">
                    <h4 class="text-center"><strong>Already have an account ?</strong>
                    </h4>
                    <p class="text-center">
                        <asp:HyperLink NavigateUrl="Login.aspx" CssClass="btn btn-primary" runat="server">Sign in</asp:HyperLink>
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