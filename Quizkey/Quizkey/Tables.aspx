﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tables.aspx.cs" Inherits="Quizkey.Tables" %>

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
        <div class="container">
            <asp:Repeater ID="QuizRepeater" runat="server">
                <HeaderTemplate>
                    <table border="1" class="table">
                        <tr>
                            <td><b>Quiz name</b></td>
                            <td><b># of questions</b></td>
                            <td><b># of times played</b></td>
                            <td><b>Actions</b></td>
                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "QuizName") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "NumberOfQuestions") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "TimesPlayed") %> </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "PlayButton") %>
                            <%# DataBinder.Eval(Container.DataItem, "EditButton") %>
                            <%# DataBinder.Eval(Container.DataItem, "DeleteButton") %> 
                        </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
            <asp:Repeater ID="LogsRepeater" runat="server">
                <HeaderTemplate>
                    <table border="1" class="table">
                        <tr>
                            <td><b>Session code</b></td>
                            <td><b>Quiz topic</b></td>
                            <td><b># players</b></td>
                            <td><b>Time played</b></td>
                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "SessionCode") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "QuizName") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "NumberOfPlayers") %> </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
            <asp:Repeater ID="LogRepeater" runat="server">
                <HeaderTemplate>
                    <table border="1" class="table">
                        <h2 id="logheader"></h2>
                        <tr>
                            <td><b>Player</b></td>
                            <td><b>Question</b></td>
                            <td><b>Selected Answer</b></td>
                            <td><b>Points awarded</b></td>
                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "Player") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Question") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Answer") %> </td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Points") %> </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
        </div>
    </form>
    <script src="Scripts/bootstrap.js\"></script>
    <script src="Scripts/jquery-3.6.0.js\"></script>
</body>
</html>
