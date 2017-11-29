<%@ Page Title="Forgot password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="SmartSocial.Web.Account.ForgotPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContentPlaceholder">
    <div class="login-page">
        <!-- Start login container -->
        <div runat="server" class="container login-container">
            <div class="login-panel panel panel-default plain animated bounceIn">
                <!-- Start .panel -->
                <div class="panel-heading">
                    <h4 class="panel-title text-center">
                        Forgot your password?
                    </h4>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal mt0" id="register-form" role="form">
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
                            <p class="text-info">
                                Please check your email to reset your password.
                            </p>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="loginForm" runat="server">
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
                            <div class="form-group mb0">
                                <div class="col-md-12">
                                    <asp:Button runat="server" OnClick="Forgot" Text="Submit" CssClass="btn btn-default" />
                                </div>
                            </div>
                        </asp:PlaceHolder>
                    </div>
                </div>
                <div class="panel-footer gray-lighter-bg bt">
                    <h4 class="text-center"><strong>Lost your password ?</strong>
                    </h4>
                    <p class="text-center">You will received new password in your email.</p>
                    
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
