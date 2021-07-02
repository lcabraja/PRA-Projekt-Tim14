<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="Quizkey.StartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="position-relative">
            <div class="position-absolute top-100 start-50 translate-middle-x">

                <div class="btn-group-vertical" role="group" aria-label="Basic checkbox toggle button group">
                    &nbsp;<label class="btn btn-outline-primary" for="btncheck1"><input type="checkbox" class="btn-check" id="btncheck1" autocomplete="off" onclick="btnFinish_Click">Igraj</label>&nbsp;
                    <label class="btn btn-outline-primary" for="btncheck2">Prijava</label>&nbsp;
                    <label class="btn btn-outline-primary" for="btncheck3">Registracija</label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
