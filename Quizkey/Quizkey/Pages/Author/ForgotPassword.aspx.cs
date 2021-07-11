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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        public bool ShowErrorMessage { get; set; }
        public string ErrorMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += Register_PreRender;
            if (IsPostBack)
                if (RequiredFieldValidator2.IsValid && RequiredFieldValidator3.IsValid)
                {
                    if (Repo.GetMultipleAuthor().Where(x => x.Username == tbUsername.Text && x.Email == tbEmail.Text).Count() > 0)
                    {
                        Session["reset-username"] = tbUsername.Text;
                        Session["reset-email"] = tbEmail.Text;
                        Response.Redirect("/Pages/Author/ForgotPasswordResetTrue.aspx");
                    }
                    else
                    {
                        Response.Redirect("/Pages/Author/ForgotPasswordResetFalse.aspx");
                    }
                }

        }

        private void Register_PreRender(object sender, EventArgs e)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;

            label1.Text = locale.Resource("Username", cookie.Enum(Cookies.UserState.language));
            label4.Text = locale.Resource("Email", cookie.Enum(Cookies.UserState.language));
            RequiredFieldValidator2.ErrorMessage = locale.Resource("MissingName", cookie.Enum(Cookies.UserState.language));
            RequiredFieldValidator3.ErrorMessage = locale.Resource("MissingEmail", cookie.Enum(Cookies.UserState.language));
            regex.ErrorMessage = locale.Resource("WrongEmail", cookie.Enum(Cookies.UserState.language));
            btSend.Text = locale.Resource("Register", cookie.Enum(Cookies.UserState.language));
            if (ShowErrorMessage)
                diverrormessage.Controls.Add(new LiteralControl($"<div class=\"badge bg-danger\">{ErrorMessage}</div>"));
        }
    }
}