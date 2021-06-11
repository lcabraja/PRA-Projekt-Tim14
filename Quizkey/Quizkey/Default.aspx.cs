using Quizkey.Models;
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
            _Navbar.Points += 1;
            if (Request.Cookies["UserState"] == null)
            {

            }
            HttpCookie userState = new HttpCookie("UserState");
            userState["loggedIn"] = "attendee";
            userState["userName"] = "pero123";
            Response.Cookies.Set(userState);
        }
    }
}