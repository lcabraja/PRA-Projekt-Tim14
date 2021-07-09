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
    public partial class GameStartPage : System.Web.UI.Page
    {
        public bool ShowErrorMessage { get; set; }
        public string ErrorMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += GameStartPage_PreRender;
            if (IsPostBack && tbQuizCode.Text != null)
            {
                var codes = Repo.GetMultipleQuizSession().Where(x => x.SessionCode == tbQuizCode.Text);
                if (codes.Count() > 0)
                {
                    Session["SessionID"] = codes.First().IDQuizSession;
                    Response.Redirect("/GameStartUsername.aspx");
                }
                else
                {
                    ShowErrorMessage = true;
                    ErrorMessage = "Incorrect Quiz Code.";
                }
            }
        }
        private void GameStartPage_PreRender(object sender, EventArgs e)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;
            button1.Text = locale.Resource("Go", cookie.Enum(UserState.language));
            if (ShowErrorMessage)
                diverrormessage.Controls.Add(new LiteralControl($"<div class=\"badge bg-danger\">{ErrorMessage}</div>"));
        }
    }
}