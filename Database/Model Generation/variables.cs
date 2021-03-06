//---------------------------------------------------------Author---------------------------------------------------------
private static Author GetAuthorFromDataRow(DataRow row)
{
    return new Author
    {
        IDAuthor = (int)row["IDAuthor"],
        Username = row["Username"].ToString(),
        PasswordHash = row["PasswordHash"].ToString(),
        Email = row["Email"].ToString()
    };
}
//---------------------------------------------------------Quiz = row["Quiz"].ToString(),
private static Quiz GetQuizFromDataRow(DataRow row)
{
    return new Quiz
    {
        IDQuiz = (int)row["IDQuiz"],
        QuizName = row["QuizName"].ToString()
    };
}
//---------------------------------------------------------QuizQuestion = row["QuizQuestion"].ToString(),
private static QuizQuestion GetQuizQuestionFromDataRow(DataRow row)
{
    return new QuizQuestion
    {
        IDQuizQuestion = (int)row["IDQuizQuestion"],
        QuestionNumber = row["QuestionNumber"].ToString(),
        QuestionText = row["QuestionText"].ToString(),
        CorrectAnswer = row["CorrectAnswer"].ToString(),
        AnswerTimeSeconds = row["AnswerTimeSeconds"].ToString()
    };
}
//---------------------------------------------------------QuizAnswer = row["QuizAnswer"].ToString(),
private static QuizAnswer GetQuizAnswerFromDataRow(DataRow row)
{
    return new QuizAnswer
    {
        IDQuizAnswer = (int)row["IDQuizAnswer"],
        AnswerText = row["AnswerText"].ToString(),
        QuestionOrder = row["QuestionOrder"].ToString()
    };
}
//---------------------------------------------------------QuizSession = row["QuizSession"].ToString(),
private static QuizSession GetQuizSessionFromDataRow(DataRow row)
{
    return new QuizSession
    {
        IDQuizSession = (int)row["IDQuizSession"],
        OccurredAt = row["OccurredAt"].ToString(),
        SessionCode = row["SessionCode"].ToString()
    };
}
//---------------------------------------------------------Attendee = row["Attendee"].ToString(),
private static Attendee GetAttendeeFromDataRow(DataRow row)
{
    return new Attendee
    {
        IDAttendee = (int)row["IDAttendee"],
        Username = row["Username"].ToString(),
    };
}
//---------------------------------------------------------LogItem = row["LogItem"].ToString(),
private static LogItem GetLogItemFromDataRow(DataRow row)
{
    return new LogItem
    {
        IDLogItem = (int)row["IDLogItem"],
        Points = row["Points"].ToString()
    };
}
//---------------------------------------------------------RecentQuiz = row["RecentQuiz"].ToString(),
private static RecentQuiz GetRecentQuizFromDataRow(DataRow row)
{
    return new RecentQuiz
    {
        IDRecentQuiz = (int)row["IDRecentQuiz"],
        LastEvent = row["LastEvent"].ToString()
    };
}