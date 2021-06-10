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
        public DateTimeOffset LastEvent { get; set; }
        public override string ToString() =>
                $"IDRecentQuiz: {IDRecentQuiz}, QuizID: {QuizID}, LastEvent: {LastEvent}";

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

            return IDRecentQuiz.Equals((obj as RecentQuiz).IDRecentQuiz);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return IDRecentQuiz.GetHashCode();
        }
    }
}
