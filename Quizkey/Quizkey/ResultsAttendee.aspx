<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultsAttendee.aspx.cs" Inherits="Quizkey.ResultsAttendee" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


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
                    <span class="input-group-text" id="quiztitletext" runat="server"></span>
                    <asp:TextBox ID="tbQuizName" ReadOnly="true" CssClass="form-control" runat="server" />
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
            </div>
            <%--Bottom Container--%>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.6.0.min.js"></script>
</body>
</html>
