<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Quizkey.ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Quizkey</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="#">Dobrodošli  </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Korisničko ime</a>
                        </li>

                    </ul>
                    <form class="d-flex">
                        <button class="btn btn-outline-success" type="submit">Odjavi se</button>
                        <button class="btn btn-outline-success" type="submit">Moj profil</button>
                        <button class="btn btn-outline-success" type="submit">Moji kvizovi</button>
                        <button class="btn btn-outline-success" type="submit">Moji zapisnici</button>
                        <button class="btn btn-outline-success" type="submit">JEZIK</button>
                    </form>
                </div>
            </div>
        </nav>

        <div class="mb-5 row">

            <label for="exampleFormControlInput1" class="form-label">Novo korisničko ime</label>
            <input type="name" class="form-control" id="txtNovoKorisnickoIme" placeholder="Name">
        </div>
        <div class="mb-3 row">
            <button type="promjenikorisnickoime" class="btn btn-primary mb-3">Promjeni korisničko ime</button>
        </div>

        <div class="mb-5 row">

            <label for="exampleFormControlInput1" class="form-label">Nova zaporka</label>
            <input type="password" class="form-control" id="txtNovazaporka" placeholder="Nova zaporka">
        </div>
        <div class="mb-5 row">

            <label for="exampleFormControlInput1" class="form-label">Ponovite novu zaporku</label>
            <input type="password" class="form-control" id="txtPonovitenovuzaporku" placeholder="Ponovite novu zaporku">
        </div>
        <div class="mb-3 row">
            <button type="promjenizaporku" class="btn btn-primary mb-3">Promjeni zaporku</button>
        </div>
        <div class="mb-3 row">

            <label for="exampleFormControlInput1" class="form-label">Adresa e-pošte</label>
            <input type="email" class="form-control" id="txtAdresaEPoste" placeholder="name@example.com">
        </div>
        <div class="mb-3 row">
            <button type="izbriširačun" class="btn btn-primary mb-3">Izbriši račun</button>
        </div>
    </form>
</body>
</html>
