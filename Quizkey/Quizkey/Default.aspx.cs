using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserState"] != null && Request.Cookies["UserState"]["loggedin"] == "author")
            {
                Response.Redirect("/Pages/Author/Login.aspx");
            }
            else
            {
                Response.Redirect("/Pages/Author/StartPage.aspx");
            }
            //HttpCookie cookie = new HttpCookie("UserState");

            //cookie["loggedin"] = "author";
            //cookie["language"] = "en";
            //cookie["username"] = "dino";
            //cookie["points"] = "6969";
            //cookie["userid"] = "2004";

            //Session["userid"] = 2004;

            //var SessionID = Repo.CreateQuizSession(new QuizSession { OccurredAt = DateTimeOffset.Now, QuizID = 4003, SessionCode = "kodkod" });
            //Session["SessionID"] = SessionID;
            //Session["qp-quizstate-playing"] = true;
            //Repo.CreateAttendee(new Attendee { SessionID = SessionID, Username = "PeroStanko1" });
            //Repo.CreateAttendee(new Attendee { SessionID = SessionID, Username = "PeroStanko3" });
            //Repo.CreateAttendee(new Attendee { SessionID = SessionID, Username = "PeroStanko4" });
            //Session["attendeeid"] = Repo.CreateAttendee(new Attendee { SessionID = SessionID, Username = "PeroStanko5" });
            //Response.Write(Session["SessionID"].ToString());
            //Response.SetCookie(cookie);
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session["qc-ID-toEdit"] = 4002;
            Response.Redirect("QuizCreation.aspx");
        }
    }
}