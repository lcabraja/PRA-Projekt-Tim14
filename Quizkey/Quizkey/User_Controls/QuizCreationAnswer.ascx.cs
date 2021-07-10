using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class QuizCreationAnswer : System.Web.UI.UserControl
    {
        public global::System.Web.UI.WebControls.TextBox tbAnswer;
        public event System.EventHandler OnAddAnswer;
        public string Shape { get; set; }
        public bool Filled { get; set; } = false;
        public bool Enabled { get; set; } = false;
        public bool Delete { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += QuizCreationAnswer_PreRender;
            this.enabler.ServerClick += OnAddAnswer;
        }

        private void QuizCreationAnswer_PreRender(object sender, EventArgs e)
        {
            placeHolder.Controls.Add(new LiteralControl($"<i class=\"bi bi-{Shape}{(Filled ? "-fill" : string.Empty)} m-auto qk-quizcreation-fontsize\"></i>"));
            enabler.Visible = Enabled;
            enabler.Attributes["class"] = $"btn btn-{(Delete ? "danger" : "success")} m-auto";
            icon.Attributes["class"] = $"bi bi-{(Delete ? "x-circle" : "plus-circle")} m-auto qk-quizcreation-fontsize";
        }
    }
}