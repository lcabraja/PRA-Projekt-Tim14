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
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += StartPage_PreRender;
        }

        private void StartPage_PreRender(object sender, EventArgs e)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;
            Igraj.Text = locale.Resource("Play", cookie.Enum(Cookies.UserState.language));
            Registracija.Text = locale.Resource("Register", cookie.Enum(Cookies.UserState.language));
            Prijava.Text = locale.Resource("Login", cookie.Enum(Cookies.UserState.language));
        }

        protected void Play_Click(object sender, EventArgs e)
        {
            Response.Redirect("/GameStartPage.aspx");
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

    }
}