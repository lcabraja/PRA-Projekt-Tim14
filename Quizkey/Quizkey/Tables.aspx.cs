using Quizkey.Cookies;
using Quizkey.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class Tables : System.Web.UI.Page
    {
        public int AuthorID { get { return (int)(Session["userid"] ?? 0); } }
        private class QuizTableRow
        {
            public string QuizName { get; set; }
            public int NumberOfQuestions { get; set; }
            public int TimesPlayed { get; set; }
            public LinkButton PlayButton { get; set; }
            public LinkButton EditButton { get; set; }
            public LinkButton DeleteButton { get; set; }
        }
        private class LogsTableRow
        {
            public string QuizName { get; set; }
            public int NumberOfPlayers { get; set; }
            public string TimePlayed { get; set; }
        }
        private class LogTableRow
        {
            public string Player { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }
            public int Points { get; set; }
        }
        public HttpCookie UserState
        {
            get
            {
                return Request.Cookies["UserState"];
            }
            set
            {
                Response.SetCookie(value);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (UserState == null || UserState["loggedin"] != "author" || Session["userid"] == null)
            //{
            //    Response.Redirect("/");
            //    return;
            //}
            Session["userid"] = 1;
            this.PreRender += Tables_PreRender;
            //values.Add(new PositionData())
        }

        private void Tables_PreRender(object sender, EventArgs e)
        {
            GenerateQuizTables();
            return;
            if (Request.QueryString.Get("quiz") != null)
            {
                GenerateQuizTables();
            }
            else if (Request.QueryString.Get("logs") != null)
            {
                GenerateLogTables();
            }
            else if (Request.QueryString.Get("log") != null)
            {
                GenerateLogTables(int.Parse(Request.QueryString.Get("log")));
            }
        }

        private void GenerateQuizTables()
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;

            var values = new ArrayList();
            var logItems = Repo.GetMultipleLogItem(AuthorID);
            var quizes = Repo.GetMultipleQuiz(AuthorID);
            var sessions = Repo.GetMultipleQuizSession(AuthorID);
            foreach (Quiz item in quizes)
            {
                var playbutton = new LinkButton { ID = "playbutton" };
                playbutton.Text = locale.Resource("Play", cookie.Enum(Cookies.UserState.language));
                playbutton.Click += Playbutton_Click;
                playbutton.Attributes["quizid"] = item.IDQuiz.ToString();

                var editbutton = new LinkButton { ID = "editbutton" };
                editbutton.Text = locale.Resource("Edit", cookie.Enum(Cookies.UserState.language));
                editbutton.Click += Editbutton_Click;
                editbutton.Attributes["quizid"] = item.IDQuiz.ToString();

                var deletebutton = new LinkButton { ID = "deletebutton" };
                deletebutton.Text = locale.Resource("Delete", cookie.Enum(Cookies.UserState.language));
                deletebutton.Click += Deletebutton_Click;
                deletebutton.Attributes["quizid"] = item.IDQuiz.ToString();

                values.Add(new QuizTableRow
                {
                    QuizName = item.QuizName,
                    NumberOfQuestions = Repo.GetMultipleQuizQuestion(item.IDQuiz).Count,
                    TimesPlayed = sessions.Where(x => x.QuizID == item.IDQuiz).Count(),
                    PlayButton = playbutton,
                    EditButton = editbutton,
                    DeleteButton = deletebutton
                });
            }
            QuizRepeater.DataSource = values;
            QuizRepeater.DataBind();
        }
        private void GenerateLogTables()
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;

            var values = new ArrayList();
            var sessions = Repo.GetMultipleQuizSession(AuthorID);
            foreach (QuizSession item in sessions)
            {
                values.Add(new LogsTableRow
                {
                    QuizName = Repo.GetQuiz(item.QuizID).QuizName,
                    NumberOfPlayers = Repo.GetMultipleAttendee().Where(x => x.SessionID == item.IDQuizSession).Count(),
                    TimePlayed = item.OccurredAt.ToString("g")
                });
            }
            LogsRepeater.DataSource = values;
            LogsRepeater.DataBind();
        }
        private void GenerateLogTables(int sessionid)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;

            var values = new ArrayList();
            var logItems = Repo.GetMultipleLogItem(AuthorID).Where(x => x.QuizSessionID == sessionid);
            foreach (LogItem item in logItems)
            {
                values.Add(new LogTableRow
                {
                    Player = Repo.GetAttendee(item.AttendeeID).Username,
                    Question = Repo.GetQuizQuestion(item.QuizQuestionID).QuestionText,
                    Answer = Repo.GetQuizAnswer(item.QuizAnswerID).AnswerText,
                    Points = item.Points
                });
            }
            LogRepeater.DataSource = values;
            LogRepeater.DataBind();
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton button)
            {
                int QuizID = int.Parse(button.Attributes["quizid"]);
                Repo.DeleteQuizComplete(QuizID);
            }
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton button)
            {
                int QuizID = int.Parse(button.Attributes["quizid"]);
                Session["qc-ID-toEdit"] = QuizID;
                Response.Redirect("/QuizCreation.aspx");
            }
        }

        private void Playbutton_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton button)
            {
                int QuizID = int.Parse(button.Attributes["quizid"]);
                var SessionID = Repo.CreateQuizSession(new QuizSession { OccurredAt = DateTimeOffset.Now, QuizID = QuizID, SessionCode = Repo.GenerateQuizCode() });
                Session["SessionID"] = SessionID;
                Session["qp-quizstate-playing"] = true;
                Response.Redirect("/WaitingRoom.aspx");
            }
        }
    }
}