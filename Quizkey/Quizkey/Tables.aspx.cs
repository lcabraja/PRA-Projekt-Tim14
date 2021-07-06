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
        public int AuthorID { get { return (int)Session["userid"]; } }
        private class QuizTableRow
        {
            public string QuizName { get; set; }
            public int NumberOfQuestions { get; set; }
            public int TimesPlayed { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var values = new ArrayList();
            var quizes = Repo.GetMultipleQuiz(AuthorID);
            var sessions = Repo.GetMultipleQuizSession(AuthorID);
            foreach (Quiz item in quizes)
            {
                values.Add(new QuizTableRow {
                    QuizName = item.QuizName, 
                    NumberOfQuestions = Repo.GetMultipleQuizQuestion(item.IDQuiz).Count, 
                    TimesPlayed = sessions.Where(x => x.QuizID == item.IDQuiz).Count()
                });
            }
            QuizRepeater.DataSource = values;
            QuizRepeater.DataBind();

            var logItems = Repo.GetMultipleLogItem(AuthorID);
            
            //values.Add(new PositionData())
        }
    }
}