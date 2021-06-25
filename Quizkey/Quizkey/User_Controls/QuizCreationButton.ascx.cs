using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey.User_Controls
{
    public partial class QuizCreationButton : System.Web.UI.UserControl
    {
        public event System.EventHandler ASAAAAAAAAAAAAAAAAAAAA;
        public bool IsClicked { get; set; } = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += QuizCreationButton_PreRender;
            Button.ServerClick += ASAAAAAAAAAAAAAAAAAAAA;
        }

        private void QuizCreationButton_PreRender(object sender, EventArgs e)
        {
            Button.Attributes["class"] = $"btn {(IsClicked ? "btn-light" : "btn-primary")}";
            icon.Attributes["class"] = $"bi bi-triangle{(IsClicked ? "-fill" : string.Empty)} qk-quizcreation-fontsize";
        }
    }
}