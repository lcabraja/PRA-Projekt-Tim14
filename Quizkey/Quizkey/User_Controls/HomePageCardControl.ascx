<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomePageCardControl.ascx.cs" Inherits="Quizkey.User_Controls.HomePageCardControl" %>
<div class="card" style="width: 18rem;">
    <div class="card-body">
        <asp:PlaceHolder ID="placeholdertitle" runat="server" />
        <p class="card-text" id="questionnumber" runat="server"></p>
        <asp:LinkButton onclick="Play_Click" Text="Play" runat="server" />
        <asp:LinkButton onclick="Edit_Click" Text="Edit" runat="server" />
        <asp:LinkButton onclick="Delete_Click" Text="Delete" runat="server" />
    </div>
</div>
