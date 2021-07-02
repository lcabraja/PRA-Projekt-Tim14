using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btncheck1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        protected void btncheck2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void btncheck3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}