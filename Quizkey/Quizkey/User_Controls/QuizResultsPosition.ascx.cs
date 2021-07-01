using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey.User_Controls
{
    public partial class QuizResultsPosition : System.Web.UI.UserControl
    {
        public string BackgroundColor { get; set; } = "light";
        public int Position { get; set; }
        public string Username { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += QuizResultsPosition_PreRender;
        }
        private void QuizResultsPosition_PreRender(object sender, EventArgs e)
        {
            aaaaaaaaaa.Attributes["class"] = $"bg-{BackgroundColor} rounded";
            bbbbbbbbb.InnerText = $"{Position}. {Username}";
        }
    }
}