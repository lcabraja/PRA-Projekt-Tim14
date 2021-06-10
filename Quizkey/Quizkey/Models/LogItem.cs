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
        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return IDLogItem.Equals((obj as LogItem).IDLogItem);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return IDLogItem.GetHashCode();
        }
    }
}
