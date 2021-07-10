using Quizkey.Cookies;
using Quizkey.Extensions;
using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quizkey
{
    public partial class EndOfQuizAttendee : System.Web.UI.Page
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
        public static bool TransmittingFile { get; internal set; } = false;
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
            this.PreRender += EndOfQuizAttendee_PreRender;
        }

        private void EndOfQuizAttendee_PreRender(object sender, EventArgs e)
        {
            QuizCreationModel model = GetCreationState();
            HttpCookie userState = Request.Cookies["UserState"];
            CookieParseWrapper cookie = new CookieParseWrapper(userState);
            Localizer locale = Quizkey.Models.Localizer.Instance;

            var attendees = Repo.GetMultipleAttendee().Where(x => x.SessionID == SessionID);
            var sortedAttendees = attendees.OrderBy(GetScore);
            var top3 = sortedAttendees.Take(3).ToList();
            if (top3.Count > 0)
            {
                place1h2.InnerText = top3[0].Username.SplitByLength(10).Aggregate((x, y) => $"{x} {y}");
                place1points.InnerText = (-GetScore(top3[0])).ToString();
            }
            if (top3.Count > 1)
            {
                place2h2.InnerText = top3[1].Username.SplitByLength(10).Aggregate((x, y) => $"{x} {y}");
                place2points.InnerText = (-GetScore(top3[1])).ToString();
            }
            if (top3.Count > 2)
            {
                place3h2.InnerText = top3[2].Username.SplitByLength(10).Aggregate((x, y) => $"{x} {y}");
                place3points.InnerText = (-GetScore(top3[2])).ToString();
            }
            int position = 4;
            sortedAttendees.Skip(3)
                           .ToList()
                           .ForEach(x => runnersup.Controls.Add(
                                new LiteralControl(
                                    $"<h2 class=\"d-grid m-2 p-1 bg-light rounded\">" +
                                        "<div style=\"display: flex;\">" +
                                            $"<span style=\"font-weight: 100; display: inline-flex; padding-right: 1rem;\">{position++}</span>" +
                                            x.Username +
                                            $"<span style=\"font-weight: 100; display: inline-flex; padding-left: 1rem;\">{-GetScore(x)} Points</span>" +
                                        "</div>" +
                                    "</h2>"
                            )));
            aposition.InnerText = $"{locale.Resource("yourposition", cookie.Enum(UserState.language))}: {(sortedAttendees.ToList().IndexOf(new Attendee { IDAttendee = (int)Session["attendeeid"] }) + 1)}";
            tbQuizName.Text = model.QuizName;
        }

        private int GetScore(Attendee attendee)
        {
            return -Repo.GetMultipleLogItem().Where(x => x.QuizSessionID == SessionID && x.AttendeeID == attendee.IDAttendee).Select(x => x.Points).Sum();
        }
    }
}