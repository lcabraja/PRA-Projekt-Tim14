<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Quizkey.Login" UnobtrusiveValidationMode="None" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prijava</title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <div class="container">
            <div class="container m-auto mt-4">
                <table style="margin: auto; margin-top: 120px;">
                    <tr>
                        <td>
                            <asp:Label
                                ID="label1"
                                runat="server"
                                Text="Username" />
                        </td>
                        <td>
                            <asp:TextBox
                                ID="tbUsername"
                                runat="server" />
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2"
                                runat="server"
                                ControlToValidate="tbUsername"
                                ForeColor="Red"
                                ErrorMessage="Name was not entered.">*
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label
                                ID="label6"
                                runat="server"
                                Text="Password" />
                        </td>
                        <td>
                            <asp:TextBox
                                ID="tbPassword"
                                TextMode="Password"
                                runat="server" />
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator6"
                                runat="server"
                                ControlToValidate="tbPassword"
                                ForeColor="Red"
                                ErrorMessage="Password was not entered.">*
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button
                                ID="btSend"
                                runat="server"
                                Text="Send" />
                            <span id="diverrormessage" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:ValidationSummary
                                ID="summary"
                                runat="server"
                                ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label CssClass="badge badge-danger" ID="errormessage" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
