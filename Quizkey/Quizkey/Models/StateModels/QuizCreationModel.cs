using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    public class QuizCreationModel
    {
        public string QuizName { get; set; }
        public int QuizID  {get; set; }
        public SortedList<int, QuizCreationPage> Pages { get; private set; }

        public QuizCreationModel()
        {
            Pages = new SortedList<int, QuizCreationPage>();
        }
    }
}