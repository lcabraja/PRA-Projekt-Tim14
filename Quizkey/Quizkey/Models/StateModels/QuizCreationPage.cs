using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    [Serializable]
    public class QuizCreationPage
    {
        public int QuestionID { get; set; }
        public int SelectedAnswer { get; set; }
        public int SelectedTime { get; set; }
        public int AnswerNumber
        {
            get
            {
                int answerCount = 0;
                if (Answer1 != null) answerCount += 1;
                if (Answer2 != null) answerCount += 1;
                if (Answer3 != null) answerCount += 1;
                if (Answer4 != null) answerCount += 1;
                return answerCount;
            }
        }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public int IDAnswer1 { get; set; }
        public string Answer2 { get; set; }
        public int IDAnswer2 { get; set; }
        public string Answer3 { get; set; }
        public int IDAnswer3 { get; set; }
        public string Answer4 { get; set; }
        public int IDAnswer4 { get; set; }

        public bool Empty
        {
            get
            {
                bool questionID = QuestionID == 0;
                bool selectedanswer = SelectedAnswer == 0;
                bool selectedtime = SelectedTime == 0;
                bool answernumber = AnswerNumber == 0;
                return questionID && selectedanswer && selectedtime && answernumber;
            }
        }
    }
}