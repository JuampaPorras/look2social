<%@ Page Title="Password Changed" Language="C#" MasterPageFile="../Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="SmartSocial.Web.Account.ResetPasswordConfirmation" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContentPlaceholder">
    <div class="login-page">
        <!-- Start login container -->
        <div runat="server" class="container login-container">
            <div class="login-panel panel panel-default plain animated bounceIn">
                <!-- Start .panel -->
                <div class="panel-heading">
                    <h4 class="panel-title text-center">
                        Password Changed
                    </h4>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal mt0" id="register-form" role="form">
                        <div class="form-group mb0">
                            <div class="col-md-12">
                                <p>Your password has been changed. Click <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">here</asp:HyperLink> to login </p>
                            </div>
                        </div>
                    </div>
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
