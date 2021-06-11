using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        public int Points { get; set; }
        public string QuizCode { get; set; }

        // Link Style = <a class="nav-link active" aria-current="page" href="#">Home</a>

        //navbarLinks.Controls.Add(new HyperLink { Text = "My Profile", NavigateUrl="/ProfilePage.aspx", CssClass = "nav-link px-1 text-light d-md-flex" });
        //navbarLinks.Controls.Add(new HyperLink { Text = "My Quizes", NavigateUrl = "/Table.aspx?table=quiz", CssClass = "nav-link px-1 text-light d-md-flex" });
        //navbarLinks.Controls.Add(new HyperLink { Text = "My Logs", NavigateUrl = "/Table.aspx?table=log", CssClass = "nav-link px-1 text-light d-md-flex" });
        protected void Page_Load(object sender, EventArgs e)
        {
            quizcode.Visible = false;
            logout.Visible = false;
            //navbarLinks.Controls.Add(new Button { Text = "My Profile", CssClass = "my-2 my-sm-0 btn btn-secondary nav-link px-2 text-light qk-nav-min" });
            //navbarLinks.Controls.Add(new Button { Text = "My Quizes", CssClass = "my-2 my-sm-0 btn btn-secondary nav-link px-2 text-light qk-nav-min" });
            //navbarLinks.Controls.Add(new Button { Text = "My Logs", CssClass = "my-2 my-sm-0 btn btn-secondary nav-link px-2 text-light qk-nav-min" });
            if (Request.Cookies["UserState"] != null)
            {
                HttpCookie userState = Request.Cookies["UserState"];

                if (userState["loggedIn"] == "author")
                {
                    welcomeText.InnerText = $"Welcome {userState["userName"]}";
                    navbarLinks.Controls.Add(new HyperLink { Text = "My Profile", NavigateUrl = "/ProfilePage.aspx", CssClass = "nav-link px-1 text-light" });
                    navbarLinks.Controls.Add(new HyperLink { Text = "My Quizes", NavigateUrl = "/Table.aspx?table=quiz", CssClass = "nav-link px-1 text-light" });
                    navbarLinks.Controls.Add(new HyperLink { Text = "My Logs", NavigateUrl = "/Table.aspx?table=log", CssClass = "nav-link px-1 text-light" });
                    logout.Visible = true;
                }
                if (userState["loggedIn"] == "attendee")
                {
                    welcomeText.InnerHtml = $"<b>{userState["userName"].ToString().ToUpper()}</b> POINTS: {Points}";
                    quizcode.Visible = true;
                    quizcode.InnerText = QuizCode.ToString().ToUpper();
                }
            }
        }
    }
}