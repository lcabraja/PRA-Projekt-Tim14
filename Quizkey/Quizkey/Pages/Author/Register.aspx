<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Quizkey.Register" UnobtrusiveValidationMode="None" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%;">
<head runat="server">
    <title>Registriraj se</title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
</head>
<body style="height: 100%;">
    <form id="form1" runat="server" style="height: 100%;">
        <uc1:_Navbar runat="server" ID="_Navbar" />
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
                        <span id="diverrormessage" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label
                            ID="label4"
                            runat="server"
                            Text="Email" />
                    </td>
                    <td>
                        <asp:TextBox
                            ID="tbEmail"
                            runat="server" />
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator3"
                            runat="server"
                            ControlToValidate="tbEmail"
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
                            ErrorMessage="Wrong Email format">*
                        </asp:RegularExpressionValidator>
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
                    <td>
                        <asp:Label
                            ID="label7"
                            runat="server"
                            Text="Repeat password" />
                    </td>
                    <td>
                        <asp:TextBox
                            ID="tbPasswordRepeat"
                            TextMode="Password"
                            runat="server" />
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator5"
                            runat="server"
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
                            ForeColor="Red"
                            ErrorMessage="Passwords do not match">*
                        </asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button
                            ID="btSend"
                            runat="server"
                            Text="Send" />
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
            </table>
        </div>
    </form>
</body>
</html>
