﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameStartPage.aspx.cs" Inherits="Quizkey.GameStartPage" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <div class="container">
            <div class="input-group mb-3">
                <asp:TextBox CssClass="form-control" ToolTip="Enter a quiz code" ID="tbQuizCode" runat="server" />
                <asp:Button Text="Go" CssClass="btn btn-outline-secondary" runat="server" />
                <span id="diverrormessage" runat="server"></span>
            </div>
        </div>
    </form>
</body>
</html>
