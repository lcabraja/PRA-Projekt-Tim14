<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizCreation.aspx.cs" Inherits="Quizkey.QuizCreation" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quizkey</title>
    <link href="Content/qk-quizcreation.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <%--Menu Bar--%>
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <%--Subnav Bar--%>
        <nav class="navbar navbar-light bg-secondary">
            <div class="container-fluid d-flex justify-content-between flex-sm-nowrap">
                <div class="input-group m-1">
                    <span class="input-group-text">Naziv Kviza</span>
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
                            <i class="bi bi-triangle qk-quizcreation-fontsize"></i>
                        </button>
                        <button id="Button3" class="btn btn-primary" runat="server">
                            <i class="bi bi-star qk-quizcreation-fontsize"></i>
                        </button>
                        <button id="Button4" class="btn btn-light" runat="server">
                            <i class="bi bi-pentagon-fill qk-quizcreation-fontsize"></i>
                        </button>
                        <button id="Button5" class="btn btn-primary" runat="server">
                            <i class="bi bi-circle qk-quizcreation-fontsize"></i>
                        </button>
                    </div>
                </div>
                <%--Question--%>
                <div class="bg-secondary rounded d-flex text-center">
                    <div class="input-group m-2">
                        <span class="input-group-text">Pitanje</span>
                        <asp:TextBox TextMode="MultiLine" CssClass="form-control qk-quizcreation-multiline" runat="server" />
                    </div>
                </div>
                <%--Time--%>
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
                            <asp:TextBox Enabled="false" CssClass="form-control" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <%--Bottom Container--%>
            <div class="qk-quizcreation-grid-container-bottom">
                <%--Left Arrow--%>
                <div class="qk-quizcreation-left-button d-grid gap-2">
                    <button id="testbutton" class="btn btn-primary p-2" runat="server"><i class="bi bi-arrow-left-circle"></i></button>
                </div>
                <%--Answers--%>
                <div class="qk-quizcreation-answers">
                    <div class="qk-quizcreation-answers-half pt-0">
                        <div class="bg-dark text-light p-2 d-flex flex-nowrap gap-2 rounded">
                            <i class="bi bi-triangle m-auto qk-quizcreation-fontsize"></i>
                            <asp:TextBox CssClass="form-control m-auto qk-quizcreation-answer" runat="server" />
                        </div>
                        <div class="bg-dark text-light p-2 d-flex flex-nowrap gap-2 rounded">
                            <i class="bi bi-star m-auto qk-quizcreation-fontsize"></i>
                            <asp:TextBox CssClass="form-control m-auto qk-quizcreation-answer" runat="server" />
                        </div>
                    </div>
                    <div class="qk-quizcreation-answers-half">
                        <div class="bg-dark text-light p-2 d-flex flex-nowrap gap-2 rounded">
                            <i class="bi bi-pentagon-fill m-auto qk-quizcreation-fontsize"></i>
                            <asp:TextBox CssClass="form-control m-auto qk-quizcreation-answer" runat="server" />
                        </div>
                        <div class="bg-dark text-light p-2 d-flex flex-nowrap gap-2 rounded">
                            <i class="bi bi-circle m-auto qk-quizcreation-fontsize m-auto"></i>
                            <asp:TextBox CssClass="form-control m-auto qk-quizcreation-answer" runat="server" />
                        </div>
                    </div>
                </div>
                <%--Right Arrow--%>
                <div class="text-center qk-quizcreation-right-button d-grid gap-2">
                    <button id="Button1" class="btn btn-primary p-2" runat="server"><i class="bi bi-arrow-right-circle"></i></button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
