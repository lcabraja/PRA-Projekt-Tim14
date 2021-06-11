<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Projekt_za_PRA.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>/
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
        <div class="card-group">
            <div class="card">
                <img src="Pictures/Quiz-1.png" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Naslov</h5>
                    <p class="card-text">Opis kviza...</p>
                    <button class="btn btn-primary" type="submit">Pokreni kviz</button>
                </div>
            </div>
            <div class="card">
                <img src="Pictures/Quiz-2.png" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Naslov</h5>
                    <p class="card-text">Opis kviza...</p>
                    <button class="btn btn-primary" type="submit">Pokreni kviz</button>
                </div>
            </div>
            <div class="card">
                <img src="Pictures/Quiz-3.png" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Naslov</h5>
                    <p class="card-text">Opis kviza...</p>
                    <button class="btn btn-primary" type="submit">Pokreni kviz</button>
                </div>
            </div>
            <div class="card">
                <img src="Pictures/Quiz-4.png" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Naslov</h5>
                    <p class="card-text">Opis kviza...</p>
                    <button class="btn btn-primary" type="submit">Pokreni kviz</button>
                </div>
            </div>
            <div class="card">
                <img src="Pictures/Quiz-5.png" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Naslov</h5>
                    <p class="card-text">Opis kviza...</p>
                    <button class="btn btn-primary" type="submit">Pokreni kviz</button>
                </div>
            </div>
            <div class="card">
                <img src="Pictures/Quiz-6.png" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Naslov</h5>
                    <p class="card-text">Opis kviza...</p>
                    <button class="btn btn-primary" type="submit">Pokreni kviz</button>
                </div>
            </div>
            <div class="card">
                <img src="Pictures/Quiz-7.png" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Novi kviz</h5>
                    <p class="card-text">Opis kviza...</p>
                    <button class="btn btn-primary" type="submit">Izradi novi kviz</button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
