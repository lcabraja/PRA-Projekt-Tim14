//---------------------------------------------------------Author---------------------------------------------------------

public override string ToString() =>
		$"IDAuthor: {IDAuthor}, Username: {Username}, PasswordHash: {PasswordHash}, Email: {Email}";

//----------------------------------------------------------Quiz----------------------------------------------------------

public override string ToString() =>
		$"IDQuiz: {IDQuiz}, AuthorID: {AuthorID}, QuizName: {QuizName}";

//------------------------------------------------------QuizQuestion------------------------------------------------------

public override string ToString() =>
		$"IDQuizQuestion: {IDQuizQuestion}, QuizID: {QuizID}, QuestionNumber: {QuestionNumber}, QuestionText: {QuestionText}, CorrectAnswer: {CorrectAnswer}, AnswerTimeSeconds: {AnswerTimeSeconds}";

//-------------------------------------------------------QuizAnswer-------------------------------------------------------

public override string ToString() =>
		$"IDQuizAnswer: {IDQuizAnswer}, QuizQuestionID: {QuizQuestionID}, AnswerText: {AnswerText}, QuestionOrder: {QuestionOrder}";

//------------------------------------------------------QuizSession-------------------------------------------------------

public override string ToString() =>
		$"IDQuizSession: {IDQuizSession}, QuizID: {QuizID}, OccurredAt: {OccurredAt}, SessionCode: {SessionCode}";

//--------------------------------------------------------Attendee--------------------------------------------------------

public override string ToString() =>
		$"IDAttendee: {IDAttendee}, Username: {Username}, SessionID: {SessionID}";

//--------------------------------------------------------LogItem---------------------------------------------------------

public override string ToString() =>
		$"IDLogItem: {IDLogItem}, QuizSessionID: {QuizSessionID}, QuizQuestionID: {QuizQuestionID}, QuizAnswerID: {QuizAnswerID}, AttendeeID: {AttendeeID}, Points: {Points}";

//-------------------------------------------------------RecentQuiz-------------------------------------------------------

public override string ToString() =>
		$"IDRecentQuiz: {IDRecentQuiz}, QuizID: {QuizID}, LastEvent: {LastEvent}";

