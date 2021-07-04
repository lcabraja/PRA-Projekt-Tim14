using Quizkey.Models;
using Quizkey.User_Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class Results : System.Web.UI.Page
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
        public QuizCreationModel CreationState
        {
            get
            {
                return Session["qc-QuizCreationModel"] as QuizCreationModel;
            }
            set { Session["qc-QuizCreationModel"] = value; }
        }
        public QuizCreationModel GetCreationState()
        {
            if (CreationState == null)
            {
                CreationState = LoadQuizData.GetQuizData(SessionID);
            }
            return CreationState;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            QuizCreationModel model = GetCreationState();
            var attendees = Repo.GetMultipleAttendee().Where(x => x.SessionID == SessionID);
            Console.OpenStandardOutput();
            var sortedAttendees = attendees.OrderBy(GetScore).Take(5).ToList();
            for (int i = 0; i < sortedAttendees.Count; i++)
            {
                positioncontainer.Controls.Add(new LiteralControl($"<div class=\"bg-{(i < 3 ? "primary" : "light")} rounded\" ><h2 class=\"d-grid\">{i + 1}. {sortedAttendees[i].Username}</h2></div>"));
            }
        }
        private int GetScore(Attendee attendee)
        {
            return -Repo.GetMultipleLogItem().Where(x => x.QuizSessionID == SessionID && x.AttendeeID == attendee.IDAttendee).Select(x => x.Points).Sum();
        }
        protected void Stop_Click(object sender, EventArgs e)
        {
            Session["SessionID"] = null;
            StatePlaying = false;
            Response.Redirect("/");
        }
        protected void Next_Click(object sender, EventArgs e)
        {
            if (PageNumber + 1 == CreationState.Pages.Count)
            {
                StatePlaying = false;
                WebSockets.AnnounceEnd(SessionID);
                Response.Redirect("EndOfQuiz.aspx");
                return;
            }
            WebSockets.AnnounceStart(SessionID);
            PageNumber++;
            Response.Redirect("InProgressQuizQuestion.aspx");
        }
    }
}