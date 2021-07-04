<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultsAttendee.aspx.cs" Inherits="Quizkey.ResultsAttendee" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quizkey</title>
    <link href="Content/qk-results.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <%--Menu Bar--%>
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <%--Subnav Bar--%>
        <nav class="navbar navbar-light bg-secondary">
            <div class="container-fluid d-flex justify-content-between flex-sm-nowrap">
                <div class="input-group m-1">
                    <span class="input-group-text">Naziv Kviza</span>
                    <asp:TextBox ID="tbQuizName" CssClass="form-control" runat="server" />
                </div>
            </div>
        </nav>
        <%--Main Container--%>
        <div class="container-fluid qk-quizcreation-grid-container-main mt-3">
            <%--Top Container--%>
            <div class="qk-quizcreation-grid-container-top">
                <%--Question--%>
                <div class="bg-secondary rounded d-flex text-center order" id="positioncontainer" runat="server">
                </div>
                <%--Time--%>
            </div>
            <%--Bottom Container--%>
        </div>
    </form>
</body>
</html>
