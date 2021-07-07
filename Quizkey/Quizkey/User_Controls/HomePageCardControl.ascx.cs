using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey.User_Controls
{
    public partial class HomePageCardControl : System.Web.UI.UserControl
    {
        public string QuizTitle { get; set; }
        public int QuestionNumber { get; set; }
        public int QuizID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += HomePageQuizControl_PreRender;
        }
        protected PlaceHolder placeholdertitle;

        private void HomePageQuizControl_PreRender(object sender, EventArgs e)
        {
            placeholdertitle.Controls.Add(new LiteralControl($"<h5 class=\"card-title\">{QuizTitle ?? string.Empty}</h5>"));
            questionnumber.InnerText = $"{QuestionNumber} Questions";
        }

        protected void Play_Click(object sender, EventArgs e)
        {
            var SessionID = Repo.CreateQuizSession(new QuizSession { OccurredAt = DateTimeOffset.Now, QuizID = QuizID, SessionCode = Repo.GenerateQuizCode() });
            Session["SessionID"] = SessionID;
            Session["qp-quizstate-playing"] = true;
            Response.Redirect("/WaitingRoom.aspx");
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Session["qc-ID-toEdit"] = QuizID;
            Response.Redirect("QuizCreation.aspx");
        }

        protected void Deletee_Click(object sender, EventArgs e)
        {
            Repo.DeleteQuizComplete(QuizID);
        }
    }
}