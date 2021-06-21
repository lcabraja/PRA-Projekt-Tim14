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
            //if (Request.Cookies["UserState"] == null)
            //{
            //    Response.Redirect("/");
            //}


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
    }
}