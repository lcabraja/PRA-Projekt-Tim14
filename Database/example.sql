USE Quizkey
--------------------------------------------------------examples--------------------------------------------------------
--Author
DECLARE @IDAuthor int
EXEC proc_create_Author @IDAuthor OUT, "lcabraja", "12345678", "luka@cabraja.eu"
SELECT * FROM Author WHERE IDAuthor = @IDAuthor
--Quiz
DECLARE @IDQuiz int
EXEC proc_create_Quiz @IDQuiz OUT, @IDAuthor, "Have you been outside?"
SELECT * FROM Quiz WHERE IDQuiz = @IDQuiz
--QuizQuestion
DECLARE @IDQuizQuestion int
EXEC proc_create_QuizQuestion @IDQuizQuestion OUT, 1, 2, "Is the sun blue?", 2, 30
SELECT * FROM QuizQuestion WHERE IDQuizQuestion = @IDQuizQuestion
--QuizAnswer
DECLARE @IDQuizAnswer1 int
DECLARE @IDQuizAnswer2 int
EXEC proc_create_QuizAnswer @IDQuizAnswer1 OUT, @IDQuizQuestion, "No", "1"
EXEC proc_create_QuizAnswer @IDQuizAnswer2 OUT, @IDQuizQuestion, "Yes", "2"
SELECT * FROM QuizAnswer WHERE IDQuizAnswer = @IDQuizAnswer1 OR IDQuizAnswer = @IDQuizAnswer2
--QuizSession
DECLARE @IDQuizSession int
DECLARE @OccurredAt datetimeoffset
SELECT @OccurredAt = SYSDATETIMEOFFSET()
EXEC proc_create_QuizSession @IDQuizSession OUT, 1, @OccurredAt, "123456"
SELECT * FROM QuizSession WHERE IDQuizSession = @IDQuizSession
--Attendee
DECLARE @IDAttendee int
EXEC proc_create_Attendee @IDAttendee OUT, "dino",@IDQuizSession
SELECT * FROM Attendee WHERE IDAttendee = @IDAttendee
--LogItem
DECLARE @IDLogItem int
EXEC proc_create_LogItem @IDLogItem OUT, @IDQuizSession, @IDQuizQuestion, @IDQuizAnswer1, @IDAttendee, 1000
SELECT * FROM LogItem WHERE IDLogItem = @IDLogItem
--RecentQuiz
DECLARE @IDRecentQuiz int
DECLARE @LastEvent datetimeoffset
SELECT @LastEvent = SYSDATETIMEOFFSET()
EXEC proc_create_RecentQuiz @IDRecentQuiz OUT, @IDQuiz, @LastEvent
SELECT * FROM RecentQuiz WHERE IDRecentQuiz = @IDRecentQuiz