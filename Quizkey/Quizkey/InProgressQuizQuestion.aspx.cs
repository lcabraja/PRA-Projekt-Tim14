using Quizkey.Cookies;
using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class InProgressQuizQuestion : System.Web.UI.Page
    {
        public string SessionCode
        {
            get
            {
                return Repo.GetQuizSession(SessionID).SessionCode;
            }
        }
        public int SessionID
        {
            get
            {
                if (Session["SessionID"] == null)
                {
                    Response.Redirect("/");
                }
                return int.Parse(Session["SessionID"].ToString());
            }
        }
        public int PageNumber
        {
            get
            {
                return (int)(Session["qp-quizstate-PageNumber"] ?? 0);
            }

            set
            {
                Session["qp-quizstate-PageNumber"] = value;
            }
        }
        public bool StatePlaying
        {
            get
            {
                return (bool)(Session["qp-quizstate-playing"] ?? false);
            }
            set
            {
                Session["qp-quizstate-playing"] = value;
            }
        }
        public QuizCreationModel CreationState
        {
            get
            {
                return Session["qc-QuizCreationModel"] as QuizCreationModel;
            }
            set { Session["qc-QuizCreationModel"] = value; }
        }
        public QuizCreationModel GetCreationState()
        {
            if (CreationState == null)
            {
                CreationState = LoadQuizData.GetQuizData(SessionID);
            }
            return CreationState;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!StatePlaying)
                Response.Write("notplaying ");
            this.PreRender += Page_PreRender;

            if (Request.QueryString["nextpage"] != null)
            {
                Response.Redirect("Results.aspx");
            }

            QuizCreationPage page;

            var data = GetCreationState();
            page = GetCreationState().Pages[PageNumber];

            countdowntime.Attributes["seconds"] = page.SelectedTime.ToString();
        }
        private void Page_PreRender(object sender, EventArgs e)
        {
            QuizCreationPage page;

            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;
            pitanjetext.InnerText = locale.Resource("Go", cookie.Enum(UserState.language));

            var data = GetCreationState();
            page = GetCreationState().Pages[PageNumber];
            try
            {
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return;
            }

            lbQuestion.Text = page.Question;

            Answer1.AnswerText = page.Answer1;
            Answer2.AnswerText = page.Answer2;
            if (page.Answer3 != null)
            {
                Answer3.Visible = true;
                Answer3.AnswerText = page.Answer3;
            }
            if (page.Answer4 != null)
            {
                Answer4.Visible = true;
                Answer4.AnswerText = page.Answer4;
            }
        }
    }
}