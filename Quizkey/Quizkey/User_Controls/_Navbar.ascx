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
</style>

<nav class="navbar navbar-expand-lg navbar-dark bg-dark" style="height:60px !important;">
    <div class="container-fluid">
        <a class="navbar-brand" href="/Default.aspx">Quizkey</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarTogglerDemo02">
            <div class="navbar-nav ms-auto mb-lg-0">
                <div class="input-group" style="height:38px !important;">

                <i class="d-inline-block text-light bg-primary border-primary input-group-text bi bi-translate qk-nav-left"></i>
                <asp:Button ID="ToggleLanguage" CssClass="btn btn-primary qk-nav-right" Text="English" runat="server" />
                </div>
                <a class="nav-link active" aria-current="page" href="#">Home</a>
                <a class="nav-link" href="#">My Profile</a>
                <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true">Disabled</a>
            </div>
        </div>
    </div>
</nav>

<%--<form class="form-inline my-2 my-lg-0">
      <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
      <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
    </form>--%>
