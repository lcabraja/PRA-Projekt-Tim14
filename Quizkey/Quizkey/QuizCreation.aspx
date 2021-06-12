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

        .qk-quizcreation-grid-container-main {
            display: grid !important;
            grid-gap: 1rem;
            grid-template-rows: 60% 40%;
        }

        .qk-quizcreation-grid-container-top {
            display: flex;
            flex-direction: column;
        }

        @media (min-width: 576px) {
            .qk-quizcreation-grid-container-top {
                display: grid !important;
                grid-gap: 1rem;
                grid-template-columns: 20% auto 20%;
            }

            .qk-quizcreation-grid-container-bottom {
                display: grid !important;
                grid-gap: 1rem;
                grid-template-columns: 5% auto 5% !important;
            }

            .qk-quizcreation-left-button {
                grid-row: 1 !important;
                grid-column: 1 !important;
            }

            .qk-quizcreation-answers {
                grid-row: 1 !important;
                grid-column: 2 !important;
            }

            .qk-quizcreation-right-button {
                grid-row: 1 !important;
                grid-column: 3 !important;
            }

            .qk-quizcreation-fontsize {
                font-size: 2rem;
            }
        }

        .qk-quizcreation-grid-container-bottom {
            display: grid;
            grid-gap: 1rem;
            grid-template: 1fr 1fr / 1fr 1fr;
        }

        .qk-quizcreation-left-button {
            grid-row: 2;
            grid-column: 1
        }

        .qk-quizcreation-right-button {
            grid-column: 2;
            grid-row: 2;
        }

        .qk-quizcreation-answers {
            grid-column: span 2;
            grid-row: 1;
        }
    </style>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <%--Menu Bar--%>
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <%--Subnav Bar--%>
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
        <%--Main Container--%>
        <div class="container-fluid qk-quizcreation-grid-container-main mt-3">
            <%--Top Container--%>
            <div class="qk-quizcreation-grid-container-top">
                <div class="bg-secondary rounded p-2 d-flex flex-column justify-content-between">
                    <p class="text-center">
                        Odaberite tocan odgovor
                    </p>
                    <div class="d-grid gap-2 text-center">
                        <button id="Button2" class="btn btn-primary" runat="server">
                            <i class="bi bi-triangle-fill qk-quizcreation-fontsize"></i>
                        </button>
                        <button id="Button3" class="btn btn-primary" runat="server">
                            <i class="bi bi-star-fill qk-quizcreation-fontsize"></i>
                        </button>
                        <button id="Button4" class="btn btn-primary" runat="server">
                            <i class="bi bi-pentagon-fill qk-quizcreation-fontsize"></i>
                        </button>
                        <button id="Button5" class="btn btn-primary" runat="server">
                            <i class="bi bi-circle-fill qk-quizcreation-fontsize"></i>
                        </button>
                    </div>
                </div>
                <div class="bg-info">
                    pitanje here plz
                </div>
                <div class="bg-secondary rounded">
                    <div class="p-2">
                        <p class="text-center">
                            Odaberite vremensko ogranicenje
                        </p>
                        <div class="d-flex flex-column gap-2 text-center">
                            <button id="Button6" class="btn btn-primary" runat="server">
                                120 sekundi
                            </button>
                            <button id="Button7" class="btn btn-primary" runat="server">
                                60 sekundi
                            </button>
                            <button id="Button8" class="btn btn-primary" runat="server">
                                30 sekundi
                            </button>
                            <button id="Button9" class="btn btn-primary" runat="server">
                                15 sekundi
                            </button>
                            <button id="Button10" class="btn btn-primary" runat="server">
                                proizvoljno
                            </button>
                            <asp:TextBox CssClass="form-control" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <%--Bottom Container--%>
            <div class="qk-quizcreation-grid-container-bottom">
                <div class="qk-quizcreation-left-button d-grid gap-2">
                    <button id="testbutton" class="btn btn-primary" runat="server"><i class="bi bi-arrow-left-circle"></i></button>
                </div>
                <div class="bg-info qk-quizcreation-answers">
                    odgovori here
                </div>
                <div class="text-center qk-quizcreation-right-button d-grid gap-2">
                    <button id="Button1" class="btn btn-primary" runat="server"><i class="bi bi-arrow-right-circle"></i></button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
