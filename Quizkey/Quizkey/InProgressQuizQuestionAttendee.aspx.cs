using Quizkey.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class InProgressQuizQuestionAttendee : System.Web.UI.Page
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
        public DateTimeOffset QuestionStarted
        {
            get
            {
                return (DateTimeOffset)Session["QuestionStarted"];
            }
            set
            {
                Session["QuestionStarted"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("advance") != null)
            {
                if (PageNumber + 1 == CreationState.Pages.Count)
                {
                    StatePlaying = false;
                    Response.Redirect("EndOfQuizAttendee.aspx");
                    return;
                }
                PageNumber++;
                Response.Redirect("InProgressQuizQuestion.aspx");
            }
            this.PreRender += InProgressQuizQuestionAttendee_PreRender;

            var page = GetCreationState().Pages[PageNumber];

            if (!IsPostBack)
                QuestionStarted = DateTimeOffset.Now;
            countdowntime.Attributes["seconds"] = page.SelectedTime.ToString();
        }

        private void InProgressQuizQuestionAttendee_PreRender(object sender, EventArgs e)
        {
            var page = GetCreationState().Pages[PageNumber];
            if (page.AnswerNumber > 2)
            {
                btPentagon.Visible = true;
            }
            if (page.AnswerNumber > 3)
            {
                btCircle.Visible = true;
            }
        }
        private int GetTimeTaken()
        {
            return (int)(DateTimeOffset.Now - QuestionStarted).TotalSeconds;
        }
        private void ProcessAnyClick(int questionNumber)
        {
            var page = GetCreationState().Pages[PageNumber];
            var time = GetTimeTaken();
            int points = time > page.SelectedTime ? 0 : Repo.CalculateScore(page.QuestionID, questionNumber, time);

            var logitem = new LogItem();
            logitem.AttendeeID = (int)Session["attendeeid"];
            logitem.Points = points;
            Debug.WriteLine(points);
            logitem.QuizAnswerID = Repo.GetMultipleQuizAnswer().Where(x => x.QuizQuestionID == page.QuestionID && x.QuestionOrder == questionNumber).First().IDQuizAnswer;
            logitem.QuizQuestionID = page.QuestionID;
            logitem.QuizSessionID = SessionID;

            var userstate = Request.Cookies["UserState"];
            try
            {
                points += int.Parse(userstate["points"]);
            }
            catch
            {
                //intended behavior
            }
            userstate["points"] = points.ToString();
            Response.SetCookie(userstate);

            Repo.CreateLogItem(logitem);
            Session["timespent"] = GetTimeTaken();
            if (time > page.SelectedTime)
            {
                Response.Redirect("ResultsAttendee.aspx");
            }
            else
            {
                Response.Redirect("WaitingForResults.aspx");
            }
        }
        protected void btTriangle_ServerClick(object sender, EventArgs e)
        {
            ProcessAnyClick(1);
        }
        protected void btStar_ServerClick(object sender, EventArgs e)
        {
            ProcessAnyClick(2);
        }
        protected void btPentagon_ServerClick(object sender, EventArgs e)
        {
            ProcessAnyClick(3);
        }
        protected void btCircle_ServerClick(object sender, EventArgs e)
        {
            ProcessAnyClick(4);
        }
    }
}