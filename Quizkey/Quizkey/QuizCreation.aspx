<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizCreation.aspx.cs" Inherits="Quizkey.QuizCreation" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .qk-quizcreation-height {
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:_Navbar runat="server" ID="_Navbar" />
            <nav class="navbar navbar-light bg-secondary">
                <div class="container-fluid d-flex justify-content-between flex-sm-nowrap">
                    <div class="input-group m-1">
                        <span class="input-group-text" id="basic-addon1">Naziv Kviza</span>
                        <asp:TextBox CssClass="form-control" runat="server" />
                    </div>
                    <div class="d-flex m-1">
                        <asp:Button Text="Save" CssClass="btn btn-warning me-1" runat="server" />
                        <asp:Button Text="Discard" CssClass="btn btn-danger mx-1" runat="server" />
                    </div>
                </div>
            </nav>
        </div>
    </form>
</body>
</html>
