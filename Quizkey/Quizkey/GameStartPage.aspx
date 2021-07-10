<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameStartPage.aspx.cs" Inherits="Quizkey.GameStartPage" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quizkey</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <div class="container">
            <h2 id="placeholder" runat="server"></h2>
            <div class="input-group mb-3">
                <asp:TextBox CssClass="form-control" ID="tbQuizCode" runat="server" />
                <asp:Button ID="button1" CssClass="btn btn-outline-secondary" runat="server" />
            </div>
            <span id="diverrormessage" runat="server"></span>
        </div>
    </form>
    <script src="Scripts/bootstrap.js\"></script>
    <script src="Scripts/jquery-3.6.0.js\"></script>
</body>
</html>
