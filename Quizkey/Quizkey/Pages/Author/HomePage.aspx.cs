using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Quizkey.Cookies;
using Quizkey.Models;
using Quizkey.User_Controls;

namespace Quizkey
{
    public partial class HomePage : System.Web.UI.Page
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
            if (UserState == null || UserState["loggedin"] != "author" || Session["userid"] == null)
            {
                Response.Redirect("/");
                return;
            }
            this.PreRender += HomePage_PreRender;
        }

        private void HomePage_PreRender(object sender, EventArgs e)
        {
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;

            Repo.GetMultipleQuiz().Where(x => x.AuthorID == (int)Session["userid"]).ToList().ForEach(x =>
            {
                var QuestionNumber = Repo.GetMultipleQuizQuestion().Where(y => y.QuizID == x.IDQuiz).Count();
                quizplace.Controls.AddAt(0, GenerateCard(x, QuestionNumber, cookie, locale));
            });
        }

        private HtmlGenericControl GenerateCard(Quiz x, int QuestionNumber, CookieParseWrapper cookie, Localizer locale)
        {
            var card = new HtmlGenericControl("div");
            card.Attributes["style"] = "width: 18rem; display: inline-flex;";
            card.Attributes["class"] = "card m-1";
            var cardbody = new HtmlGenericControl("div");
            cardbody.Attributes["class"] = "card-body";
            var cardtitle = new HtmlGenericControl("h5");
            cardtitle.Attributes["class"] = "card-title";
            cardtitle.InnerText = x.QuizName;
            var cardtext = new HtmlGenericControl("p");
            cardtext.InnerText = $"{QuestionNumber} {locale.Resource("questions", cookie.Enum(Cookies.UserState.language))}";
            var play = new LinkButton();
            play.Text = "Play";
            play.CssClass = "btn btn-outline-success mx-1";
            play.Attributes["quizid"] = x.IDQuiz.ToString();
            play.Click += Playclick_Click;
            var edit = new LinkButton();
            edit.Text = "Edit";
            edit.CssClass = "btn btn-outline-info mx-1";
            edit.Attributes["quizid"] = x.IDQuiz.ToString();
            edit.Click += Edit_Click;
            var delete = new LinkButton();
            delete.Text = "Delete";
            delete.CssClass = "btn btn-outline-danger mx-1";
            delete.Attributes["quizid"] = x.IDQuiz.ToString();
            delete.Click += Delete_Click;

            cardbody.Controls.Add(cardtitle);
            cardbody.Controls.Add(cardtext);
            cardbody.Controls.Add(play);
            cardbody.Controls.Add(edit);
            cardbody.Controls.Add(delete);

            card.Controls.Add(cardbody);
            return card;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton button)
            {
                int QuizID = int.Parse(button.Attributes["quizid"]);
                Session["qc-ID-toEdit"] = QuizID;
                Response.Redirect("/QuizCreation.aspx");
            }
        }

        private void Playclick_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton button)
            {
                int QuizID = int.Parse(button.Attributes["quizid"]);
                var SessionID = Repo.CreateQuizSession(new QuizSession { OccurredAt = DateTimeOffset.Now, QuizID = QuizID, SessionCode = Repo.GenerateQuizCode() });
                Session["SessionID"] = SessionID;
                Session["qp-quizstate-playing"] = true;
                Response.Redirect("/WaitingRoom.aspx");
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton button)
            {
                int QuizID = int.Parse(button.Attributes["quizid"]);
                Repo.DeleteQuizComplete(QuizID);
            }
        }
    }
}
