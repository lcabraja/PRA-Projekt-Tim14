<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EndOfQuiz.aspx.cs" Inherits="Quizkey.EndOfQuiz" %>

<!DOCTYPE html>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>
<%@ Register Src="~/User_Controls/QuizCreationAnswer.ascx" TagPrefix="uc1" TagName="QuizCreationAnswer" %>
<%@ Register Src="~/User_Controls/QuizCreationButton.ascx" TagPrefix="uc1" TagName="QuizCreationButton" %>
<%@ Register Src="~/User_Controls/QuizCreationTimeButton.ascx" TagPrefix="uc1" TagName="QuizCreationTimeButton" %>
<%@ Register Src="~/User_Controls/QuizResultsPosition.ascx" TagPrefix="uc1" TagName="QuizResultsPosition" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quizkey</title>
    <link href="Content/qk-endofquiz.css" rel="stylesheet" />
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
                <div class="bg-secondary rounded text-center order" id="positioncontainer" runat="server">
                    <div class="position-columns">
                        <div class="qk-column" id="place2" runat="server">2</div>
                        <div class="qk-column" id="place1" runat="server">1</div>
                        <div class="qk-column" id="place3" runat="server">3</div>
                    </div>
                    <div class="rowrowrowyourboat">
                        <div class="bg-light rounded"><h2 class="d-grid">testvaleusad</h2></div>
                    </div>
                </div>
                <%--Time--%>
            </div>
            <%--Bottom Container--%>
            <div class="qk-quizcreation-grid-container-bottom">
                <button class="btn btn-primary d-flex"  runat="server"><h2 style="margin: auto;">Prekini Kviz</h2></button>
                <button class="btn btn-primary d-flex"  runat="server"><h2 style="margin: auto;">Pokreni Slijedece Pitanje</h2></button>
            </div>
        </div>
    </form>
</body>
</html>
