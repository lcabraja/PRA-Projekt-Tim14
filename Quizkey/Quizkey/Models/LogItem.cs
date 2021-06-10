using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    //--------------------------------------------------------LogItem---------------------------------------------------------
    public class LogItem
    {
        public int IDLogItem { get; set; }
        public int QuizSessionID { get; set; }
        public int QuizQuestionID { get; set; }
        public int QuizAnswerID { get; set; }
        public int AttendeeID { get; set; }
        public int Points { get; set; }
    }
}
