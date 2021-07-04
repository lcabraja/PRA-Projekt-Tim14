<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InProgressQuizQuestionAttendee.aspx.cs" Inherits="Quizkey.InProgressQuizQuestionAttendee" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>
<%@ Register Src="~/User_Controls/QuizCreationAnswer.ascx" TagPrefix="uc1" TagName="QuizCreationAnswer" %>
<%@ Register Src="~/User_Controls/QuizCreationButton.ascx" TagPrefix="uc1" TagName="QuizCreationButton" %>
<%@ Register Src="~/User_Controls/QuizCreationTimeButton.ascx" TagPrefix="uc1" TagName="QuizCreationTimeButton" %>
<%@ Register Src="~/User_Controls/InProgressAnswer.ascx" TagPrefix="uc1" TagName="InProgressAnswer" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%;">
<head runat="server">
    <title>Quizkey</title>
    <link href="Content/qk-inprogress.css" rel="stylesheet" />
    <style>
        .gridcontainer {
            height: 100%;
            display: grid;
            grid-template-columns: auto auto;
            grid-gap: 2rem;
        }
        .question {
            width: 100%;
            height: 100%;
        }
        .fontsize {
            font-size: 10vw;
        }
    </style>
</head>
<body style="height: 100%; /*overflow: hidden*/">
    <form id="form1" runat="server" style="height: 100%;">
        <%--Menu Bar--%>
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <%--Main Container--%>
        <div class="m-3" style="height: 90vh;">
            <div class="gridcontainer">
                <button runat="server" onserverclick="btTriangle_ServerClick" id="btTriangle" class="btn btn-primary question"><i class="fontsize bi bi-triangle "></i></button>
                <button runat="server" onserverclick="btStar_ServerClick" id="btStar" class="btn btn-primary question"><i class="fontsize bi bi-star"></i></button>
                <button runat="server" visible="false" onserverclick="btPentagon_ServerClick" id="btPentagon" class="btn btn-primary question"><i class="fontsize bi bi-pentagon"></i></button>
                <button runat="server" visible="false" onserverclick="btCircle_ServerClick" id="btCircle" class="btn btn-primary question"><i class="fontsize bi bi-circle"></i></button>
            </div>
        </div>
        <div id="countdowntime" runat="server"></div>
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
                //document.getElementById("countdowntime").innerHTML = seconds + "s ";

                // If the count down is finished, write some text
                if (distance < 0) {
                    clearInterval(x);
                    //document.getElementById("countdowntime").innerHTML = "0s";
                    window.location.replace("ResultsAttendee.aspx");
                }
            }, 1000);
        </script>
    </form>
</body>
</html>
