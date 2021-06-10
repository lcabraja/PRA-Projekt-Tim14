using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    //-------------------------------------------------------RecentQuiz-------------------------------------------------------
    public class RecentQuiz
    {
        public int IDRecentQuiz { get; set; }
        public int QuizID { get; set; }
        public DateTime LastEvent { get; set; }
    }
}
