using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    //----------------------------------------------------------Quiz----------------------------------------------------------
    public class Quiz
    {
        public int IDQuiz { get; set; }
        public int AuthorID { get; set; }
        public string QuizName { get; set; }
        public override string ToString() =>
                $"IDQuiz: {IDQuiz}, AuthorID: {AuthorID}, QuizName: {QuizName}";

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

            return IDQuiz.Equals((obj as Quiz).IDQuiz);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return IDQuiz.GetHashCode();
        }
    }
}
