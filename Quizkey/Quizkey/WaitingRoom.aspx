﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaitingRoom.aspx.cs" Inherits="Quizkey.WaitingRoom" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>
<%@ Register Src="~/User_Controls/QuizCreationAnswer.ascx" TagPrefix="uc1" TagName="QuizCreationAnswer" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quizkey</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/qk-quizcreation.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <%--Menu Bar--%>
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <%--Subnav Bar--%>
        <div class="container-fluid qk-quizcreation-grid-container-main">
            <div class="navbar navbar-light bg-secondary mt-3 p-2 rounded">
                <div class="input-group m-1">
                    <span class="input-group-text" id="codeText" runat="server"></span>
                    <asp:TextBox ID="tbQuizName" TextMode="SingleLine" ReadOnly="true" CssClass="form-control" runat="server" />
                    <button onclick="location.reload(true)" class="btn btn-light border border-white">
                        <i class="bi bi-arrow-repeat"></i>
                    </button>
                </div>
            </div>
        </div>
        <%--Main Container--%>
        <style>
            .box {
                display: flex;
                flex-direction: row;
                flex-wrap: wrap;
            }
        </style>
        <div class="container-fluid qk-quizcreation-grid-container-main">
            <div class="qk-quizcreation-grid-container-top d-flex">
                <%--Players--%>
                <div class="bg-secondary rounded text-center box" style="width: 100%; /*height: 79vh; */" id="players" runat="server">
                </div>
            </div>
        </div>
        <%--Subnav Bar--%>
        <nav class="navbar navbar-light bg-secondary" style="position: fixed; bottom: 0; width: 100%;">
            <div class="container-fluid d-flex justify-content-between flex-sm-nowrap">
                <div class="d-flex m-1 m-auto" style="align-self: center;">
                    <asp:Button ID="Button1" CssClass="btn btn-light mx-1" OnClick="Start_Click" runat="server" />
                </div>
                <div class="d-flex m-1">
                    <asp:Button ID="Odustani" CssClass="btn btn-danger mx-1" OnClientClick="return confirm('Jeste li sigurni?');" OnClick="Odustani_Click" runat="server" />
                </div>
            </div>
        </nav>
    </form>
    <script src="Scripts/bootstrap.js\"></script>
    <script src="Scripts/jquery-3.6.0.js\"></script>
</body>
</html>
