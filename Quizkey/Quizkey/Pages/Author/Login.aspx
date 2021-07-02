<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Quizkey.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="mb-5 row">
                <label for="exampleFormControlInput1" class="form-label">Korisničko ime</label>
                <input type="name" class="form-control" id="txtKorisnicko" placeholder="Name">
            </div>
            <div class="mb-3 row">
                <label for="exampleFormControlInput1" class="form-label">Zaporka</label>
                <input type="password" class="form-control" id="txtZapo" placeholder="password">
            </div>
            <div class="mb-3 row">
                <button type="prijava" class="btn btn-primary mb-3">Prijavi se</button>
            </div>
            <div class="mb-3 row">
                <button type="obnova" class="btn btn-primary mb-3">Zaboravljena lozinka</button>
            </div>
        </div>
    </form>
</body>
</html>
