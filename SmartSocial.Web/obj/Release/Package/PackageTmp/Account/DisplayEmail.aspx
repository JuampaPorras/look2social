<%@ Page Title="Email Confirmation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayEmail.aspx.cs" Inherits="SmartSocial.Web.Account.DisplayEmail" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContentPlaceholder">
    <div class="login-page">
        <!-- Start login container -->
        <div runat="server" class="container login-container">
            <asp:PlaceHolder ID="loginForm" runat="server">
                <div class="login-panel panel panel-default plain animated bounceIn">
                    <!-- Start .panel -->
                    <div class="panel-heading">
                        <h4 class="panel-title text-center">
                            Email Confirmation
                        </h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal mt0" id="register-form" role="form">
                            <div class="form-group mb0">
                                <div class="col-md-12">
                                    <p class="text-center">Please check your email and confirm your email address.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End .panel -->
            </asp:PlaceHolder>
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
