<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPasswordResetFalse.aspx.cs" Inherits="Quizkey.Pages.Author.ForgotPasswordResetFalse" %>

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
        <h1 class="text-center" style="margin-top: 45vh" id="waitingtext" runat="server"></h1>
        <a href="StartPage.aspx">
            <h1 class="text-center" id="gohome" runat="server"></h1>
        </a>
    </form>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/jquery-3.6.0.min.js"></script>
</body>
</html>
