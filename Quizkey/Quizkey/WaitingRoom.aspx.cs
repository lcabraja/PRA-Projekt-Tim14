using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class WaitingRoom : System.Web.UI.Page
    {
        public string SessionCode
        {
            get
            {
                return Repo.GetQuizSession(SessionID).SessionCode;
            }
        }
        public int SessionID
        {
            get
            {
                if (Session["SessionID"] == null)
                {
                    Response.Redirect("/");
                }
                return int.Parse(Session["SessionID"].ToString());
            }
        }
        public int PageNumber
        {
            get
            {
                return (int)(Session["qp-quizstate-PageNumber"] ?? 0);
            }

            set
            {
                Session["qp-quizstate-PageNumber"] = value;
            }
        }
        public bool StatePlaying
        {
            get
            {
                return (bool)(Session["qp-quizstate-playing"] ?? false);
            }
            set
            {
                Session["qp-quizstate-playing"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var attendees = Repo.GetMultipleAttendee().Where(x => x.SessionID == this.SessionID);
            foreach (var attendee in attendees)
            {
                players.Controls.Add(new Label { CssClass = "badge bg-light text-dark p-2 m-2", Text = attendee.Username });
            }
            this.tbQuizName.Text = SessionCode;
        }

        protected void Start_Click(object sender, EventArgs e)
        {
            //var SessionID = Repo.CreateQuizSession(new QuizSession { OccurredAt = DateTimeOffset.Now, QuizID = 4003, SessionCode = "kodkod" });
            Session["qp-quizstate-playing"] = true;
            PageNumber = 0;
            Response.Redirect("InProgressQuizQuestion.aspx");
        }

        protected void Odustani_Click(object sender, EventArgs e)
        {
            StatePlaying = false;
            Session["SessionID"] = null;
        }
    }
}