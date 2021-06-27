using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    [Serializable]
    public class QuizCreationPage
    {
        public int QuestionID {get; set; }
        public int SelectedAnswer { get; set; }
        public int SelectedTime { get; set; }
        public int AnswerNumber { get { 
            int answerCount = 0; 
            Answer1.Equals(string.Empty) ? answerCount += 1 : void; 
            Answer2.Equals(string.Empty) ? answerCount += 1 : void; 
            Answer3.Equals(string.Empty) ? answerCount += 1 : void; 
            Answer4.Equals(string.Empty) ? answerCount += 1 : void;
            return answerCount;
        } }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
    }
} 