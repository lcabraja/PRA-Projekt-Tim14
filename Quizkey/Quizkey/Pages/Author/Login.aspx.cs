using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BCrypt.Net;

namespace Quizkey
{
    public partial class Login : System.Web.UI.Page
    {
        public bool ShowErrorMessage { get; set; }
        public string ErrorMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += Login_PreRender;
            if (Request.Cookies["UserState"] != null && Request.Cookies["UserState"]["loggedin"] == "author")
            {
                Session["userid"] = int.Parse(Request.Cookies["UserState"]["userid"]);
                Response.Redirect("/Pages/Author/HomePage.aspx");
                return;
            }
            if (IsPostBack)
                if (RequiredFieldValidator2.IsValid && RequiredFieldValidator6.IsValid)
                {
                    var users = Repo.GetMultipleAuthor().Where(x => x.Username == tbUsername.Text && BCrypt.Net.BCrypt.Verify(tbPassword.Text, x.PasswordHash));
                    if (users.Count() > 0)
                    {
                        HttpCookie cookie = new HttpCookie("UserState");

                        cookie["loggedin"] = "author";
                        cookie["language"] = "en";
                        cookie["username"] = tbUsername.Text;
                        cookie["userid"] = users.First().IDAuthor.ToString();
                        Session["userid"] = users.First().IDAuthor;
                        Response.SetCookie(cookie);
                        Response.Redirect("/Pages/Author/HomePage.aspx");
                    }
                    else
                    {
                        ShowErrorMessage = true;
                        ErrorMessage = "Incorrect username or password.";
                    }
                }
        }

        private void Login_PreRender(object sender, EventArgs e)
        {
            if (ShowErrorMessage)
                diverrormessage.Controls.Add(new LiteralControl($"<div class=\"badge bg-danger\">{ErrorMessage}</div>"));
        }
    }
}