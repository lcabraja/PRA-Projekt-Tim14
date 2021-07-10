<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Quizkey.Register" UnobtrusiveValidationMode="None" %>

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
                    <asp:Label
                        ID="label1"
                        class="input-group-text"
                        runat="server"/>
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
                    ForeColor="Red"/>
                <div class="input-group mb-3">
                    <asp:Label
                        ID="label6"
                        class="input-group-text"
                        runat="server"/>
                    <asp:TextBox
                        ID="tbPassword"
                        CssClass="form-control"
                        TextMode="Password"
                        runat="server" />
                </div>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator6"
                    CssClass="d-none"
                    runat="server"
                    ControlToValidate="tbPassword"
                    ForeColor="Red" />
                <div class="input-group mb-3">
                    <asp:Label
                        ID="label7"
                        class="input-group-text"
                        runat="server" />
                    <asp:TextBox
                        ID="tbPasswordRepeat"
                        CssClass="form-control"
                        TextMode="Password"
                        runat="server" />
                </div>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5"
                    runat="server"
                    Display="Dynamic"
                    ControlToValidate="tbPasswordRepeat"
                    CssClass="d-none"
                    ForeColor="Red" />
                <asp:CompareValidator
                    ID="comparePasswordValidator"
                    ControlToValidate="tbPasswordRepeat"
                    ControlToCompare="tbPassword"
                    runat="server"
                    CssClass="d-none"
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
        </div>
    </form>
</body>
</html>
