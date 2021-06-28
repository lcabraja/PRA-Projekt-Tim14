using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quizkey.Models;

namespace Quizkey
{
    public partial class QuizCreation : System.Web.UI.Page
    {
        // ================================================================================================ Props ==========================================================
        public bool TriangleFill { get; set; }
        public bool StarFill { get; set; }
        public bool PentagonFill { get; set; }
        public bool CircleFill { get; set; }
        public int PageNumber
        {
            get
            {
                if (Request.QueryString.GetValues("page") == null)
                {
                    Response.Redirect($"QuizCreation.aspx?page=0");
                    return 0;
                }
                return int.Parse(Request.QueryString.GetValues("page")[0]);
            }
        }

        private int QuizID;

        public QuizCreationModel CreationState
        {
            get
            {
                if (Session["qc-QuizCreationModel"] == null)
                {
                    Session["qc-QuizCreationModel"] = new QuizCreationModel();
                }
                return Session["qc-QuizCreationModel"] as QuizCreationModel;
            }
            set { Session["qc-QuizCreationModel"] = value; }
        }
        public HttpCookie UserState
        {
            get { return Request.Cookies["UserState"]; }
            set { Response.SetCookie(value); }
        }
        // ================================================================================================ Load ===========================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Unload += QuizCreation_Unload;
            this.PreRender += Page_PreRender;
            Response.Write(Request.QueryString.AllKeys.ToList().Aggregate("!!", (a, b) => a += " " + b, x => x.ToUpper()));
            Response.Write("<br/>");
            Response.Write(GetSession());

            QuizCreationButton1.ServerClick += btTriangle_ServerClick;
            QuizCreationButton2.ServerClick += btStar_ServerClick;
            QuizCreationButton3.ServerClick += btPentagon_ServerClick;
            QuizCreationButton4.ServerClick += btCircle_ServerClick;

            QuizCreationTimeButton1.ServerClick += QuizCreationTimeButton1_ServerClick;
            QuizCreationTimeButton2.ServerClick += QuizCreationTimeButton2_ServerClick;
            QuizCreationTimeButton3.ServerClick += QuizCreationTimeButton3_ServerClick;
            QuizCreationTimeButton4.ServerClick += QuizCreationTimeButton4_ServerClick;

            QuizCreationAnswer3.OnAddAnswer += QuizCreationAnswer3_OnAddAnswer;
            QuizCreationAnswer4.OnAddAnswer += QuizCreationAnswer4_OnAddAnswer;

            if (!IsPostBack)
            {
                LoadQuiz();
                LoadSessionValues();
            }
            Response.Write(GetSession());
        }

        private void QuizCreation_Unload(object sender, EventArgs e)
        {
            //SaveState();
        }

