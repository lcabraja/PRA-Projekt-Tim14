<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InProgressQuizQuestion.aspx.cs" Inherits="Quizkey.InProgressQuizQuestion" ValidateRequest="false" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>
<%@ Register Src="~/User_Controls/QuizCreationAnswer.ascx" TagPrefix="uc1" TagName="QuizCreationAnswer" %>
<%@ Register Src="~/User_Controls/QuizCreationButton.ascx" TagPrefix="uc1" TagName="QuizCreationButton" %>
<%@ Register Src="~/User_Controls/QuizCreationTimeButton.ascx" TagPrefix="uc1" TagName="QuizCreationTimeButton" %>
<%@ Register Src="~/User_Controls/InProgressAnswer.ascx" TagPrefix="uc1" TagName="InProgressAnswer" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quizkey</title>
    <link href="Content/qk-inprogress.css" rel="stylesheet" />
</head>
<body style="height: 100%; /*overflow: hidden*/">
    <form id="form1" runat="server">
        <%--Menu Bar--%>
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <%--Main Container--%>
        <div class="container-fluid qk-quizcreation-grid-container-main mt-3" style="height: 90%;">
            <%--Top Container--%>
            <div style="height:100%;">
                <%--Question--%>
                <div class="bg-secondary rounded d-flex text-center m-auto" style="height: 100%;" >
                    <div class="input-group m-2">
                        <span class="input-group-text">Pitanje</span>
                        <asp:Label CssClass="form-control qk-quizcreation-multiline" ID="lbQuestion" runat="server" />
                    </div>
                </div>
            </div>
            <%--Bottom Container--%>
            <div class="qk-quizcreation-grid-container-bottom">
                <%--Left Arrow--%>
                <div class="qk-quizcreation-left-button d-grid gap-2">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:Timer ID="timetimer" runat="server" />
                    <button id="testbutton" class="btn btn-primary p-2" runat="server"><i class="bi bi-arrow-left-circle"></i></button>
                </div>
                <%--Answers--%>
                <div class="qk-quizcreation-answers">
                    <div class="qk-quizcreation-answers-half pt-0">
                        <uc1:InProgressAnswer Shape="Triangle" runat="server" ID="Answer1" />
                        <uc1:InProgressAnswer Shape="Star" runat="server" ID="Answer2" />
                    </div>
                    <div class="qk-quizcreation-answers-half">
                        <uc1:InProgressAnswer Visible="false" Shape="Pentagon" runat="server" ID="Answer3" />
                        <uc1:InProgressAnswer Visible="false" Shape="Circle" runat="server" ID="Answer4" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
