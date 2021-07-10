using Quizkey.Cookies;
using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey.User_Controls
{
    public partial class QuizCreationTimeButton : System.Web.UI.UserControl
    {
        public event System.EventHandler ServerClick;
        public int Seconds { get; set; }
        public bool Filled { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += QuizCreationButton_PreRender;
            Button.ServerClick += ServerClick;
        }

        private void QuizCreationButton_PreRender(object sender, EventArgs e)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;

            Button.InnerText = $"{Seconds} {locale.Resource("seconds", cookie.Enum(Cookies.UserState.language))}";
            Button.Attributes["class"] = $"btn {(Filled ? "btn-light" : "btn-primary")}";
        }
    }
}