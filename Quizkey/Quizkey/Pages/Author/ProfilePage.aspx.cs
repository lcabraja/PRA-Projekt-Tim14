using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        public HttpCookie UserState
        {
            get
            {
                return Request.Cookies["UserState"];
            }
            set
            {
                Response.SetCookie(value);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie cookie = new HttpCookie("UserState");

            //var author = Repo.GetAuthor(2005);
            
            //cookie["loggedin"] = "author";
            //cookie["language"] = "en";
            //cookie["username"] = author.Username;
            //cookie["userid"] = "2005";

            //Session["userid"] = 2005;
            //Response.SetCookie(cookie);

            if (UserState == null || UserState["loggedin"] != "author" || Session["userid"] == null)
            {
                Response.Redirect("/");
                return;
            }

            this.PreRender += ProfilePage_PreRender;

            //SqlConnection sqlcon = new SqlConnection("putanja");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("Update Author set korisnickoime=@korisnickoime");
            //cmd.Parameters.AddWithValue("@Korisnickoime", txtNovoKorisnickoIme.Text);
            //cmd.ExecuteNonQuery();
            //con.Close();
        }

        private void ProfilePage_PreRender(object sender, EventArgs e)
        {
            var author = Repo.GetAuthor((int)Session["userid"]);
            tbUsername.Text = author.Username;
            tbEmail.Text = author.Email;
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            Repo.DeleteAuthorComplete((int)Session["userid"]);
        }

        protected void btUpdateAccount_Click(object sender, EventArgs e)
        {
            var author = Repo.GetAuthor((int)Session["userid"]);
            if (BCrypt.Net.BCrypt.Verify(tbPassword.Text, author.PasswordHash))
            {
                Repo.UpdateAuthor(new Author { 
                    IDAuthor = (int)Session["userid"], 
                    Username = tbUsername.Text, 
                    Email = tbEmail.Text, 
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(tbPasswordNew.Text) 
                });
            } else
            {
                var n = 100;
                var d = 10;
                Response.Write(10 / (10 - n / d));
            }
        }

        //button za promjenu zaporke isto ali s zaporkom i ponovljenom zaporkom

        //delete
        // SqlConnection sqlcon = new SqlConnection("putanja");
        // con.Open();
        //  SqlCommand cmd = new SqlCommand("Delete Author where email=@email");
        //   cmd.Parameters.AddWithValue("@Email",txtEmail.Text);
        //  cmd.ExecuteNonQuery();
        //con.Close();
    }
}