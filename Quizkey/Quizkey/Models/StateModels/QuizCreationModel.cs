using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    public class QuizCreationModel
    {
        public string QuizName { get; set; }
        public List<QuizCreationPage> Pages { get; private set; }
    }
}