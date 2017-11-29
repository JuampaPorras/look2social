<%@ Page Title="Manage Password" Language="C#" MasterPageFile="../Site.Master" AutoEventWireup="true" CodeBehind="ManagePassword.aspx.cs" Inherits="SmartSocial.Web.Account.ManagePassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <div class="login-page">
        <!-- Start login container -->
        <div class="container login-container">
            <div class="login-panel panel panel-default plain animated bounceIn">
                <!-- Start .panel -->
                <div class="panel-heading">
                    <h4 class="panel-title text-center">
                        Manage Password
                    </h4>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal mt0" id="register-form" role="form">
                        <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
                            <p>
                                You do not have a local password for this site. Add a local
                                    password so you can log in without an external login.
                            </p>
                            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="input-group input-icon">
                                        <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                        <asp:TextBox runat="server" ID="password" CssClass="form-control" TextMode="Password" placeholder="Type your current password ..." />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                            CssClass="text-danger" ErrorMessage="The password field is required."
                                            Display="Dynamic" ValidationGroup="SetPassword" />
                                        <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                            CssClass="text-danger" SetFocusOnError="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="input-group input-icon">
                                        <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                        <asp:TextBox runat="server" ID="confirmPassword" CssClass="form-control" TextMode="Password" placeholder="Type confirm password ..." />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required."
                                            ValidationGroup="SetPassword" />
                                        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match."
                                            ValidationGroup="SetPassword" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group mb0">
                                <div class="col-md-12">
                                    <asp:Button runat="server" ValidationGroup="SetPassword" OnClick="SetPassword_Click" Text="Set Password" CssClass="btn btn-default" />
                                </div>
                            </div>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder runat="server" ID="changePasswordHolder" Visible="false">
                            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="input-group input-icon">
                                        <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                        <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control" placeholder="Type your current password ..." />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword" Display="Dynamic"
                                            CssClass="text-danger" ErrorMessage="The current password field is required."
                                            ValidationGroup="ChangePassword" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="input-group input-icon">
                                        <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                        <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" placeholder="Type your new password ..." />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword" Display="Dynamic"
                                            CssClass="text-danger" ErrorMessage="The new password is required."
                                            ValidationGroup="ChangePassword" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="input-group input-icon">
                                        <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                        <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" CssClass="form-control" placeholder="Type confirm password ..." />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                            CssClass="text-danger" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                            ValidationGroup="ChangePassword" />
                                        <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                            ValidationGroup="ChangePassword" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group mb0">
                                <div class="col-md-12">
                                    <asp:Button runat="server" Text="Change Password" ValidationGroup="ChangePassword" OnClick="ChangePassword_Click" CssClass="btn btn-default" />
                                </div>
                            </div>
                        </asp:PlaceHolder>
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
