using Quizkey.Cookies;
using Quizkey.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            public string PlayButton { get; set; }
            public string EditButton { get; set; }
            public string DeleteButton { get; set; }
        }
        private class LogsTableRow
        {
            public string QuizName { get; set; }
            public int NumberOfPlayers { get; set; }
            public string TimePlayed { get; set; }
            public string InspectButton { get; set; }
            public string DownloadButton { get; set; }
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

        public bool TransmittingFile { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserState == null || UserState["loggedin"] != "author" || Session["userid"] == null)
            {
                Response.Redirect("/");
                return;
            }
            //Session["userid"] = 1;
            this.PreRender += Tables_PreRender;
            //values.Add(new PositionData())
        }

        private void Tables_PreRender(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("download") != null)
            {
                int idSession = int.Parse(Request.QueryString.Get("download"));
                DownloadLog(idSession);
            }
            if (Request.QueryString.Get("play") != null)
            {
                int quizID = int.Parse(Request.QueryString.Get("play"));
                Playbutton(quizID);
            }
            else if (Request.QueryString.Get("edit") != null)
            {
                int quizID = int.Parse(Request.QueryString.Get("edit"));
                Editbutton(quizID);
                Response.Redirect("/Tables.aspx?quiz=1");
            }
            else if (Request.QueryString.Get("delete") != null)
            {
                int quizID = int.Parse(Request.QueryString.Get("delete"));
                Deletebutton(quizID);
                Response.Redirect("/Tables.aspx?quiz=1");
            }
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

            TemplateBuilder builder = new TemplateBuilder();
            builder.AppendLiteralString("<table border=\"1\" class=\"table mt-4\">");
            builder.AppendLiteralString("<tr>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("QuizTopic", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("nquestions", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("nplayed", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("Actions", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString("</tr>");
            QuizRepeater.HeaderTemplate = builder;

            var values = new ArrayList();
            var quizes = Repo.GetMultipleQuiz(AuthorID);
            var sessions = Repo.GetMultipleQuizSession(AuthorID);
            foreach (Quiz item in quizes)
            {
                var playbutton = $"<a href=\"/Tables.aspx?play={item.IDQuiz}\" class=\"btn btn-success mx-1\" >{locale.Resource("Play", cookie.Enum(Cookies.UserState.language))}";

                var editbutton = $"<a href=\"/Tables.aspx?edit={item.IDQuiz}\" class=\"btn btn-info mx-1\" >{locale.Resource("Edit", cookie.Enum(Cookies.UserState.language))}";

                var deletebutton = $"<a href=\"/Tables.aspx?delete={item.IDQuiz}\" class=\"btn btn-danger mx-1\" >{locale.Resource("Delete", cookie.Enum(Cookies.UserState.language))}";

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


            TemplateBuilder builder = new TemplateBuilder();
            builder.AppendLiteralString("<table border=\"1\" class=\"table mt-4\">");
            builder.AppendLiteralString("<tr>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("QuizTopic", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("nplayers", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("TimePlayed", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("Actions", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString("</tr>");
            LogsRepeater.HeaderTemplate = builder;

            var values = new ArrayList();
            var sessions = Repo.GetMultipleQuizSession(AuthorID);
            foreach (QuizSession item in sessions)
            {
                var inspectbutton = $"<a href=\"/Tables.aspx?log={item.IDQuizSession}\" class=\"btn btn-info mx-1\" >{locale.Resource("Inspect", cookie.Enum(Cookies.UserState.language))}";
                var downloadbutton = $"<a href=\"/Tables.aspx?download={item.IDQuizSession}\" class=\"btn btn-success mx-1\" >{locale.Resource("DownloadLog", cookie.Enum(Cookies.UserState.language))}";

                values.Add(new LogsTableRow
                {
                    QuizName = Repo.GetQuiz(item.QuizID).QuizName,
                    NumberOfPlayers = Repo.GetMultipleAttendee().Where(x => x.SessionID == item.IDQuizSession).Count(),
                    TimePlayed = item.OccurredAt.ToString("g"),
                    InspectButton = inspectbutton,
                    DownloadButton = downloadbutton
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

            TemplateBuilder builder = new TemplateBuilder();
            builder.AppendLiteralString("<table border=\"1\" class=\"table mt-4\">");
            builder.AppendLiteralString("<tr>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("Player", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("Question", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("Answer", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString($"<td><b>{locale.Resource("Points", cookie.Enum(Cookies.UserState.language))}</b></td>");
            builder.AppendLiteralString("</tr>");
            LogRepeater.HeaderTemplate = builder;

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
                }); ;
            }
            LogRepeater.DataSource = values;
            LogRepeater.DataBind();
        }

        private void Playbutton(int QuizID)
        {
            var SessionID = Repo.CreateQuizSession(new QuizSession { OccurredAt = DateTimeOffset.Now, QuizID = QuizID, SessionCode = Repo.GenerateQuizCode() });
            Session["SessionID"] = SessionID;
            Session["qp-quizstate-playing"] = true;
            Response.Redirect("/WaitingRoom.aspx");
        }
        private void Editbutton(int QuizID)
        {
            Session["qc-ID-toEdit"] = QuizID;
            Response.Redirect("/QuizCreation.aspx");
        }
        private void Deletebutton(int QuizID)
        {
            Repo.DeleteQuizComplete(QuizID);
        }
        protected void DownloadLog(int SessionID)
        {
            var csvstring = Repo.GetMultipleLogItem().Where(x => x.QuizSessionID == SessionID);
            if (csvstring.Count() == 0)
            {
                Response.Redirect("/Tables.aspx?logs=1");
                return;
            }
            var csvdata = csvstring.Select(ConvertToCSVLine)
                                   .Aggregate((x, y) => $"{x}\n{y}");

            var filepath = Path.GetTempFileName();
            File.WriteAllText(filepath, csvdata);
            Response.ContentType = "text/csv";
            Response.AppendHeader("Content-Disposition", $"attachment; filename=Quizkey-Log-{Repo.GetQuizSession(SessionID).OccurredAt}.csv");
            TransmittingFile = true;
            Response.TransmitFile(filepath);
            Response.End();
        }

        private string ConvertToCSVLine(LogItem arg)
        {
            List<string> values = new List<string>
            {
                arg.IDLogItem.ToString(),
                Repo.GetQuizSession(arg.QuizSessionID).SessionCode,
                Regex.Replace(Repo.GetQuizQuestion(arg.QuizQuestionID).QuestionText.Trim(), @"[^0-9a-zA-Z]+", "-"),
                Regex.Replace(Repo.GetQuizAnswer(arg.QuizAnswerID).AnswerText.Trim(), @"[^0-9a-zA-Z]+", "-"),
                arg.AttendeeID.ToString(),
                Regex.Replace(Repo.GetAttendee(arg.AttendeeID).Username.Trim(), @"[^0-9a-zA-Z]+", "-"),
                arg.Points.ToString()
            };

            var hold = string.Join(",", values);
            return hold;
        }
    }
}