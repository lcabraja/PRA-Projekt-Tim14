using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.WebSockets;
using Quizkey.Cookies;

namespace Quizkey
{
    public partial class ResultsAttendee : System.Web.UI.Page
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
                this.PreRender += ResultsAttendee_PreRender;
                var x = sortedAttendees[i];
                positioncontainer.Controls.Add(
                    new LiteralControl(
                                    $"<h2 class=\"d-grid m-2 p-1 {(i < 3 ? "bg-primary" : "bg-light")} rounded\">" +
                                        "<div style=\"display: flex;\">" +
                                            $"<span style=\"font-weight: 100; display: inline-flex; padding-right: 1rem;\">{i + 1}.</span>" +
                                            x.Username +
                                            $"<span style=\"font-weight: 100; display: inline-flex; padding-left: 1rem;\">{-GetScore(x)} Points</span>" +
                                        "</div>" +
                                    "</h2>"
                    ));
            }
        }

        private void ResultsAttendee_PreRender(object sender, EventArgs e)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;

            this.tbQuizName.Text = Repo.GetQuiz(Repo.GetQuizSession(SessionID).QuizID).QuizName;
            this.quiztitletext.InnerText = locale.Resource("QuizTopic", cookie.Enum(UserState.language));
        }

        private int GetScore(Attendee attendee)
        {
            return -Repo.GetMultipleLogItem().Where(x => x.QuizSessionID == SessionID && x.AttendeeID == attendee.IDAttendee).Select(x => x.Points).Sum();
        }
    }
}