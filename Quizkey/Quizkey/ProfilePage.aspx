<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Projekt_za_PRA.ProfilePage" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:_Navbar runat="server" ID="_Navbar" />

        <div class="mb-5 row">

            <label for="exampleFormControlInput1" class="form-label">Novo korisničko ime</label>
            <input type="name" class="form-control" id="exampleFormControlInput1" placeholder="Name" />
        </div>
        <div class="mb-3 row">
            <button type="promjenikorisnickoime" class="btn btn-primary mb-3">Promjeni korisničko ime</button>
        </div>

        <div class="mb-5 row">

            <label for="exampleFormControlInput1" class="form-label">Nova zaporka</label>
            <input type="password" class="form-control" id="exampleFormControlInput1" placeholder="Nova zaporka" />
        </div>
        <div class="mb-5 row">

            <label for="exampleFormControlInput1" class="form-label">Ponovite novu zaporku</label>
            <input type="password" class="form-control" id="exampleFormControlInput1" placeholder="Ponovite novu zaporku" />
        </div>
        <div class="mb-3 row">
            <button type="promjenizaporku" class="btn btn-primary mb-3">Promjeni zaporku</button>
        </div>
        <div class="mb-3 row">

            <label for="exampleFormControlInput1" class="form-label">Adresa e-pošte</label>
            <input type="email" class="form-control" id="exampleFormControlInput1" placeholder="name@example.com" />
        </div>
        <div class="mb-3 row">
            <button type="izbriširačun" class="btn btn-primary mb-3">Izbriši račun</button>
        </div>
    </form>
</body>
</html>
