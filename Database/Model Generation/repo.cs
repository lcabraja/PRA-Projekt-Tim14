//---------------------------------------------------------Author---------------------------------------------------------

public static int CreateAuthor(Author author) =>
    (int)SqlHelper.ExecuteScalar(cs, "proc_create_Author", author.Username, author.PasswordHash, author.Email);

public static Author GetAuthor(int None)
{
    List<Author> collection = new List<Author>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_Author", None);
    return GetAuthorFromDataRow(ds.Tables[0].Rows[0]);
}

public static List<Author> GetMultipleAuthor()
{
    List<Author> collection = new List<Author>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_Author");
    foreach (DataRow row in ds.Tables[0].Rows)
    {
        collection.Add(GetAuthorFromDataRow(row));
    }
    return collection;
}

public static void UpdateAuthor(Author author)
{
    SqlHelper.ExecuteDataset(cs, "proc_update_Author", author.IDAuthor, author.Username, author.PasswordHash, author.Email);
}

public static void DeleteAuthor(int None)
{
    SqlHelper.ExecuteDataset(cs, "proc_delete_Author", None);
}

//----------------------------------------------------------Quiz----------------------------------------------------------

public static int CreateQuiz(Quiz quiz) =>
    (int)SqlHelper.ExecuteScalar(cs, "proc_create_Quiz", quiz.AuthorID, quiz.QuizName);

public static Quiz GetQuiz(int None)
{
    List<Quiz> collection = new List<Quiz>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_Quiz", None);
    return GetQuizFromDataRow(ds.Tables[0].Rows[0]);
}

public static List<Quiz> GetMultipleQuiz()
{
    List<Quiz> collection = new List<Quiz>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_Quiz");
    foreach (DataRow row in ds.Tables[0].Rows)
    {
        collection.Add(GetQuizFromDataRow(row));
    }
    return collection;
}

public static void UpdateQuiz(Quiz quiz)
{
    SqlHelper.ExecuteDataset(cs, "proc_update_Quiz", quiz.IDQuiz, quiz.AuthorID, quiz.QuizName);
}

public static void DeleteQuiz(int None)
{
    SqlHelper.ExecuteDataset(cs, "proc_delete_Quiz", None);
}

//------------------------------------------------------QuizQuestion------------------------------------------------------

public static int CreateQuizQuestion(QuizQuestion quizquestion) =>
    (int)SqlHelper.ExecuteScalar(cs, "proc_create_QuizQuestion", quizquestion.QuizID, quizquestion.QuestionNumber, quizquestion.QuestionText, quizquestion.CorrectAnswer, quizquestion.AnswerTimeSeconds);

public static QuizQuestion GetQuizQuestion(int None)
{
    List<QuizQuestion> collection = new List<QuizQuestion>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_QuizQuestion", None);
    return GetQuizQuestionFromDataRow(ds.Tables[0].Rows[0]);
}

public static List<QuizQuestion> GetMultipleQuizQuestion()
{
    List<QuizQuestion> collection = new List<QuizQuestion>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_QuizQuestion");
    foreach (DataRow row in ds.Tables[0].Rows)
    {
        collection.Add(GetQuizQuestionFromDataRow(row));
    }
    return collection;
}

public static void UpdateQuizQuestion(QuizQuestion quizquestion)
{
    SqlHelper.ExecuteDataset(cs, "proc_update_QuizQuestion", quizquestion.IDQuizQuestion, quizquestion.QuizID, quizquestion.QuestionNumber, quizquestion.QuestionText, quizquestion.CorrectAnswer, quizquestion.AnswerTimeSeconds);
}

public static void DeleteQuizQuestion(int None)
{
    SqlHelper.ExecuteDataset(cs, "proc_delete_QuizQuestion", None);
}

//-------------------------------------------------------QuizAnswer-------------------------------------------------------

public static int CreateQuizAnswer(QuizAnswer quizanswer) =>
    (int)SqlHelper.ExecuteScalar(cs, "proc_create_QuizAnswer", quizanswer.QuizQuestionID, quizanswer.AnswerText, quizanswer.QuestionOrder);

public static QuizAnswer GetQuizAnswer(int None)
{
    List<QuizAnswer> collection = new List<QuizAnswer>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_QuizAnswer", None);
    return GetQuizAnswerFromDataRow(ds.Tables[0].Rows[0]);
}

public static List<QuizAnswer> GetMultipleQuizAnswer()
{
    List<QuizAnswer> collection = new List<QuizAnswer>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_QuizAnswer");
    foreach (DataRow row in ds.Tables[0].Rows)
    {
        collection.Add(GetQuizAnswerFromDataRow(row));
    }
    return collection;
}

public static void UpdateQuizAnswer(QuizAnswer quizanswer)
{
    SqlHelper.ExecuteDataset(cs, "proc_update_QuizAnswer", quizanswer.IDQuizAnswer, quizanswer.QuizQuestionID, quizanswer.AnswerText, quizanswer.QuestionOrder);
}

