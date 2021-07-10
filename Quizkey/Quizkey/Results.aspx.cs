using Quizkey.Cookies;
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
            this.PreRender += Results_PreRender;
        }

        private void Results_PreRender(object sender, EventArgs e)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;
            quiztopic.InnerText = locale.Resource("QuizTopic", cookie.Enum(UserState.language));
            buttonstarttext.InnerText = locale.Resource("NextQuestion", cookie.Enum(UserState.language));
            buttonstoptext.InnerText = locale.Resource("StopQuiz", cookie.Enum(UserState.language));

            QuizCreationModel model = GetCreationState();
            tbQuizName.Text = model.QuizName;

            var attendees = Repo.GetMultipleAttendee().Where(x => x.SessionID == SessionID);
            var sortedAttendees = attendees.OrderBy(GetScore).Take(5).ToList();
            for (int i = 0; i < sortedAttendees.Count; i++)
            {
                positioncontainer.Controls.Add(new LiteralControl(
                    $"<div class=\"bg-{(i < 3 ? "primary" : "light")} rounded\">" +
                        $"<h2 class=\"d-flex\">" +
                            $"<span style=\"font-weight: 100; display: inline-flex; padding-right: 1rem; margin-left: 1rem;\">{i + 1}.</span>" +
                            $"{sortedAttendees[i].Username}" +
                        $"</h2>" +
                    $"</div>"));
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
            WebSockets.AnnounceEnd(SessionID);
            Response.Redirect("EndOfQuiz.aspx");
            return;
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