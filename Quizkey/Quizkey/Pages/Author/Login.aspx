<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Quizkey.Login" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prijava</title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <div class="container">
            <div class="mb-5 row">
                <label for="exampleFormControlInput1" class="form-label">Korisničko ime</label>
                <input name="name" class="form-control" id="txtKorisnicko" placeholder="Name" />
            </div>
            <div class="mb-3 row">
                <label for="exampleFormControlInput1" class="form-label">Zaporka</label>
                <input name="password" class="form-control" id="txtZapo" placeholder="password" />
            </div>
            <div class="mb-3 row">
                <button name="prijava" class="btn btn-primary mb-3">Prijavi se</button>
            </div>
            <div class="mb-3 row">
                <button name="obnova" class="btn btn-primary mb-3">Zaboravljena lozinka</button>
            </div>
        </div>
    </form>
</body>
</html>
