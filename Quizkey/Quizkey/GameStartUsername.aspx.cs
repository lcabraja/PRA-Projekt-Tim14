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
    public partial class GameStartUsername : System.Web.UI.Page
    {
        public bool ShowErrorMessage { get; set; }
        public string ErrorMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += GameStartPage_PreRender;
            if (Session["SessionID"] != null)
                if (IsPostBack && tbUsername.Text != null)
                {
                    if (tbUsername.Text.Trim().Length > 0 && tbUsername.Text.Trim().Length <= 64)
                    {
                        HttpCookie cookie = new HttpCookie("UserState");
                        cookie["loggedin"] = "attendee";
                        cookie["language"] = "en";
                        cookie["username"] = tbUsername.Text.Trim();

                        var attendeeid = Repo.CreateAttendee(new Attendee { SessionID = (int)Session["SessionID"], Username = tbUsername.Text });

                        cookie["userid"] = attendeeid.ToString();
                        Session["attendeeid"] = attendeeid;

                        Response.SetCookie(cookie);
                        Response.SetCookie(new HttpCookie("sessionid", Session["SessionID"].ToString()));

                        Response.Redirect("/WaitingRoomAttendee.aspx");
                    }
                    else if (tbUsername.Text.Trim().Length == 0)
                    {
                        ShowErrorMessage = true;
                        ErrorMessage = "Please insert a username";
                    }
                    else if (tbUsername.Text.Trim().Length > 64)
                    {
                        ShowErrorMessage = true;
                        ErrorMessage = "Username too long";
                    }
                }
        }
        private void GameStartPage_PreRender(object sender, EventArgs e)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;
            button1.Text = locale.Resource("Go", cookie.Enum(UserState.language));
            placeholder.InnerText = locale.Resource("PleaseName", cookie.Enum(UserState.language));
            if (ShowErrorMessage)
                diverrormessage.Controls.Add(new LiteralControl($"<div class=\"badge bg-danger\">{ErrorMessage}</div>"));
        }
    }
}