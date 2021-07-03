<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Quizkey.HomePage" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pocetna Stranica</title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <div class="flex container mt-3" id="quizplace" runat="server" style="flex-wrap: wrap; flex-direction: row;" >
            <div class="card" style="width: 18rem;">
                <img src="Pictures/Quiz-7.png" class="card-img-top" />
                <div class="card-body">
                    <h5 class="card-title" id="title" runat="server"></h5>
                    <p class="card-text" id="questionnumber" runat="server"></p>
                    <asp:HyperLink CssClass="btn btn-light btn-outline-primary" NavigateUrl="/QuizCreation.aspx" Text="Create new quiz" runat="server" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>
