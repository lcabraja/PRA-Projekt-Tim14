﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InProgressQuizQuestion.aspx.cs" Inherits="Quizkey.InProgressQuizQuestion" ValidateRequest="false" %>

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
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body style="height: 100%; /*overflow: hidden*/">
    <form id="form1" runat="server">
        <%--Menu Bar--%>
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <%--Main Container--%>
        <div class="container-fluid qk-quizcreation-grid-container-main mt-3" style="height: 90%;">
            <%--Top Container--%>
            <div style="height: 100%;">
                <%--Question--%>
                <div class="bg-secondary rounded d-flex text-center m-auto" style="height: 100%;">
                    <div class="input-group m-2">
                        <span class="input-group-text" id="pitanjetext" runat="server"></span>
                        <asp:Textbox CssClass="form-control qk-quizcreation-multiline" ReadOnly="true" ID="tbQuestion" runat="server" />
                    </div>
                </div>
            </div>
            <%--Bottom Container--%>
            <div class="qk-quizcreation-grid-container-bottom">
                <%--Left Arrow--%>
                <div class="qk-quizcreation-left-button d-grid gap-2">
                    <div id="countdowntime" class="btn btn-primary p-2" runat="server"></div>
                    <asp:PlaceHolder ID="placeholder" runat="server" />
                    <script>
                        // Gets the number of seconds the question lasts for from the server
                        var seconds = parseInt(document.getElementById("countdowntime").getAttribute("seconds"))
                        // Set the date we're counting down to
                        var countDownDate = new Date().setSeconds(new Date().getSeconds() + seconds)

                        // Update the count down every 1 second
                        var x = setInterval(function () {

                            // Get today's date and time
                            var now = new Date().getTime();

                            // Find the distance between now and the count down date
                            var distance = countDownDate - now;

                            // Time calculations for days, hours, minutes and seconds
                            var seconds = Math.floor((distance % (1000 * 60)) / 1000);

                            // Display the result in the element with id="demo"
                            document.getElementById("countdowntime").innerHTML = seconds + "s ";

                            // If the count down is finished, write some text
                            if (distance < 0) {
                                clearInterval(x);
                                document.getElementById("countdowntime").innerHTML = "0s";
                                window.location.replace("InProgressQuizQuestion.aspx?nextpage=1");
                            }
                        }, 1000);
                    </script>
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
    <script src="Scripts/bootstrap.js\"></script>
    <script src="Scripts/jquery-3.6.0.js\"></script>
</body>
</html>
