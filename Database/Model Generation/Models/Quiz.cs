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
    }
}
