<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="Quizkey.Results" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>
<%@ Register Src="~/User_Controls/QuizCreationAnswer.ascx" TagPrefix="uc1" TagName="QuizCreationAnswer" %>
<%@ Register Src="~/User_Controls/QuizCreationButton.ascx" TagPrefix="uc1" TagName="QuizCreationButton" %>
<%@ Register Src="~/User_Controls/QuizCreationTimeButton.ascx" TagPrefix="uc1" TagName="QuizCreationTimeButton" %>
<%@ Register Src="~/User_Controls/QuizResultsPosition.ascx" TagPrefix="uc1" TagName="QuizResultsPosition" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quizkey</title>
    <link href="Content/qk-results.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <%--Menu Bar--%>
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <%--Subnav Bar--%>
        <nav class="navbar navbar-light bg-secondary">
            <div class="container-fluid d-flex justify-content-between flex-sm-nowrap">
                <div class="input-group m-1">
                    <span class="input-group-text" id="quiztopic" runat="server"></span>
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
            <div class="qk-quizcreation-grid-container-bottom">
                <button class="btn btn-primary d-flex" onserverclick="Stop_Click" runat="server">
                    <h2 style="margin: auto;" id="buttonstoptext" runat="server"></h2>
                </button>
                <button class="btn btn-primary d-flex" onserverclick="Next_Click" runat="server">
                    <h2 style="margin: auto;" id="buttonstarttext" runat="server"></h2>
                </button>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.js\"></script>
    <script src="Scripts/jquery-3.6.0.js\"></script>
</body>
</html>
