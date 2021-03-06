//---------------------------------------------------------Author---------------------------------------------------------
if (authorCache.Contains(new Author { IDAuthor = IDAuthor }))
    return authorCache.Find(x => x.IDAuthor == IDAuthor);
//----------------------------------------------------------Quiz----------------------------------------------------------
if (quizCache.Contains(new Quiz { IDQuiz = IDQuiz }))
    return quizCache.Find(x => x.IDQuiz == IDQuiz);
//------------------------------------------------------QuizQuestion------------------------------------------------------
if (quizquestionCache.Contains(new QuizQuestion { IDQuizQuestion = IDQuizQuestion }))
    return quizquestionCache.Find(x => x.IDQuizQuestion == IDQuizQuestion);
//-------------------------------------------------------QuizAnswer-------------------------------------------------------
if (quizanswerCache.Contains(new QuizAnswer { IDQuizAnswer = IDQuizAnswer }))
    return quizanswerCache.Find(x => x.IDQuizAnswer == IDQuizAnswer);
//------------------------------------------------------QuizSession-------------------------------------------------------
if (quizsessionCache.Contains(new QuizSession { IDQuizSession = IDQuizSession }))
    return quizsessionCache.Find(x => x.IDQuizSession == IDQuizSession);
//--------------------------------------------------------Attendee--------------------------------------------------------
if (attendeeCache.Contains(new Attendee { IDAttendee = IDAttendee }))
    return attendeeCache.Find(x => x.IDAttendee == IDAttendee);
//--------------------------------------------------------LogItem---------------------------------------------------------
if (logitemCache.Contains(new LogItem { IDLogItem = IDLogItem }))
    return logitemCache.Find(x => x.IDLogItem == IDLogItem);
//-------------------------------------------------------RecentQuiz-------------------------------------------------------
if (recentquizCache.Contains(new RecentQuiz { IDRecentQuiz = IDRecentQuiz }))
    return recentquizCache.Find(x => x.IDRecentQuiz == IDRecentQuiz);
