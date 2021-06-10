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
    }
}
