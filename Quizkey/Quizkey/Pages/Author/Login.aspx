<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Quizkey.Login" UnobtrusiveValidationMode="None" %>

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
    <form id="form1" runat="server">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <div class="container">
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
                            class="input-group-text"
                            ID="label1"
                            runat="server" />
                        <asp:TextBox
                            CssClass="form-control"
                            ID="tbUsername"
                            runat="server" />
                    </div>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2"
                        CssClass="d-none"
                        runat="server"
                        ControlToValidate="tbUsername"
                        ForeColor="Red"
                        ErrorMessage="Name was not entered.">*
                            </asp:RequiredFieldValidator>
                    <div class="input-group mb-3">
                        <asp:Label
                            class="input-group-text"
                            ID="label6"
                            runat="server" />
                        <asp:TextBox
                            CssClass="form-control"
                            ID="tbPassword"
                            TextMode="Password"
                            runat="server" />
                    </div>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator6"
                        runat="server"
                        CssClass="d-none"
                        ControlToValidate="tbPassword"
                        ForeColor="Red"
                        ErrorMessage="Password was not entered.">*
                            </asp:RequiredFieldValidator>
                    <div class="d-flex flex-row-reverse">
                        <asp:Button
                            CssClass="btn btn-outline-success ms-1"
                            ID="btSend"
                            runat="server" />
                        <asp:HyperLink
                            CssClass="btn btn-outline-danger mx-1"
                            ID="hpforgot"
                            NavigateUrl="~/Pages/Author/ForgotPassword.aspx"
                            runat="server" />
                        <span id="diverrormessage" runat="server"></span>
                    </div>
                    <div>
                        <asp:ValidationSummary
                            ID="summary"
                            runat="server"
                            ForeColor="Red" />
                    </div>
                    <div>
                        <asp:Label CssClass="badge badge-danger" ID="errormessage" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <script src="../../Scripts/jquery-3.6.0.min.js"></script>
    </form>
</body>
</html>
