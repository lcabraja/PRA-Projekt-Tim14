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
        public List<QuizQuestion> questions
        {
            get
            {
                if ((List<QuizQuestion>)Session["qk-creation-quizQuestions"] != null)
                    return (List<QuizQuestion>)Session["qk-creation-quizQuestions"];
                Session["qk-creation-quizQuestions"] = new List<QuizQuestion>();
                return questions;
            }
            set { Session["qk-creation-quizQuestions"] = value; }
        }
        public List<QuizAnswer> answers
        {
            get
            {
                if ((List<QuizAnswer>)Session["qk-creation-quizAnswers"] != null)
                    return (List<QuizAnswer>)Session["qk-creation-quizAnswers"];
                Session["qk-creation-quizAnswers"] = new List<QuizAnswer>();
                return answers;
            }
            set { Session["qk-creation-quizAnswers"] = value; }
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

            LoadSessionValues();
        }

        private void LoadSessionValues()
        {
            QuizCreation quizCreation = Session["QuizCreationStore"] as QuizCreation;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.tbQuizName.Text = Session["QuizName"]?.ToString();

            // Correct answer selection
            // Time limit selection
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
            if (PageValid())
            {
                Quiz quiz = new Quiz { AuthorID = int.Parse(UserState["userid"]), QuizName = tbQuizName.Text };
                int quizID = Repo.CreateQuiz(quiz);
                System.Threading.Thread.Sleep(10000);
                questions.Add(new QuizQuestion { QuestionText = "test" });
                questions.Add(new QuizQuestion { QuestionText = "test1" });
                questions.Add(new QuizQuestion { QuestionText = "test2" });
                questions.Add(new QuizQuestion { QuestionText = "test3" });
                var hold = questions;
            }
        }


        private bool PageValid()
        {
            return true;
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