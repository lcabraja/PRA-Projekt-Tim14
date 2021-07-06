<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tables.aspx.cs" Inherits="Quizkey.Tables" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater id="QuizRepeater" runat="server">
          <HeaderTemplate>
             <table border="1">
                <tr>
                   <td><b>Quiz name</b></td>
                   <td><b># of questions</b></td>
                   <td><b># of times played</b></td>
                </tr>
          </HeaderTemplate>
             
          <ItemTemplate>
             <tr>
                <td> <%# DataBinder.Eval(Container.DataItem, "QuizName") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "NumberOfQuestions") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "TimesPlayed") %> </td>
             </tr>
          </ItemTemplate>
             
          <FooterTemplate>
             </table>
          </FooterTemplate>
             
       </asp:Repeater>
        </div>
    </form>
</body>
</html>
