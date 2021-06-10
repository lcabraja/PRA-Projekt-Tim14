using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    //------------------------------------------------------QuizSession-------------------------------------------------------
    public class QuizSession
    {
        public int IDQuizSession { get; set; }
        public int QuizID { get; set; }
        public DateTimeOffset OccurredAt { get; set; }
        public string SessionCode { get; set; }
    }
}
