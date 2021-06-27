using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    [Serializable]
    public class QuizCreationPage
    {
        public int SelectedAnswer { get; set; }
        public int SelectedTime { get; set; }
        public int AnswerNumber { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
    }
} 