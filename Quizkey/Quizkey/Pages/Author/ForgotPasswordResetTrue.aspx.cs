using Quizkey.Cookies;
using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey.Pages.Author.Pictures
{
    public partial class ForgotPasswordResetTrue : System.Web.UI.Page
    {
        public bool ShowErrorMessage { get; set; }
        public string ErrorMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += ForgotPasswordResetTrue_PreRender;
            if (IsPostBack)
                if (RequiredFieldValidator5.IsValid && RequiredFieldValidator6.IsValid)
                    if (tbPassword.Text == tbPasswordRepeat.Text)
                    {
                        try
                        {
                            var account = Repo.GetMultipleAuthor().Where(x => x.Username == (string)Session["reset-username"] && x.Email == (string)Session["reset-email"]);
                            if (account.Count() > 0)
                            {
                                Repo.UpdateAuthor(new Models.Author
                                {
                                    IDAuthor = account.First().IDAuthor,
                                    Email = (string)Session["reset-email"],
                                    Username = (string)Session["reset-username"],
                                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(tbPasswordRepeat.Text)
                                });

                                HttpCookie cookie = new HttpCookie("UserState");

                                cookie["loggedin"] = "author";
                                cookie["language"] = "en";
                                cookie["username"] = (string)Session["reset-email"];
                                cookie["userid"] = account.First().IDAuthor.ToString();
                                Session["userid"] = account.First().IDAuthor;
                                Response.SetCookie(cookie);
                                Response.Redirect("/Pages/Author/HomePage.aspx");
                            }
                        }
                        catch
                        {

                        }
                    }
        }

        private void ForgotPasswordResetTrue_PreRender(object sender, EventArgs e)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;

            this.NewPasswordHeader.InnerText = locale.Resource("NewPasswordHeader", cookie.Enum(Cookies.UserState.language));
            this.label6.Text = locale.Resource("Password", cookie.Enum(Cookies.UserState.language));
            this.label7.Text = locale.Resource("RepeatPassword", cookie.Enum(Cookies.UserState.language));
        }
    }
}