<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Quizkey.ProfilePage" UnobtrusiveValidationMode="None" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%;">
<head runat="server">
    <title>Quizkey</title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
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
                    <span id="lbUsername" runat="server" class="input-group-text"></span>
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
                        ErrorMessage="Name was not entered." />
                    <span id="diverrormessage" runat="server"></span>
                </div>
                <div class="input-group mb-3">
                    <span id="lbEmail" runat="server" class="input-group-text"></span>
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
                        ErrorMessage="Email was not entered." />
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
                <div class="input-group mb-3">
                    <span id="lbPassword" runat="server" class="input-group-text"></span>
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
                        ErrorMessage="Password was not entered." />
                </div>
                <div class="input-group mb-3">
                    <span id="lbRepeatPassword" runat="server" class="input-group-text"></span>
                    <asp:TextBox
                        ID="tbPasswordNew"
                        TextMode="Password"
                        runat="server"
                        CssClass="form-control" />
                </div>
                <div class="d-flex flex-row-reverse gap-3">
                    <asp:Button
                        ID="btDelete"
                        runat="server"
                        OnClientClick="return confirm('Are you sure you wish to delete your account?\nAll your data will be lost');"
                        OnClick="btDelete_Click"
                        CssClass="btn btn-danger" />
                    <asp:Button
                        ID="btSend"
                        runat="server"
                        CssClass="btn btn-primary"
                        OnClick="btUpdateAccount_Click" />
                </div>
                <div>
                    <asp:ValidationSummary
                        ID="summary"
                        runat="server"
                        ForeColor="Red" />
                </div>
            </div>
        </div>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <script src="../../Scripts/jquery-3.6.0.min.js"></script>
    </form>
</body>
</html>
