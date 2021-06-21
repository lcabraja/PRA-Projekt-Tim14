using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserState");

            cookie["loggedin"] = "author";
            cookie["language"] = "en";
            cookie["username"] = "Pero123";
            cookie["points"] = "6969";
            cookie["userid"] = "1007";
            cookie["quizcode"] = "poland";

            Response.SetCookie(cookie);
        }
    }
}