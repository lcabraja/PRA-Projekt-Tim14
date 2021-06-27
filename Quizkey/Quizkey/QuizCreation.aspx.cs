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
        public bool TriangleFill { get; set; }
        public bool StarFill { get; set; }
        public bool PentagonFill { get; set; }
        public bool CircleFill { get; set; }

        public QuizCreationModel CreationState
        {
            get
            {
                if (Session["qk-QuizCreationModel"] == null)
                {
                    Session["qk-QuizCreationModel"] = new QuizCreationModel();
                }
                return Session["qk-QuizCreationModel"] as QuizCreationModel;
            }
            set { Session["qk-QuizCreationModel"] = value; }
        }
        public HttpCookie UserState
        {
            get { return Request.Cookies["UserState"]; }
            set { Response.SetCookie(value); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += Page_PreRender;
            Response.Write(Request.QueryString.AllKeys.ToList().Aggregate("!!", (a, b) => a += " " + b, x => x.ToUpper()));
            Response.Write("<br/>");
            Response.Write(GetSession());

            QuizCreationButton1.ASAAAAAAAAAAAAAAAAAAAA += btTriangle_ServerClick;
            QuizCreationButton2.ASAAAAAAAAAAAAAAAAAAAA += btStar_ServerClick;
            QuizCreationButton3.ASAAAAAAAAAAAAAAAAAAAA += btPentagon_ServerClick;
            QuizCreationButton4.ASAAAAAAAAAAAAAAAAAAAA += btCircle_ServerClick;

            QuizCreationTimeButton1.ServerClick += QuizCreationTimeButton1_ServerClick;
            QuizCreationTimeButton2.ServerClick += QuizCreationTimeButton2_ServerClick;
            QuizCreationTimeButton3.ServerClick += QuizCreationTimeButton3_ServerClick;
            QuizCreationTimeButton4.ServerClick += QuizCreationTimeButton4_ServerClick;

            QuizCreationAnswer3.OnAddAnswer += QuizCreationAnswer3_OnAddAnswer;
            QuizCreationAnswer4.OnAddAnswer += QuizCreationAnswer4_OnAddAnswer;
            LoadSessionValues();
        }

        private void LoadSessionValues()
        {
            if (Request.QueryString.GetValues("page") == null)
            {
                Response.Redirect($"{Request.RawUrl}?page=0");
                return;
            }

            int pageNumber = int.Parse(Request.QueryString.GetValues("page")[0]);

            if (pageNumber < 0)
            {
                Response.Redirect($"{Request.RawUrl}?page=0");
            }

            if (CreationState.Pages == null)
                return;

            if (pageNumber >= CreationState.Pages.Count)
            {
                Response.Redirect($"{Request.RawUrl}?page={CreationState.Pages.Count - 1}");
            }
            var page = int.Parse(Request.QueryString.GetValues("page")[0]);

            QuizCreationPage currentPage = CreationState.Pages[pageNumber];

            base.Session["SelectedAnswer"] = currentPage.SelectedAnswer;
            Session["SelectedTime"] = currentPage.SelectedTime;

            tbQuestion.Text = currentPage.Question;

            Session["AnswerNumber"] = currentPage.AnswerNumber;

            QuizCreationAnswer1.tbAnswer.Text = currentPage.Answer1;
            QuizCreationAnswer2.tbAnswer.Text = currentPage.Answer2;
            QuizCreationAnswer3.tbAnswer.Text = currentPage.Answer3;
            QuizCreationAnswer4.tbAnswer.Text = currentPage.Answer4;

            SetQuestionNumbers();
        }

        private void QuizCreationAnswer3_OnAddAnswer(object sender, EventArgs e)
        {
            var delete = (bool)(Session["qk-a3-delete"] ?? false);
            int NumberOfQuestions = delete ? 2 : 3;
            Session["AnswerNumber"] = NumberOfQuestions;
            Session["qk-a3-delete"] = !delete;
        }
        private void QuizCreationAnswer4_OnAddAnswer(object sender, EventArgs e)
        {
            var delete = (bool)(Session["qk-a4-delete"] ?? false);
            int NumberOfQuestions = delete ? 3 : 4;
            Session["AnswerNumber"] = NumberOfQuestions;
            Session["qk-a4-delete"] = !delete;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.tbQuizName.Text = Session["QuizName"]?.ToString();

            // Answer number selection
            SetQuestionNumbers();

            // Correct answer selection
            if (Session["SelectedAnswer"] != null)
            {
                int answer = (int)Session["SelectedAnswer"];
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

            // Time limit selection
            if (Session["SelectedTime"] != null)
            {

                int time = (int)Session["SelectedTime"];
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
                    default:
                        ButtonCustomTime.Attributes["class"] = "btn btn-light";
                        TextboxCustomTime.Text = time.ToString();
                        break;
                }
            }
        }

        private void SetQuestionNumbers()
        {
            if (Session["AnswerNumber"] != null)
            {
                int answer = (int)Session["AnswerNumber"];
                switch (answer)
                {
                    case 3:
                        QuizCreationAnswer3.Delete = true;

                        QuizCreationAnswer4.Visible = true;
                        QuizCreationAnswer4.Delete = false;
                        break;
                    case 4:
                        QuizCreationAnswer3.Delete = true;

                        QuizCreationAnswer4.Visible = true;
                        QuizCreationAnswer4.Delete = true;
                        break;
                    default:
                        QuizCreationAnswer3.Delete = false;

                        QuizCreationAnswer4.Visible = false;
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

        protected void Save_Click(object sender, EventArgs e)
        {

        }

        // ================================================================================================ Event Handlers

        protected void Discard_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }
        protected void btTriangle_ServerClick(object sender, EventArgs e)
        {
            Session["SelectedAnswer"] = 1;
        }
        protected void btStar_ServerClick(object sender, EventArgs e)
        {
            Session["SelectedAnswer"] = 2;
        }
        protected void btPentagon_ServerClick(object sender, EventArgs e)
        {
            Session["SelectedAnswer"] = 3;
        }
        protected void btCircle_ServerClick(object sender, EventArgs e)
        {
            Session["SelectedAnswer"] = 4;

        }
        private void QuizCreationTimeButton1_ServerClick(object sender, EventArgs e)
        {
            Session["SelectedTime"] = 120;
        }
        private void QuizCreationTimeButton2_ServerClick(object sender, EventArgs e)
        {
            Session["SelectedTime"] = 60;
        }
        private void QuizCreationTimeButton3_ServerClick(object sender, EventArgs e)
        {
            Session["SelectedTime"] = 30;
        }
        private void QuizCreationTimeButton4_ServerClick(object sender, EventArgs e)
        {
            Session["SelectedTime"] = 15;
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
                    Session["SelectedTime"] = seconds;
                }
            }
        }
    }
}