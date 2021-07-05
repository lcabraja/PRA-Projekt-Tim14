﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Quizkey.ProfilePage" UnobtrusiveValidationMode="None" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%;">
<head runat="server">
    <title id="title" runat="server">Your Profile</title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
</head>
<body style="height: 100%;">
    <form id="form1" runat="server" style="height: 100%;">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <div class="container m-auto mt-4">
            <div class="container mt-5" id="formcontainer">
                <style>
                    #formcontainer > .input-group {
                        margin-right: 0px;
                    }

                        #formcontainer > .input-group > .form-control {
                            margin-right: 1px;
                        }
                </style>
                <div class="input-group mb-3">
                    <span id="lbUsername" runat="server" class="input-group-text">Username</span>
                    <asp:TextBox
                        ID="tbUsername"
                        runat="server"
                        CssClass="form-control" />
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2"
                        runat="server"
                        ControlToValidate="tbUsername"
                        CssClass="d-none"
                        ForeColor="Red"
                        ErrorMessage="Name was not entered.">*
                            </asp:RequiredFieldValidator>
                    <span id="diverrormessage" runat="server"></span>
                </div>
                <div class="input-group mb-3">
                    <span id="lbEmail" runat="server" class="input-group-text">E-mail</span>
                    <asp:TextBox
                        ID="tbEmail"
                        runat="server"
                        CssClass="form-control" />
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3"
                        runat="server"
                        ControlToValidate="tbEmail"
                        CssClass="d-none"
                        ForeColor="Red"
                        ErrorMessage="Email was not entered.">*
                        </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator
                        ID="regex"
                        runat="server"
                        ControlToValidate="tbEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        EnableClientScript="true"
                        Display="Static"
                        ForeColor="Red"
                        ErrorMessage="Wrong Email format"
                        CssClass="d-none" />
                </div>
                <div class="mb-3">
                    <asp:Button
                        ID="btUpdateEmail"
                        runat="server"
                        CssClass="btn btn-primary"
                        OnClick="btUpdateEmail_Click"
                        Text="Update E-mail" />
                </div>
                <div class="input-group mb-3">
                    <span id="lbPassword" runat="server" class="input-group-text">Password</span>
                    <asp:TextBox
                        ID="tbPassword"
                        TextMode="Password"
                        runat="server"
                        CssClass="form-control" />
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator6"
                        runat="server"
                        ControlToValidate="tbPassword"
                        CssClass="d-none"
                        ForeColor="Red"
                        ErrorMessage="Password was not entered.">*
                        </asp:RequiredFieldValidator>
                </div>
                <div class="input-group mb-3">
                    <span id="lbRepeatPassword" runat="server" class="input-group-text">Repeat Password</span>
                    <asp:TextBox
                        ID="tbPasswordRepeat"
                        TextMode="Password"
                        runat="server"
                        CssClass="form-control" />
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator5"
                        runat="server"
                        CssClass="d-none"
                        Display="Dynamic"
                        ControlToValidate="tbPasswordRepeat"
                        ForeColor="Red"
                        ErrorMessage="Password was not repeated.">*
                        </asp:RequiredFieldValidator>
                    <asp:CompareValidator
                        ID="comparePasswordValidator"
                        ControlToValidate="tbPasswordRepeat"
                        ControlToCompare="tbPassword"
                        runat="server"
                        CssClass="d-none"
                        ForeColor="Red"
                        ErrorMessage="Passwords do not match">*
                        </asp:CompareValidator>
                </div>
                <div class="d-flex" style="flex-direction: row-reverse; grid-column-gap: 1rem;">
                    <asp:Button
                        ID="btDelete"
                        runat="server"
                        OnClientClick="return confirm('Are you sure you wish to delete your account?\nAll your data will be lost');"
                        OnClick="btDelete_Click"
                        CssClass="btn btn-danger"
                        Text="Delete Account" />
                    <asp:Button
                        ID="btSend"
                        runat="server"
                        CssClass="btn btn-primary"
                        OnClick="btSend_Click"
                        Text="Update Password" />
                </div>
                <div>
                    <asp:ValidationSummary
                        ID="summary"
                        runat="server"
                        ForeColor="Red" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
