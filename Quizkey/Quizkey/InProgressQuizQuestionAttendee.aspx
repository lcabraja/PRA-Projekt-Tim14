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
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
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
                <button runat="server" onserverclick="btStar_ServerClick" id="btStar" class="btn btn-success question"><i class="fontsize bi bi-star"></i></button>
                <button runat="server" visible="false" onserverclick="btPentagon_ServerClick" id="btPentagon" class="btn btn-warning question"><i class="fontsize bi bi-pentagon"></i></button>
                <button runat="server" visible="false" onserverclick="btCircle_ServerClick" id="btCircle" class="btn btn-danger question"><i class="fontsize bi bi-circle"></i></button>
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
                }
            }, 1000);

            var ws;

            function _$$(id) {
                return document.getElementById(id);
            }

            function createSpan(text) {
                var span = document.createElement('span');
                span.innerHTML = text + '‹br />';
                return span;
            }

            function getCookie(cname) {
                let name = cname + "=";
                let decodedCookie = decodeURIComponent(document.cookie);
                let ca = decodedCookie.split(';');
                for (let i = 0; i < ca.length; i++) {
                    let c = ca[i];
                    while (c.charAt(0) == ' ') {
                        c = c.substring(1);
                    }
                    if (c.indexOf(name) == 0) {
                        return c.substring(name.length, c.length);
                    }
                }
                return "";
            }

            window.onload = function () {
                //wireEvents();
                var conversation = _$$('conversation');
                var url = `ws://${window.location.host}/WebSocketEndpoint.ashx`;
                ws = new WebSocket(url);

                ws.onerror = function (e) {
                    conversation.appendChild(createSpan('There is a problem with the connection.'))
                };

                ws.onmessage = function (e) {
                    if (e.data.split('-')[1] == getCookie("sessionid")) {
                        if (e.data.split('-')[0] == "movesession") {
                            window.location.replace("/InProgressQuizQuestionAttendee.aspx?advance=1");
                        }
                        if (e.data.split('-')[0] == "endsession") {
                            window.location.replace("/EndOfQuizAttendee.aspx");
                        }
                    }
                };
            };
        </script>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.6.0.min.js"></script>
</body>
</html>
