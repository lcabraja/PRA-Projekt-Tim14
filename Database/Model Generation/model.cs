//---------------------------------------------------------Author---------------------------------------------------------
public class Author
{
    public int IDAuthor { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
}

//----------------------------------------------------------Quiz----------------------------------------------------------
public class Quiz
{
    public int IDQuiz { get; set; }
        public int AuthorID { get; set; }
        public string QuizName { get; set; }
}

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

//-------------------------------------------------------QuizAnswer-------------------------------------------------------
public class QuizAnswer
{
    public int IDQuizAnswer { get; set; }
        public int QuizQuestionID { get; set; }
        public string AnswerText { get; set; }
        public string QuestionOrder { get; set; }
}

//------------------------------------------------------QuizSession-------------------------------------------------------
public class QuizSession
{
    public int IDQuizSession { get; set; }
        public int QuizID { get; set; }
        public DateTime OccurredAt { get; set; }
        public string SessionCode { get; set; }
}

//--------------------------------------------------------Attendee--------------------------------------------------------
public class Attendee
{
    public int IDAttendee { get; set; }
        public string Username { get; set; }
        public int SessionID { get; set; }
}

//--------------------------------------------------------LogItem---------------------------------------------------------
public class LogItem
{
    public int IDLogItem { get; set; }
        public int QuizSessionID { get; set; }
        public int QuizQuestionID { get; set; }
        public int QuizAnswerID { get; set; }
        public int AttendeeID { get; set; }
        public int Points { get; set; }
}

//-------------------------------------------------------RecentQuiz-------------------------------------------------------
public class RecentQuiz
{
    public int IDRecentQuiz { get; set; }
        public int QuizID { get; set; }
        public DateTime LastEvent { get; set; }
}

