using Quizkey.Cookies;
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
                            ErrorMessage = "UsernameTaken";
                            return;
                        }
                        if (Repo.GetMultipleAuthor().Where(x => x.Email == tbEmail.Text).Count() > 0)
                        {
                            ShowErrorMessage = true;
                            ErrorMessage = "EmailTaken";
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
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;

            if (ErrorMessage == "UsernameTaken")
                ErrorMessage = locale.Resource("UsernameTaken", cookie.Enum(Cookies.UserState.language));
            if (ErrorMessage == "EmailTaken")
                ErrorMessage = locale.Resource("EmailTaken", cookie.Enum(Cookies.UserState.language));

            label1.Text = locale.Resource("Username", cookie.Enum(Cookies.UserState.language));
            label4.Text = locale.Resource("Email", cookie.Enum(Cookies.UserState.language));
            label6.Text = locale.Resource("Password", cookie.Enum(Cookies.UserState.language));
            label7.Text = locale.Resource("RepeatPassword", cookie.Enum(Cookies.UserState.language));
            RequiredFieldValidator2.ErrorMessage = locale.Resource("MissingName", cookie.Enum(Cookies.UserState.language));
            RequiredFieldValidator3.ErrorMessage = locale.Resource("MissingEmail", cookie.Enum(Cookies.UserState.language));
            RequiredFieldValidator6.ErrorMessage = locale.Resource("MissingPassword", cookie.Enum(Cookies.UserState.language));
            RequiredFieldValidator5.ErrorMessage = locale.Resource("MissingPasswordRepeat", cookie.Enum(Cookies.UserState.language));
            regex.ErrorMessage = locale.Resource("WrongEmail", cookie.Enum(Cookies.UserState.language));
            comparePasswordValidator.ErrorMessage = locale.Resource("PasswordMatch", cookie.Enum(Cookies.UserState.language));
            btSend.Text = locale.Resource("Register", cookie.Enum(Cookies.UserState.language));
            if (ShowErrorMessage)
                diverrormessage.Controls.Add(new LiteralControl($"<div class=\"badge bg-danger\">{ErrorMessage}</div>"));
        }
    }
}