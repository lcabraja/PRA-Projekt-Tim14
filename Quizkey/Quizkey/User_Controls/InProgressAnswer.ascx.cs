using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey.User_Controls
{
    public partial class InProgressAnswer : System.Web.UI.UserControl
    {
        public string Shape { get; set; }
        public string AnswerText { get; set; }
        public bool Filled { get; set; } = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += QuizCreationAnswer_PreRender;
        }

        private void QuizCreationAnswer_PreRender(object sender, EventArgs e)
        {
            placeHolder.Controls.Add(new LiteralControl($"<i class=\"bi bi-{Shape}{(Filled ? "-fill" : string.Empty)} text-dark m-auto qk-quizcreation-fontsize\"></i>"));
            lbAnswer.Text = AnswerText;
        }
    }
}