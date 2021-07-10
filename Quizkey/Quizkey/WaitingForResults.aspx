<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaitingForResults.aspx.cs" Inherits="Quizkey.WaitingForResults" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%;">
<head runat="server">
    <title>Quizkey</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body style="height: 100%;">
    <form id="form1" runat="server" style="height: 100%;">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <h1 class="text-center" style="margin-top: 45vh" id="waitingtext" runat="server"></h1>
        <div id="countdowntime" runat="server"></div>
        <script>
            // Gets the number of seconds the question lasts for from the server
            var seconds = parseInt(document.getElementById("countdowntime").getAttribute("seconds"))
            if (seconds == undefined) {
                seconds = 0
            }
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
    <script src="Scripts/bootstrap.js\"></script>
    <script src="Scripts/jquery-3.6.0.js\"></script>
</body>
</html>
