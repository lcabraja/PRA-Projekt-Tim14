<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="Quizkey.StartPage" %>

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
        <div class="position-relative m-auto" style="height: 30%">
            <div class="position-absolute top-100 start-50 translate-middle-x m-auto">
                <div class="btn-group-vertical" role="group" aria-label="Basic checkbox toggle button group">
                    <asp:Button ID="Igraj" OnClick="Play_Click" CssClass="btn btn-outline-primary" runat="server" />
                    <asp:Button ID="Prijava" OnClick="Login_Click" CssClass="btn btn-outline-primary" runat="server" />
                    <asp:Button ID="Registracija" OnClick="Register_Click" CssClass="btn btn-outline-primary" runat="server" />
                </div>
            </div>
        </div>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <script src="../../Scripts/jquery-3.6.0.min.js"></script>
    </form>
</body>
</html>
