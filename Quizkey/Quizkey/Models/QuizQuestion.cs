using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    //------------------------------------------------------QuizQuestion------------------------------------------------------
    public class QuizQuestion
    {
        public int IDQuizQuestion { get; set; }
        public int QuizID { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public int AnswerTimeSeconds { get; set; }
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

            return IDQuizQuestion.Equals((obj as QuizQuestion).IDQuizQuestion);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return IDQuizQuestion.GetHashCode();
        }
    }
}
