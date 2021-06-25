<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuizCreationAnswer.ascx.cs" Inherits="Quizkey.QuizCreationAnswer" %>
<div class="bg-dark text-light p-2 d-flex flex-nowrap gap-2 rounded">
    <asp:PlaceHolder ID="placeHolder" runat="server" />
    <asp:TextBox ID="tbAnswer" CssClass="form-control m-auto qk-quizcreation-answer" runat="server" />
</div>
