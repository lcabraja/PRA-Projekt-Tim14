<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaitingRoomAttendee.aspx.cs" Inherits="Quizkey.WaitingRoomAttendee" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quizkey</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <%--Main Container--%>
        <style>
            .box {
                display: flex;
                flex-direction: row;
                flex-wrap: wrap;
            }
        </style>
        <div class="container-fluid qk-quizcreation-grid-container-main">
            <span id="conversation"></span>
            <div class="qk-quizcreation-grid-container-top d-flex">
                <%--Players--%>
                <div class="bg-secondary rounded text-center box mt-3" style="width: 100%; /*height: 79vh; */" id="players" runat="server">
                </div>
                <script>
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
                                window.location.replace("/InProgressQuizQuestionAttendee.aspx");
                            }
                        };
                    };
                </script>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.6.0.min.js"></script>
</body>
</html>
