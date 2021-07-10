<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizCreation.aspx.cs" Inherits="Quizkey.QuizCreation" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>
<%@ Register Src="~/User_Controls/QuizCreationAnswer.ascx" TagPrefix="uc1" TagName="QuizCreationAnswer" %>
<%@ Register Src="~/User_Controls/QuizCreationButton.ascx" TagPrefix="uc1" TagName="QuizCreationButton" %>
<%@ Register Src="~/User_Controls/QuizCreationTimeButton.ascx" TagPrefix="uc1" TagName="QuizCreationTimeButton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quizkey</title>
    <link href="Content/qk-quizcreation.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-icons-1.5.0/bootstrap-icons.css" rel="stylesheet" />
    <%--<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css" />--%>
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
                <div class="d-flex m-1">
                    <asp:Button ID="btSave" CssClass="btn btn-warning me-1" OnClick="Save_Click" runat="server" />
                    <asp:Button ID="btDiscard" CssClass="btn btn-danger mx-1" OnClick="Discard_Click" runat="server" />
                </div>
            </div>
        </nav>
        <%--Main Container--%>
        <div class="container-fluid qk-quizcreation-grid-container-main mt-3">
            <%--Top Container--%>
            <div class="qk-quizcreation-grid-container-top">
                <div class="bg-secondary rounded p-2 d-flex flex-column justify-content-between">
                    <p class="text-center" id="localCorrectAnswer" runat="server"></p>
                    <script src="Scripts/CustomScripts/QuizCreationButtonScript.js"></script>
                    <div class="d-grid gap-2 text-center">
                        <uc1:QuizCreationButton Shape="triangle" runat="server" ID="QuizCreationButton1" />
                        <uc1:QuizCreationButton Shape="star" runat="server" ID="QuizCreationButton2" />
                        <uc1:QuizCreationButton Visible="false" Shape="pentagon" runat="server" ID="QuizCreationButton3" />
                        <uc1:QuizCreationButton Visible="false" Shape="circle" runat="server" ID="QuizCreationButton4" />
                    </div>
                </div>
                <%--Question--%>
                <div class="bg-secondary rounded d-flex text-center">
                    <div class="input-group m-2">
                        <span class="input-group-text" id="localquestion" runat="server"></span>
                        <asp:TextBox TextMode="MultiLine" CssClass="form-control qk-quizcreation-multiline" ID="tbQuestion" runat="server" />
                    </div>
                </div>
                <%--Time--%>
                <div class="bg-secondary rounded">
                    <div class="p-2">
                        <p class="text-center" id="localTimeLimit" runat="server"></p>
                        <div class="d-flex flex-column gap-2 text-center">
                            <uc1:QuizCreationTimeButton Seconds="120" runat="server" ID="QuizCreationTimeButton1" />
                            <uc1:QuizCreationTimeButton Seconds="60" runat="server" ID="QuizCreationTimeButton2" />
                            <uc1:QuizCreationTimeButton Seconds="30" runat="server" ID="QuizCreationTimeButton3" />
                            <uc1:QuizCreationTimeButton Seconds="15" runat="server" ID="QuizCreationTimeButton4" />
                            <button id="ButtonCustomTime" onserverclick="ButtonCustomTime_ServerClick" class="btn btn-primary" runat="server"></button>
                            <asp:TextBox Enabled="true" AutoCompleteType="None" TextMode="Number" CssClass="form-control" ID="TextboxCustomTime" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <%--Bottom Container--%>
            <div class="qk-quizcreation-grid-container-bottom">
                <%--Left Arrow--%>
                <div class="qk-quizcreation-left-button d-grid gap-2">
                    <button onserverclick="Left_ServerClick" id="testbutton" class="btn btn-primary p-2" runat="server"><i class="bi bi-arrow-left-circle"></i></button>
                </div>
                <%--Answers--%>
                <div class="qk-quizcreation-answers">
                    <style>
                        .bi-plus-circle:hover::before {
                            content: "\f4f9" !important;
                        }

                        .bi-x-circle:hover::before {
                            content: "\f622" !important;
                        }
                    </style>
                    <div class="qk-quizcreation-answers-half pt-0">
                        <uc1:QuizCreationAnswer Shape="triangle" runat="server" ID="QuizCreationAnswer1" />
                        <uc1:QuizCreationAnswer Shape="star" runat="server" ID="QuizCreationAnswer2" />
                    </div>
                    <div class="qk-quizcreation-answers-half">
                        <uc1:QuizCreationAnswer Enabled="true" Shape="pentagon" runat="server" ID="QuizCreationAnswer3" />
                        <uc1:QuizCreationAnswer Enabled="true" Visible="false" Shape="circle" runat="server" ID="QuizCreationAnswer4" />
                    </div>
                </div>
                <%--Right Arrow--%>
                <div class="text-center qk-quizcreation-right-button d-grid gap-2">
                    <button id="Button1" onserverclick="Right_ServerClick" class="btn btn-primary p-2" runat="server"><i class="bi bi-arrow-right-circle"></i></button>
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.6.0.min.js"></script>
</body>
</html>
