<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Quizkey.Pages.Author.Pictures.ForgotPassword" UnobtrusiveValidationMode="None" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quizkey</title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
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
                <h2></h2>
                <div class="input-group mb-3">
                    <asp:Label
                        ID="label1"
                        class="input-group-text"
                        runat="server" />
                    <asp:TextBox
                        CssClass="form-control"
                        ID="tbUsername"
                        runat="server" />
                </div>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2"
                    runat="server"
                    CssClass="d-none"
                    ControlToValidate="tbUsername"
                    ForeColor="Red" />
                <span id="diverrormessage" runat="server"></span>
                <div class="input-group mb-3">
                    <asp:Label
                        class="input-group-text"
                        ID="label4"
                        runat="server" />
                    <asp:TextBox
                        CssClass="form-control"
                        ID="tbEmail"
                        runat="server" />
                </div>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3"
                    runat="server"
                    CssClass="d-none"
                    ControlToValidate="tbEmail"
                    ForeColor="Red" />
                <asp:RegularExpressionValidator
                    ID="regex"
                    runat="server"
                    ControlToValidate="tbEmail"
                    CssClass="d-none"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    EnableClientScript="true"
                    Display="Static"
                    ForeColor="Red" />
                <div>
                    <asp:Button
                        CssClass="btn btn-outline-success"
                        ID="btSend"
                        runat="server" />
                </div>
                <div>
                    <asp:ValidationSummary
                        ID="summary"
                        runat="server"
                        ForeColor="Red" />
                </div>
            </div>
            <script src="../../Scripts/bootstrap.min.js"></script>
            <script src="../../Scripts/jquery-3.6.0.min.js"></script>
    </form>
</body>
</html>