public static void DeleteQuizAnswer(int None)
{
    SqlHelper.ExecuteDataset(cs, "proc_delete_QuizAnswer", None);
}

//------------------------------------------------------QuizSession-------------------------------------------------------

public static int CreateQuizSession(QuizSession quizsession) =>
    (int)SqlHelper.ExecuteScalar(cs, "proc_create_QuizSession", quizsession.QuizID, quizsession.OccurredAt, quizsession.SessionCode);

public static QuizSession GetQuizSession(int None)
{
    List<QuizSession> collection = new List<QuizSession>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_QuizSession", None);
    return GetQuizSessionFromDataRow(ds.Tables[0].Rows[0]);
}

public static List<QuizSession> GetMultipleQuizSession()
{
    List<QuizSession> collection = new List<QuizSession>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_QuizSession");
    foreach (DataRow row in ds.Tables[0].Rows)
    {
        collection.Add(GetQuizSessionFromDataRow(row));
    }
    return collection;
}

public static void UpdateQuizSession(QuizSession quizsession)
{
    SqlHelper.ExecuteDataset(cs, "proc_update_QuizSession", quizsession.IDQuizSession, quizsession.QuizID, quizsession.OccurredAt, quizsession.SessionCode);
}

public static void DeleteQuizSession(int None)
{
    SqlHelper.ExecuteDataset(cs, "proc_delete_QuizSession", None);
}

//--------------------------------------------------------Attendee--------------------------------------------------------

public static int CreateAttendee(Attendee attendee) =>
    (int)SqlHelper.ExecuteScalar(cs, "proc_create_Attendee", attendee.Username, attendee.SessionID);

public static Attendee GetAttendee(int None)
{
    List<Attendee> collection = new List<Attendee>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_Attendee", None);
    return GetAttendeeFromDataRow(ds.Tables[0].Rows[0]);
}

public static List<Attendee> GetMultipleAttendee()
{
    List<Attendee> collection = new List<Attendee>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_Attendee");
    foreach (DataRow row in ds.Tables[0].Rows)
    {
        collection.Add(GetAttendeeFromDataRow(row));
    }
    return collection;
}

public static void UpdateAttendee(Attendee attendee)
{
    SqlHelper.ExecuteDataset(cs, "proc_update_Attendee", attendee.IDAttendee, attendee.Username, attendee.SessionID);
}

public static void DeleteAttendee(int None)
{
    SqlHelper.ExecuteDataset(cs, "proc_delete_Attendee", None);
}

//--------------------------------------------------------LogItem---------------------------------------------------------

public static int CreateLogItem(LogItem logitem) =>
    (int)SqlHelper.ExecuteScalar(cs, "proc_create_LogItem", logitem.QuizSessionID, logitem.QuizQuestionID, logitem.QuizAnswerID, logitem.AttendeeID, logitem.Points);

public static LogItem GetLogItem(int None)
{
    List<LogItem> collection = new List<LogItem>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_LogItem", None);
    return GetLogItemFromDataRow(ds.Tables[0].Rows[0]);
}

public static List<LogItem> GetMultipleLogItem()
{
    List<LogItem> collection = new List<LogItem>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_LogItem");
    foreach (DataRow row in ds.Tables[0].Rows)
    {
        collection.Add(GetLogItemFromDataRow(row));
    }
    return collection;
}

public static void UpdateLogItem(LogItem logitem)
{
    SqlHelper.ExecuteDataset(cs, "proc_update_LogItem", logitem.IDLogItem, logitem.QuizSessionID, logitem.QuizQuestionID, logitem.QuizAnswerID, logitem.AttendeeID, logitem.Points);
}

public static void DeleteLogItem(int None)
{
    SqlHelper.ExecuteDataset(cs, "proc_delete_LogItem", None);
}

//-------------------------------------------------------RecentQuiz-------------------------------------------------------

public static int CreateRecentQuiz(RecentQuiz recentquiz) =>
    (int)SqlHelper.ExecuteScalar(cs, "proc_create_RecentQuiz", recentquiz.QuizID, recentquiz.LastEvent);

public static RecentQuiz GetRecentQuiz(int None)
{
    List<RecentQuiz> collection = new List<RecentQuiz>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_RecentQuiz", None);
    return GetRecentQuizFromDataRow(ds.Tables[0].Rows[0]);
}

public static List<RecentQuiz> GetMultipleRecentQuiz()
{
    List<RecentQuiz> collection = new List<RecentQuiz>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_RecentQuiz");
    foreach (DataRow row in ds.Tables[0].Rows)
    {
        collection.Add(GetRecentQuizFromDataRow(row));
    }
    return collection;
}

public static void UpdateRecentQuiz(RecentQuiz recentquiz)
{
    SqlHelper.ExecuteDataset(cs, "proc_update_RecentQuiz", recentquiz.IDRecentQuiz, recentquiz.QuizID, recentquiz.LastEvent);
}

public static void DeleteRecentQuiz(int None)
{
    SqlHelper.ExecuteDataset(cs, "proc_delete_RecentQuiz", None);
}

