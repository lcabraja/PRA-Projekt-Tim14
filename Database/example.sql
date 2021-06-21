USE Quizkey
--------------------------------------------------------examples--------------------------------------------------------
--Author
DECLARE @IDAuthor int
EXEC proc_create_Author "lcabraja", "12345678", "luka@cabraja.eu"
SET @IDAuthor = @@IDENTITY
SELECT * FROM Author WHERE IDAuthor = @IDAuthor
--Quiz
DECLARE @IDQuiz int
EXEC proc_create_Quiz @IDAuthor, "Have you been outside?"
SET @IDQuiz = @@IDENTITY
SELECT * FROM Quiz WHERE IDQuiz = @IDQuiz
--QuizQuestion
DECLARE @IDQuizQuestion int
EXEC proc_create_QuizQuestion 1, 2, "Is the sun blue?", 2, 30
SET @IDQuizQuestion = @@IDENTITY
SELECT * FROM QuizQuestion WHERE IDQuizQuestion = @IDQuizQuestion
--QuizAnswer
DECLARE @IDQuizAnswer1 int
DECLARE @IDQuizAnswer2 int
EXEC proc_create_QuizAnswer @IDQuizQuestion, "No", "1"
SET @IDQuizAnswer1 = @@IDENTITY
EXEC proc_create_QuizAnswer @IDQuizQuestion, "Yes", "2"
SET @IDQuizAnswer2 = @@IDENTITY
SELECT * FROM QuizAnswer WHERE IDQuizAnswer = @IDQuizAnswer1 OR IDQuizAnswer = @IDQuizAnswer2
--QuizSession
DECLARE @IDQuizSession int
DECLARE @OccurredAt datetimeoffset
SELECT @OccurredAt = SYSDATETIMEOFFSET()
EXEC proc_create_QuizSession 1, @OccurredAt, "123456"
SET @IDQuizSession = @@IDENTITY
SELECT * FROM QuizSession WHERE IDQuizSession = @IDQuizSession
--Attendee
DECLARE @IDAttendee int
EXEC proc_create_Attendee "dino",2 --@IDQuizSession
SET @IDAttendee = @@IDENTITY
SELECT * FROM Attendee WHERE IDAttendee = @IDAttendee
--LogItem
DECLARE @IDLogItem int
EXEC proc_create_LogItem @IDQuizSession, @IDQuizQuestion, @IDQuizAnswer1, @IDAttendee, 1000
SET @IDLogItem = @@IDENTITY
SELECT * FROM LogItem WHERE IDLogItem = @IDLogItem
--RecentQuiz
DECLARE @IDRecentQuiz int
DECLARE @LastEvent datetimeoffset
SELECT @LastEvent = SYSDATETIMEOFFSET()
EXEC proc_create_RecentQuiz @IDQuiz, @LastEvent
SET @IDRecentQuiz = @@IDENTITY
SELECT * FROM RecentQuiz WHERE IDRecentQuiz = @IDRecentQuiz