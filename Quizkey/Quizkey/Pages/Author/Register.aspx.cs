using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class Register : System.Web.UI.Page
    {
        public bool ShowErrorMessage { get; set; }
        public string ErrorMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += Register_PreRender;
            if (IsPostBack)
                if (RequiredFieldValidator2.IsValid && RequiredFieldValidator3.IsValid && RequiredFieldValidator5.IsValid && RequiredFieldValidator6.IsValid)
                    if (tbPassword.Text == tbPasswordRepeat.Text)
                    {
                        if (Repo.GetMultipleAuthor().Where(x => x.Username == tbUsername.Text).Count() > 0)
                        {
                            ShowErrorMessage = true;
                            ErrorMessage = "Username is already taken.";
                            return;
                        }
                        var userid = Repo.CreateAuthor(new Author
                        {
                            Username = tbUsername.Text,
                            Email = tbEmail.Text,
                            PasswordHash = BCrypt.Net.BCrypt.HashPassword(tbPasswordRepeat.Text)
                        });

                        HttpCookie cookie = new HttpCookie("UserState");

                        cookie["loggedin"] = "author";
                        cookie["language"] = "en";
                        cookie["username"] = tbUsername.Text;
                        cookie["userid"] = userid.ToString();

                        Response.SetCookie(cookie);
                        Response.Redirect("/Pages/Author/HomePage.aspx");
                    }
        }

        private void Register_PreRender(object sender, EventArgs e)
        {
            if (ShowErrorMessage)
                diverrormessage.Controls.Add(new LiteralControl($"<div class=\"badge bg-danger\">{ErrorMessage}</div>"));
        }
    }
}