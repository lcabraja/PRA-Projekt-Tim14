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
            <uc1:_Navbar runat="server" ID="_Navbar" />
            <asp:HyperLink NavigateUrl="QuizCreation.aspx" Text="Create new Quiz" CssClass="a" runat="server" />
            <asp:LinkButton Text="text" OnClick="Unnamed_Click" runat="server" />
        </div>
    </form>
</body>
</html>
