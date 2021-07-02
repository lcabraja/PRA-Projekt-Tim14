<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Quizkey.Register" %>

<%@ Register Src="~/User_Controls/_Navbar.ascx" TagPrefix="uc1" TagName="_Navbar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%;">
<head runat="server">
    <title>Registriraj se</title>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
</head>
<body style="height: 100%;">
    <form id="form1" runat="server" style="height: 100%;">
        <uc1:_Navbar runat="server" ID="_Navbar" />
        <div class="container m-auto mt-4">
            <asp:HiddenField ID="hfUserID" runat="server" />
            <div class="mb-3 row">
                <label for="exampleFormControlInput1" class="form-label">Korisničko ime</label>
                <input name="name" class="form-control" id="txtKorisnickoIme" placeholder="Name"/>
            </div>
            <div class="mb-3 row">
                <label for="exampleFormControlInput1" class="form-label">E-mail</label>
                <input name="email" class="form-control" id="txtEmail" placeholder="name@example.com"/>
            </div>

            <div class="mb-3 row">

                <label for="exampleFormControlInput1" class="form-label">Zaporka</label>
                <input name="password" class="form-control" id="txtZaporka" placeholder="password"/>
            </div>

            <div class="mb-3 row">
                <label for="exampleFormControlInput1" class="form-label">Ponovljena zaporka</label>
                <input name="rpassword" class="form-control" id="txtPonovljenazaporka" placeholder="password"/>
            </div>
            <div class="mb-3 row">
                <button name="registracija" class="btn btn-primary mb-3">Registriraj se</button>
            </div>
        </div>
    </form>
</body>
</html>
