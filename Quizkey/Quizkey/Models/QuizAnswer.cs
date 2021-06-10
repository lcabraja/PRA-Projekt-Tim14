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
        public string QuestionOrder { get; set; }
    }
}
