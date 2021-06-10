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
        public override string ToString() =>
                $"IDQuizSession: {IDQuizSession}, QuizID: {QuizID}, OccurredAt: {OccurredAt}, SessionCode: {SessionCode}";

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

            return IDQuizSession.Equals((obj as QuizSession).IDQuizSession);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return IDQuizSession.GetHashCode();
        }
    }
}
