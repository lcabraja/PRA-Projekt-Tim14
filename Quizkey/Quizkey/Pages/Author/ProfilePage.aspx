<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Quizkey.ProfilePage" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vas Profil</title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <div class="mb-5 row">
            <label for="exampleFormControlInput1" class="form-label">Novo korisničko ime</label>
            <input name="name" class="form-control" id="txtNovoKorisnickoIme" placeholder="Name" />
        </div>
        <div class="mb-3 row">
            <button name="promjenikorisnickoime" class="btn btn-primary mb-3">Promjeni korisničko ime</button>
        </div>
        <div class="mb-5 row">
            <label for="exampleFormControlInput1" class="form-label">Nova zaporka</label>
            <input name="password" class="form-control" id="txtNovazaporka" placeholder="Nova zaporka" />
        </div>
        <div class="mb-5 row">
            <label for="exampleFormControlInput1" class="form-label">Ponovite novu zaporku</label>
            <input name="password" class="form-control" id="txtPonovitenovuzaporku" placeholder="Ponovite novu zaporku" />
        </div>
        <div class="mb-3 row">
            <button name="promjenizaporku" class="btn btn-primary mb-3">Promjeni zaporku</button>
        </div>
        <div class="mb-3 row">
            <label for="exampleFormControlInput1" class="form-label">Adresa e-pošte</label>
            <input name="email" class="form-control" id="txtAdresaEPoste" placeholder="name@example.com" />
        </div>
        <div class="mb-3 row">
            <button name="izbriširačun" class="btn btn-primary mb-3">Izbriši račun</button>
        </div>
    </form>
</body>
</html>
