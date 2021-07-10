<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Quizkey.HomePage" %>

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
        <div class="flex container mt-3" id="quizplace" runat="server" style="flex-wrap: wrap; flex-direction: row;">
            <div class="card m-1" style="width: 18rem;">
                <img src="Pictures/Quiz-7.png" class="card-img-top" />
                <div class="card-body">
                    <h5 class="card-title" id="title" runat="server"></h5>
                    <p class="card-text" id="questionnumber" runat="server"></p>
                    <asp:HyperLink CssClass="btn btn-light btn-outline-primary" NavigateUrl="/QuizCreation.aspx" ID="hyperlink" runat="server" />
                </div>
            </div>
        </div>
    </form>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/jquery-3.6.0.min.js"></script>
</body>
</html>
