<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="Quizkey.StartPage" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%;">
<head runat="server">
    <title>Dobrodosao u Quizkey</title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
</head>
<body style="height: 100%;">
    <form id="form1" runat="server" style="height: 100%;">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <div class="position-relative m-auto">
            <div class="position-absolute top-100 start-50 translate-middle-x m-auto">
                <div class="btn-group-vertical" role="group" aria-label="Basic checkbox toggle button group">
                    <asp:Button Text="Igraj" OnClick="Play_Click" CssClass="btn btn-outline-primary" runat="server" />
                    <asp:Button Text="Prijava" OnClick="Login_Click" CssClass="btn btn-outline-primary" runat="server" />
                    <asp:Button Text="Registracija" OnClick="Register_Click" CssClass="btn btn-outline-primary" runat="server" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
