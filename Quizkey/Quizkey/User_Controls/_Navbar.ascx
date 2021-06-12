<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_Navbar.ascx.cs" Inherits="Quizkey.Navbar" %>

<style>
    .qk-nav-left {
        border-bottom-right-radius: 0;
        border-top-right-radius: 0;
        display: inline;
    }

    .qk-nav-right {
        border-bottom-left-radius: 0;
        border-top-left-radius: 0;
        display: inline;
    }

    .qk-nav-input-group {
        display: flex;
        flex-wrap: wrap;
        align-items: stretch;
    }
    .bi-door-closed:hover::before {
        content: "\f308" !important;
    }
</style>

<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
    <div class="container-fluid justify-content-xl-between justify-content-lg-between">
        <a class="navbar-brand text-secondary d-none d-sm-block" href="/Default.aspx">Quizkey</a>
        <div id="welcomeText" class="navbar-brand p-0 me-auto d-flex justify-content-center align-content-center flex-nowrap" runat="server"></div>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarTogglerDemo02">
            <div id="navbarbutton" class="navbar-nav ms-auto mb-lg-0 mx-1 qk-nav-grid" runat="server">
                <span id="quizcode" visible="false" class="text-secondary nav-link px-1 text-light" runat="server"></span>
                <div id="navbarLinks" class="navbar-nav px-1" runat="server">
                </div>
                <div class="qk-nav-input-group px-1">
                    <i class="text-light bg-primary border-primary input-group-text bi bi-translate qk-nav-left"></i>
                    <asp:Button ID="btToggleLanguage" OnClick="btToggleLanguage_Click" CssClass="btn btn-primary qk-nav-right" runat="server" />
                </div>
                <div id="logout" visible="false" class="qk-nav-input-group px-1" runat="server">
                    <i class="text-light bg-danger border-danger input-group-text bi bi-door-closed qk-nav-left"></i>
                    <asp:Button ID="btLogOut" OnClick="btLogOut_Click" CssClass="btn btn-danger qk-nav-right" Text="Logout" runat="server" />
                </div>
            </div>
        </div>
    </div>
</nav>
