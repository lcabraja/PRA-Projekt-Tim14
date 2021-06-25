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
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
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

        protected void Discard_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }
        private void ResetShapes()
        {
            Session["TriangleFill"] = false;
            Session["StarFill"] = false;
            Session["PentagonFill"] = false;
            Session["CircleFill"] = false;
        }
        protected void btTriangle_ServerClick(object sender, EventArgs e)
        {
            ResetShapes();
            Session["TriangleFill"] = true;
            QuizCreationAnswer1.Filled = true;
            QuizCreationButton1.IsClicked = true;
        }
        protected void btStar_ServerClick(object sender, EventArgs e)
        {
            ResetShapes();
            Session["StarFill"] = true;
            QuizCreationAnswer2.Filled = true;
            QuizCreationButton2.IsClicked = true;
        }
        protected void btPentagon_ServerClick(object sender, EventArgs e)
        {
            ResetShapes();
            Session["PentagonFill"] = true;
            QuizCreationAnswer3.Filled = true;
            QuizCreationButton3.IsClicked = true;
        }
        protected void btCircle_ServerClick(object sender, EventArgs e)
        {
            ResetShapes();
            Session["CircleFill"] = true;
            QuizCreationAnswer4.Filled = true;
            QuizCreationButton4.IsClicked = true;

        }
    }
}