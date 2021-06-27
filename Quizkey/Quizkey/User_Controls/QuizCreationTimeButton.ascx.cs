using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey.User_Controls
{
    public partial class QuizCreationTimeButton : System.Web.UI.UserControl
    {
        public event System.EventHandler ServerClick;
        public int Seconds { get; set; }
        public bool Filled { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += QuizCreationButton_PreRender;
            Button.ServerClick += ServerClick;
        }

        private void QuizCreationButton_PreRender(object sender, EventArgs e)
        {
            Button.InnerText = $"{Seconds} sekund{GetLastLetter()}";
            Button.Attributes["class"] = $"btn {(Filled ? "btn-light" : "btn-primary")}";
        }

        private string GetLastLetter()
        {
            var lastDigit = Seconds % 10;
            switch (lastDigit)
            {
                case 1:
                    return "a";
                case 2:
                case 3:
                case 4:
                    return "e";
                default:
                    return "i";
            }
        }
    }
}