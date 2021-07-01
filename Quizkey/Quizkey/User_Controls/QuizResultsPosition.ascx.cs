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

        protected global::System.Web.UI.WebControls.PlaceHolder aaaaaaa;
        protected void Page_Load(object sender, EventArgs e)
        {
            aaaaaaa = new PlaceHolder();
            this.PreRender += QuizResultsPosition_PreRender;
        }
        private void QuizResultsPosition_PreRender(object sender, EventArgs e)
        {
            Response.Write($"<div class=\"bg-{BackgroundColor} rounded\"><h2 class=\"d-grid\">{Position}. {Username}</h2>");
            aaaaaaa.Controls.Add(new LiteralControl($"<div class=\"bg-{BackgroundColor} rounded\"><h2 class=\"d-grid\">{Position}. {Username}</h2>"));
        }
    }
}