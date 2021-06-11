<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Projekt_za_PRA.Register" %>

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
            <div class="mb-3 row">

                <label for="exampleFormControlInput1" class="form-label">Korisničko ime</label>
                <input type="name" class="form-control" id="exampleFormControlInput1" placeholder="Name">
            </div>
            <div class="mb-3 row">

                <label for="exampleFormControlInput1" class="form-label">E-mail</label>
                <input type="email" class="form-control" id="exampleFormControlInput1" placeholder="name@example.com">
            </div>

            <div class="mb-3 row">

                <label for="exampleFormControlInput1" class="form-label">Zaporka</label>
                <input type="password" class="form-control" id="exampleFormControlInput1" placeholder="password">
            </div>

            <div class="mb-3 row">
                <label for="exampleFormControlInput1" class="form-label">Ponovljena zaporka</label>
                <input type="rpassword" class="form-control" id="exampleFormControlInput1" placeholder="password">
            </div>
            <div class="mb-3 row">
                <button type="registracija" class="btn btn-primary mb-3">Registriraj se</button>
            </div>

        </div>
    </form>
</body>
</html>
