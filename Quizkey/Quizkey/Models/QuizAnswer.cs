using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    //-------------------------------------------------------QuizAnswer-------------------------------------------------------
    public class QuizAnswer
    {
        public int IDQuizAnswer { get; set; }
        public int QuizQuestionID { get; set; }
        public string AnswerText { get; set; }
        public int QuestionOrder { get; set; }
        public override string ToString() =>
                $"IDQuizAnswer: {IDQuizAnswer}, QuizQuestionID: {QuizQuestionID}, AnswerText: {AnswerText}, QuestionOrder: {QuestionOrder}";

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

            return IDQuizAnswer.Equals((obj as QuizAnswer).IDQuizAnswer);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return IDQuizAnswer.GetHashCode();
        }
    }
}
