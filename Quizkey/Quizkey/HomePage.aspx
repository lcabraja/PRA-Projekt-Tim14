<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Projekt_za_PRA.HomePage" %>

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
