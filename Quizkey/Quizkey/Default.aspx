<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Quizkey.Default" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <style>
                a {
                    margin-right: 2rem;
                }
            </style>
            <uc1:_Navbar runat="server" ID="_Navbar" />
            <asp:HyperLink NavigateUrl="QuizCreation.aspx" Text="Create new Quiz" CssClass="a" runat="server" />
            <asp:LinkButton Text="QuizCreation + Code of Quiz to edit" OnClick="Unnamed_Click" runat="server" />
            <asp:HyperLink NavigateUrl="WaitingRoom.aspx" Text="Waiting Room" CssClass="a" runat="server" />
            <asp:HyperLink NavigateUrl="InProgressQuizQuestion.aspx" Text="In Progress Quiz Question" CssClass="a" runat="server" />
            <asp:HyperLink NavigateUrl="InProgressQuizQuestionAttendee.aspx" Text="In Progress Attendee Quiz Question" CssClass="a" runat="server" />
            <asp:HyperLink NavigateUrl="Pages/Author/HomePage.aspx" Text="HomePage" CssClass="a" runat="server" />
        </div>
    </form>
</body>
</html>
