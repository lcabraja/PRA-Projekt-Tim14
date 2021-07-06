using Quizkey.Cookies;
using System;
using System.Web;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class Navbar : System.Web.UI.UserControl
    {
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
                CookieParseWrapper cookie = new CookieParseWrapper(userState);
                
                SetLanguageButtonText(userState);
                
                if (userState["loggedIn"] == "author")
                {
                    welcomeText.InnerText = $"Welcome {userState["userName"]}";
                    navbarLinks.Controls.Add(new HyperLink { Text = "My Profile", NavigateUrl = "/Pages/Author/ProfilePage.aspx", CssClass = "nav-link px-1 text-light" });
                    navbarLinks.Controls.Add(new HyperLink { Text = "My Quizes", NavigateUrl = "/Table.aspx?table=quiz", CssClass = "nav-link px-1 text-light" });
                    navbarLinks.Controls.Add(new HyperLink { Text = "My Logs", NavigateUrl = "/Table.aspx?table=log", CssClass = "nav-link px-1 text-light" });
                    logout.Visible = true;
                }
                if (userState[UserState.loggedin.ToString()] == "attendee")
                {
                    welcomeText.InnerHtml = $"<span class=\"d-inline\">{cookie.Enum(UserState.username).ToUpper().ToBold()}<span/> " +
                        $"<span class=\"badge bg-success d-inline\">{(cookie.Enum(UserState.points) ?? "0").ToBold()}</span>";
                    quizcode.Visible = true;
                    quizcode.InnerHtml = cookie.Enum(UserState.quizcode)?.ToString().ToUpper().ToBadge("secondary");
                }
            }
        }

        private void SetLanguageButtonText(HttpCookie cookie)
        {
            if (cookie[UserState.language.ToString()] == UserStateLanguage.en.ToString())
            {
                btToggleLanguage.Text = "English";
            }
            else
            {
                btToggleLanguage.Text = "Hrvatski";
            }
        }

        protected void btToggleLanguage_Click(object sender, EventArgs e)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            userState[UserState.language.ToString()] =
                userState[UserState.language.ToString()] == UserStateLanguage.en.ToString() ? UserStateLanguage.hr.ToString() : UserStateLanguage.en.ToString();
            SetLanguageButtonText(userState);
            Response.SetCookie(userState);
        }

        protected void btLogOut_Click(object sender, EventArgs e)
        {
            Response.Cookies.Remove("UserState");
        }
    }
}