        private void LoadQuiz()
        {
            if (!(bool)(Session["qc-DataLoaded"] ?? false))
            {
                if (QuizID != 0)
                {
                    QuizID = (int)(Session["qc-ID-toEdit"] ?? 0);
                    var quizDatabaseInstance = Repo.GetQuiz(QuizID);

                    if (quizDatabaseInstance == null)
                    {
                        ClearSession();
                        Response.Redirect("/");
                        return;
                    }

                    var answers = Repo.GetMultipleQuizAnswer();


                    Session["qc-DataLoaded"] = true;
                    var questions = Repo.GetMultipleQuizQuestion();

                    questions.ForEach(x => CreationState.Pages[PageNumber] = new QuizCreationPage
                    {
                        QuestionID = x.IDQuizQuestion,
                        SelectedAnswer = x.CorrectAnswer,
                        SelectedTime = x.AnswerTimeSeconds,
                        Question = x.QuestionText,
                        Answer1 = answers.Where(y => y.QuizQuestionID == x.IDQuizQuestion).ToList().Find(y => y.QuestionOrder == 1).AnswerText,
                        Answer2 = answers.Where(y => y.QuizQuestionID == x.IDQuizQuestion).ToList().Find(y => y.QuestionOrder == 2).AnswerText,
                        Answer3 = answers.Where(y => y.QuizQuestionID == x.IDQuizQuestion).ToList().Find(y => y.QuestionOrder == 3).AnswerText,
                        Answer4 = answers.Where(y => y.QuizQuestionID == x.IDQuizQuestion).ToList().Find(y => y.QuestionOrder == 4).AnswerText
                    });
                }
            }

        }
        //TODO Make loading and updating from db possible lol
        private void LoadSessionValues()
        {
            if (PageNumber < 0)
            {
                Response.Redirect($"QuizCreation.aspx?page=0");
                return;
            }

            if (CreationState.Pages.Keys.Count == 0)
                return;

            tbQuizName.Text = CreationState.QuizName ?? string.Empty;

            QuizCreationPage currentPage;
            try
            {
                currentPage = CreationState.Pages[PageNumber];
            }
            catch
            {
                currentPage = new QuizCreationPage();
            }

            Session["qc-SelectedAnswer"] = currentPage.SelectedAnswer;
            Session["qc-SelectedTime"] = currentPage.SelectedTime;

            tbQuestion.Text = currentPage.Question;

            Session["qc-AnswerNumber"] = currentPage.AnswerNumber;

            QuizCreationAnswer1.tbAnswer.Text = currentPage.Answer1;
            QuizCreationAnswer2.tbAnswer.Text = currentPage.Answer2;
            QuizCreationAnswer3.tbAnswer.Text = currentPage.Answer3;
            QuizCreationAnswer4.tbAnswer.Text = currentPage.Answer4;
        }
        private void SaveState()
        {
            CreationState.QuizName = tbQuizName.Text;
            var page = new QuizCreationPage();

            page.Question = tbQuestion.Text;
            page.SelectedAnswer = (int)(Session["qc-SelectedAnswer"] ?? 0);
            page.SelectedTime = (int)(Session["qc-SelectedTime"] ?? 0);
            page.Answer1 = QuizCreationAnswer1.tbAnswer.Text;
            page.Answer2 = QuizCreationAnswer2.tbAnswer.Text;


            int answers = (int)(Session["qc-AnswerNumber"] ?? 0);
            if (answers > 2)
                page.Answer3 = QuizCreationAnswer3.tbAnswer.Text;
            if (answers > 3)
                page.Answer4 = QuizCreationAnswer4.tbAnswer.Text;

            CreationState.Pages[PageNumber] = page;
        }
        // ================================================================================================ Render =========================================================
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Answer number selection
            SetAnswerNumbers();
            // Correct answer selection
            SetSelectedAnswer();
            // Time limit selection
            SetSelectedTime();
        }
        private void SetSelectedTime()
        {
            if (Session["qc-SelectedTime"] != null)
            {

                int time = (int)Session["qc-SelectedTime"];
                switch (time)
                {
                    case 120:
                        this.QuizCreationTimeButton1.Filled = true;
                        ClearCustomTime();
                        break;
                    case 60:
                        this.QuizCreationTimeButton2.Filled = true;
                        ClearCustomTime();
                        break;
                    case 30:
                        this.QuizCreationTimeButton3.Filled = true;
                        ClearCustomTime();
                        break;
                    case 15:
                        this.QuizCreationTimeButton4.Filled = true;
                        ClearCustomTime();
                        break;
                    case 0:
                        ClearCustomTime();
                        break;
                    default:
                        ButtonCustomTime.Attributes["class"] = "btn btn-light";
                        TextboxCustomTime.Text = time.ToString();
                        break;
                }
            }
        }
        private void SetSelectedAnswer()
        {
            if (Session["qc-SelectedAnswer"] != null)
            {
                int answer = (int)Session["qc-SelectedAnswer"];
                switch (answer)
                {
                    case 1:
                        this.QuizCreationAnswer1.Filled = true;
                        this.QuizCreationButton1.Filled = true;
                        break;
                    case 2:
                        this.QuizCreationAnswer2.Filled = true;
                        this.QuizCreationButton2.Filled = true;
                        break;
                    case 3:
                        this.QuizCreationAnswer3.Filled = true;
                        this.QuizCreationButton3.Filled = true;
                        break;
                    case 4:
                        this.QuizCreationAnswer4.Filled = true;
                        this.QuizCreationButton4.Filled = true;
                        break;

                }
            }
        }
        private void SetAnswerNumbers()
        {
            if (Session["qc-AnswerNumber"] != null)
            {
                int answer = (int)Session["qc-AnswerNumber"];
                switch (answer)
                {
                    case 3:
                        QuizCreationAnswer3.Delete = true;

                        QuizCreationAnswer4.Visible = true;
                        QuizCreationAnswer4.Delete = false;

                        QuizCreationButton3.Visible = true;
                        QuizCreationButton4.Visible = false;
                        if (Session["qc-SelectedAnswer"] != null)
                        {
                            int correctanswer = (int)Session["qc-SelectedAnswer"];
                            if (correctanswer == 4)
                                Session["qc-SelectedAnswer"] = null;
                        }
                        break;
                    case 4:
                        QuizCreationAnswer3.Delete = true;

                        QuizCreationAnswer4.Visible = true;
                        QuizCreationAnswer4.Delete = true;

                        QuizCreationButton3.Visible = true;
                        QuizCreationButton4.Visible = true;
                        break;
                    default:
                        QuizCreationAnswer3.Delete = false;

                        QuizCreationAnswer4.Visible = false;

                        QuizCreationButton3.Visible = false;
                        QuizCreationButton4.Visible = false;
                        if (Session["qc-SelectedAnswer"] != null)
                        {
                            int correctanswer = (int)Session["qc-SelectedAnswer"];
                            if (correctanswer > 2)
                                Session["qc-SelectedAnswer"] = null;
                        }
                        break;
                }
            }
        }
        private void ClearCustomTime()
        {
            ButtonCustomTime.Attributes["class"] = "btn btn-primary";
            TextboxCustomTime.Text = string.Empty;
        }
        private string GetSession()
        {
            string hold = string.Empty;
            for (int i = 0; i < Session.Keys.Count; i++)
            {
                hold += $"|{Session.Keys[i]}: {Session[Session.Keys[i]]}";
            }
            return hold;
        }
        private void ClearSession() // TODO
        {
            for (int i = 0; i < Session.Keys.Count; i++)
            {
                if (Session.Keys[i].StartsWith("qc-"))
                    Session[Session.Keys[i]] = null;
            }
        }
        private void ClearVars()
        {
            Session["qc-a3-delete"] = false;
            Session["qc-a4-delete"] = false;
        }
        // ================================================================================================ Event Handlers =================================================

        protected void Save_Click(object sender, EventArgs e)
        {
            SaveState();
            var quizID = Repo.CreateQuiz(new Quiz { AuthorID = int.Parse(UserState["userid"]), QuizName = CreationState.QuizName ?? tbQuizName.Text });
            foreach (var page in CreationState.Pages)
            {
                var pagedata = page.Value;
                var questionID = Repo.CreateQuizQuestion(new QuizQuestion
                {
                    AnswerTimeSeconds = pagedata.SelectedTime,
                    CorrectAnswer = pagedata.SelectedAnswer,
                    QuizID = quizID,
                    AnswerNumber = pagedata.AnswerNumber,
                    QuestionText = pagedata.Question
                });
                Repo.CreateQuizAnswer(new QuizAnswer
                {
                    AnswerText = pagedata.Answer1,
                    QuestionOrder = 1,
                    QuizQuestionID = questionID
                });
                Repo.CreateQuizAnswer(new QuizAnswer
                {
                    AnswerText = pagedata.Answer2,
                    QuestionOrder = 2,
                    QuizQuestionID = questionID
                });
                if (pagedata.AnswerNumber > 2)
                    Repo.CreateQuizAnswer(new QuizAnswer
                    {
                        AnswerText = pagedata.Answer3,
                        QuestionOrder = 3,
                        QuizQuestionID = questionID
                    });
                if (pagedata.AnswerNumber > 3)
                    Repo.CreateQuizAnswer(new QuizAnswer
                    {
                        AnswerText = pagedata.Answer4,
                        QuestionOrder = 4,
                        QuizQuestionID = questionID
                    });
                // TODO update Session["qc-ID-toEdit"] after save
            }
        }
        protected void Discard_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
            ClearSession();
        }
        protected void btTriangle_ServerClick(object sender, EventArgs e)
        {
            Session["qc-SelectedAnswer"] = 1;
        }
        protected void btStar_ServerClick(object sender, EventArgs e)
        {
            Session["qc-SelectedAnswer"] = 2;
        }
        protected void btPentagon_ServerClick(object sender, EventArgs e)
        {
            Session["qc-SelectedAnswer"] = 3;
        }
        protected void btCircle_ServerClick(object sender, EventArgs e)
        {
            Session["qc-SelectedAnswer"] = 4;

        }
        private void QuizCreationTimeButton1_ServerClick(object sender, EventArgs e)
        {
            Session["qc-SelectedTime"] = 120;
        }
        private void QuizCreationTimeButton2_ServerClick(object sender, EventArgs e)
        {
            Session["qc-SelectedTime"] = 60;
        }
        private void QuizCreationTimeButton3_ServerClick(object sender, EventArgs e)
        {
            Session["qc-SelectedTime"] = 30;
        }
        private void QuizCreationTimeButton4_ServerClick(object sender, EventArgs e)
        {
            Session["qc-SelectedTime"] = 15;
        }
        protected void ButtonCustomTime_ServerClick(object sender, EventArgs e)
        {
            if (int.TryParse(TextboxCustomTime.Text, out int seconds))
            {
                if (seconds < 10 || seconds > 120)
                {
                    TextboxCustomTime.Text = string.Empty;
                }
                else
                {
                    Session["qc-SelectedTime"] = seconds;
                }
            }
        }
        private void QuizCreationAnswer3_OnAddAnswer(object sender, EventArgs e)
        {
            var delete = (bool)(Session["qc-a3-delete"] ?? false);
            int NumberOfQuestions = delete ? 2 : 3;
            Session["qc-AnswerNumber"] = NumberOfQuestions;
            Session["qc-a3-delete"] = !delete;
            if (!delete)
                Session["qc-a4-delete"] = false;
        }
        private void QuizCreationAnswer4_OnAddAnswer(object sender, EventArgs e)
        {
            var delete = (bool)(Session["qc-a4-delete"] ?? false);
            int NumberOfQuestions = delete ? 3 : 4;
            Session["qc-AnswerNumber"] = NumberOfQuestions;
            Session["qc-a4-delete"] = !delete;
        }
        protected void Left_ServerClick(object sender, EventArgs e)
        {
            if (PageNumber == 0)
            {
                return;
            }
            SaveState();
            ClearVars();
            Response.Redirect($"QuizCreation.aspx?page={PageNumber - 1}");
        }
        protected void Right_ServerClick(object sender, EventArgs e)
        {
            if (PageNumber == 99)
            {
                return;
            }
            SaveState();
            ClearVars();
            Response.Redirect($"QuizCreation.aspx?page={PageNumber + 1}");
        }
    }
}