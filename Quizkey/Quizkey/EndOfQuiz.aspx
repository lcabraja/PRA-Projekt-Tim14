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
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style>
        html {
            height: 100%;
        }

        body {
            height: 100%;
        }

        #form1 {
            height: 100% !important;
        }

        .qk-quizcreation-multiline {
            resize: none;
        }

        .qk-quizcreation-height {
            height: 40px;
        }

        .order {
            flex-direction: column;
            grid-gap: .7rem;
            height: 100%;
            padding: 2rem;
            display: grid;
            grid-template-columns: 30% auto;
        }

        .position-columns {
            display: grid;
            grid-template-columns: 1fr 1fr 1fr;
            grid-gap: 2rem;
        }

        .qk-column {
            display: flex;
            flex-direction: column-reverse;
            flex-wrap: nowrap;
        }

        .rowrowrowyourboat {
            margin-left: 5rem;
            margin-right: 5rem;
            padding-left: 2rem;
            padding-right: 2rem;
            overflow-y: hidden;
        }

        .qk-column-3 {
            display: inline-grid;
            width: 100%;
            height: 30%;
            background-color: chocolate;
            word-wrap: break-word;
        }

        .qk-column-2 {
            display: inline-grid;
            width: 100%;
            height: 60%;
            background-color: silver;
            word-wrap: break-word;
        }

        .qk-column-1 {
            display: inline-grid;
            width: 100%;
            height: 1000%;
            background-color: gold;
            word-wrap: break-word;
        }

        @media (min-width: 576px) {
            html {
                overflow: hidden;
            }

            .qk-quizcreation-grid-container-main {
                display: grid !important;
                grid-gap: 1rem;
                grid-template-rows: 90% 10%;
                height: 89%;
            }

            .qk-quizcreation-grid-container-top {
                display: flex !important;
                grid-gap: 1rem;
                grid-template-columns: auto;
            }

            .qk-quizcreation-grid-container-bottom {
                display: grid !important;
                grid-gap: 1rem;
                grid-template-columns: auto auto;
                margin-bottom: 2rem;
            }

            .qk-quizcreation-answers-half {
                display: grid !important;
                grid-gap: 1rem !important;
                grid-template-columns: 1fr 1fr;
            }

            .qk-quizcreation-answers {
                grid-row: 1 !important;
                grid-column: 2 !important;
                grid-gap: 1rem;
                display: flex;
                flex-direction: column;
                flex-wrap: wrap;
                padding-left: 2rem;
                padding-right: .5rem;
                padding: 0px;
                margin: 0px;
            }

            .qk-quizcreation-left-button {
                grid-row: 1 !important;
                grid-column: 1 !important;
            }

            .qk-quizcreation-right-button {
                grid-row: 1 !important;
                grid-column: 3 !important;
            }

            .qk-quizcreation-fontsize {
                font-size: 2rem;
            }
        }

        qk-quizcreation-answer {
            height: 1rem !important;
            margin: 2rem !important;
        }

        .qk-quizcreation-answers-half {
            display: flex;
            flex-direction: column;
            flex-wrap: nowrap;
            grid-gap: 1rem;
        }

        @media (max-width: 575px) {
            .qk-quizcreation-answers-half {
                padding-top: 16px;
            }
        }

        .qk-quizcreation-grid-container-main {
            display: grid !important;
            grid-gap: 1rem;
            margin-bottom: 2rem;
        }

        .qk-quizcreation-grid-container-top {
            display: flex;
            grid-gap: 1rem;
            flex-direction: column;
        }

        .qk-quizcreation-grid-container-bottom {
            display: grid;
            grid-gap: 1rem;
            grid-template-columns: 1fr 1fr;
            margin-bottom: 2rem;
        }

        .qk-quizcreation-left-button {
            grid-row: 2;
            grid-column: 1;
        }

        .qk-quizcreation-right-button {
            grid-column: 2;
            grid-row: 2;
        }

        .qk-quizcreation-answers {
            grid-column: span 2;
            grid-row: 1;
        }
    </style>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <%--Menu Bar--%>
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <%--Subnav Bar--%>
        <nav class="navbar navbar-light bg-secondary">
            <div class="container-fluid d-flex justify-content-between flex-sm-nowrap">
                <div class="input-group m-1">
                    <span class="input-group-text" id="quiztitle" runat="server"></span>
                    <asp:TextBox ID="tbQuizName" ReadOnly="true" CssClass="form-control" runat="server" />
                </div>
            </div>
        </nav>
        <%--Main Container--%>
        <div class="container-fluid qk-quizcreation-grid-container-main mt-3">
            <%--Top Container--%>
            <div class="qk-quizcreation-grid-container-top">
                <%--Question--%>
                                <style>
                    @media (max-width: 767.98px) {
                        .fold {
                            display: flex;
                            flex-wrap: wrap;
                            flex-direction: row;
                        }

                        .position-columns {
                            display: flex;
                            margin: auto;
                        }

                        .rowrowrowyourboat {
                            margin: auto;
                            overflow-y: hidden;
                        }
                    }
                </style>
                <div class="bg-secondary rounded text-center order fold" id="positioncontainer" runat="server">
                    <div class="position-columns">
                        <div class="qk-column" id="place2" runat="server">
                            <div class="qk-column-2 rounded">
                                <h2 class="pointspoints" id="place2points" runat="server"></h2>
                            </div>
                            <h2 id="place2h2" runat="server"></h2>
                        </div>
                        <div class="qk-column" id="place1" runat="server">
                            <div class="qk-column-1 rounded">
                                <h2 class="pointspoints" id="place1points" runat="server"></h2>
                            </div>
                            <h2 id="place1h2" runat="server"></h2>
                        </div>
                        <div class="qk-column" id="place3" runat="server">
                            <div class="qk-column-3 rounded">
                                <h2 class="pointspoints" id="place3points" runat="server"></h2>
                            </div>
                            <h2 id="place3h2" runat="server"></h2>
                        </div>
                    </div>
                    <div class="rowrowrowyourboat">
                        <div class="p-1" id="runnersup" runat="server">
                        </div>
                    </div>
                </div>
                <%--Time--%>
            </div>
            <%--Bottom Container--%>
            <div class="qk-quizcreation-grid-container-bottom">
                <button class="btn btn-primary d-flex" id="zapisnik" onserverclick="zapisnik_ServerClick" runat="server">
                    <h2 style="margin: auto;" id="log" runat="server"></h2>
                </button>
                <button class="btn btn-primary d-flex" id="end" onserverclick="end_ServerClick" runat="server">
                    <h2 style="margin: auto;" id="endquiz" runat="server"></h2>
                </button>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.6.0.min.js"></script>
</body>
</html>
