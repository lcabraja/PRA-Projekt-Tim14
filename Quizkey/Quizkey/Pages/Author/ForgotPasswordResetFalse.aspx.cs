using Quizkey.Cookies;
using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey.Pages.Author
{
    public partial class ForgotPasswordResetFalse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += ForgotPasswordResetFalse_PreRender;
        }

        private void ForgotPasswordResetFalse_PreRender(object sender, EventArgs e)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;


            waitingtext.InnerText = locale.Resource("MissingAccount", cookie.Enum(Cookies.UserState.language));
            gohome.InnerText = locale.Resource("GoHome", cookie.Enum(Cookies.UserState.language));
        }
    }
}