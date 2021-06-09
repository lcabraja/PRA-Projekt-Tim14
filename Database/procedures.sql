USE Quizkey
GO
---------------------------------------------------proc_create_Author---------------------------------------------------
IF OBJECT_ID('proc_create_Author') IS NOT NULL
BEGIN 
    DROP PROCEDURE proc_create_Author 
END
GO
CREATE PROCEDURE proc_create_Author
    @IDAuthor int OUTPUT,
    @Username varchar(64),
    @PasswordHash varchar(128),
    @Email varchar(128)
AS
BEGIN
INSERT INTO Author
    VALUES (@Username, @PasswordHash, @Email)
 
SET @IDAuthor = SCOPE_IDENTITY()
END
GO
---------------------------------------------------proc_select_Author---------------------------------------------------
IF OBJECT_ID('proc_select_Author') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_Author
END
GO
CREATE PROCEDURE proc_select_Author
    @IDAuthor int
AS
BEGIN
    SELECT * FROM Author WHERE IDAuthor = @IDAuthor
END
GO

----------------------------------------------proc_select_multiple_Author-----------------------------------------------
IF OBJECT_ID('proc_select_multiple_Author') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_Author
END
GO
CREATE PROCEDURE proc_select_multiple_Author
AS
BEGIN
    SELECT * FROM Author
END
GO

---------------------------------------------------proc_update_Author---------------------------------------------------
IF OBJECT_ID('proc_update_Author') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_update_Author
END
GO
CREATE PROCEDURE proc_update_Author
    @IDAuthor int,
    @Username varchar(64),
    @PasswordHash varchar(128),
    @Email varchar(128)
AS
BEGIN
    UPDATE Author SET Username = @Username, PasswordHash = @PasswordHash, Email = @Email WHERE IDAuthor = @IDAuthor 
END
GO

---------------------------------------------------proc_delete_Author---------------------------------------------------
IF OBJECT_ID('proc_delete_Author') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_delete_Author
END
GO
CREATE PROCEDURE proc_delete_Author
    @IDAuthor int
AS 
BEGIN 
    DELETE FROM Author WHERE IDAuthor = @IDAuthor
END
GO

----------------------------------------------------proc_create_Quiz----------------------------------------------------
IF OBJECT_ID('proc_create_Quiz') IS NOT NULL
BEGIN 
    DROP PROCEDURE proc_create_Quiz 
END
GO
CREATE PROCEDURE proc_create_Quiz
    @IDQuiz int OUTPUT,
    @AuthorID int,
    @QuizName varchar(256)
AS
BEGIN
INSERT INTO Quiz
    VALUES (@AuthorID, @QuizName)
 
SET @IDQuiz = SCOPE_IDENTITY()
END
GO
----------------------------------------------------proc_select_Quiz----------------------------------------------------
IF OBJECT_ID('proc_select_Quiz') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_Quiz
END
GO
CREATE PROCEDURE proc_select_Quiz
    @IDQuiz int
AS
BEGIN
    SELECT * FROM Quiz WHERE IDQuiz = @IDQuiz
END
GO

------------------------------------------------proc_select_multiple_Quiz-------------------------------------------------
IF OBJECT_ID('proc_select_multiple_Quiz') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_Quiz
END
GO
CREATE PROCEDURE proc_select_multiple_Quiz
AS
BEGIN
    SELECT * FROM Quiz
END
GO

----------------------------------------------------proc_update_Quiz----------------------------------------------------
IF OBJECT_ID('proc_update_Quiz') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_update_Quiz
END
GO
CREATE PROCEDURE proc_update_Quiz
    @IDQuiz int,
    @AuthorID int,
    @QuizName varchar(256)
AS
BEGIN
    UPDATE Quiz SET AuthorID = @AuthorID, QuizName = @QuizName WHERE IDQuiz = @IDQuiz 
END
GO

----------------------------------------------------proc_delete_Quiz----------------------------------------------------
IF OBJECT_ID('proc_delete_Quiz') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_delete_Quiz
END
GO
CREATE PROCEDURE proc_delete_Quiz
    @IDQuiz int
AS 
BEGIN 
    DELETE FROM Quiz WHERE IDQuiz = @IDQuiz
END
GO

------------------------------------------------proc_create_QuizQuestion------------------------------------------------
IF OBJECT_ID('proc_create_QuizQuestion') IS NOT NULL
BEGIN 
    DROP PROCEDURE proc_create_QuizQuestion 
END
GO
CREATE PROCEDURE proc_create_QuizQuestion
    @IDQuizQuestion int OUTPUT,
    @QuizID int,
    @QuestionNumber int,
    @QuestionText varchar(512),
    @CorrectAnswer smallint,
    @AnswerTimeSeconds int
AS
BEGIN
INSERT INTO QuizQuestion
    VALUES (@QuizID, @QuestionNumber, @QuestionText, @CorrectAnswer, @AnswerTimeSeconds)
 
SET @IDQuizQuestion = SCOPE_IDENTITY()
END
GO
------------------------------------------------proc_select_QuizQuestion------------------------------------------------
IF OBJECT_ID('proc_select_QuizQuestion') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_QuizQuestion
END
GO
CREATE PROCEDURE proc_select_QuizQuestion
    @IDQuizQuestion int
AS
BEGIN
    SELECT * FROM QuizQuestion WHERE IDQuizQuestion = @IDQuizQuestion
END
GO

--------------------------------------------proc_select_multiple_QuizQuestion---------------------------------------------
IF OBJECT_ID('proc_select_multiple_QuizQuestion') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_QuizQuestion
END
GO
CREATE PROCEDURE proc_select_multiple_QuizQuestion
AS
BEGIN
    SELECT * FROM QuizQuestion
END
GO

------------------------------------------------proc_update_QuizQuestion------------------------------------------------
IF OBJECT_ID('proc_update_QuizQuestion') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_update_QuizQuestion
END
GO
CREATE PROCEDURE proc_update_QuizQuestion
    @IDQuizQuestion int,
    @QuizID int,
    @QuestionNumber int,
    @QuestionText varchar(512),
    @CorrectAnswer smallint,
    @AnswerTimeSeconds int
AS
BEGIN
    UPDATE QuizQuestion SET QuizID = @QuizID, QuestionNumber = @QuestionNumber, QuestionText = @QuestionText, CorrectAnswer = @CorrectAnswer, AnswerTimeSeconds = @AnswerTimeSeconds WHERE IDQuizQuestion = @IDQuizQuestion 
END
GO

------------------------------------------------proc_delete_QuizQuestion------------------------------------------------
IF OBJECT_ID('proc_delete_QuizQuestion') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_delete_QuizQuestion
END
GO
CREATE PROCEDURE proc_delete_QuizQuestion
    @IDQuizQuestion int
AS 
BEGIN 
    DELETE FROM QuizQuestion WHERE IDQuizQuestion = @IDQuizQuestion
END
GO

-------------------------------------------------proc_create_QuizAnswer-------------------------------------------------
IF OBJECT_ID('proc_create_QuizAnswer') IS NOT NULL
BEGIN 
    DROP PROCEDURE proc_create_QuizAnswer 
END
GO
CREATE PROCEDURE proc_create_QuizAnswer
    @IDQuizAnswer int OUTPUT,
    @QuizQuestionID int,
    @AnswerText varchar(512),
    @QuestionOrder smallint
AS
BEGIN
INSERT INTO QuizAnswer
    VALUES (@QuizQuestionID, @AnswerText, @QuestionOrder)
 
SET @IDQuizAnswer = SCOPE_IDENTITY()
END
GO
-------------------------------------------------proc_select_QuizAnswer-------------------------------------------------
IF OBJECT_ID('proc_select_QuizAnswer') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_QuizAnswer
END
GO
CREATE PROCEDURE proc_select_QuizAnswer
    @IDQuizAnswer int
AS
BEGIN
    SELECT * FROM QuizAnswer WHERE IDQuizAnswer = @IDQuizAnswer
END
GO

--------------------------------------------proc_select_multiple_QuizAnswer---------------------------------------------
IF OBJECT_ID('proc_select_multiple_QuizAnswer') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_QuizAnswer
END
GO
CREATE PROCEDURE proc_select_multiple_QuizAnswer
AS
BEGIN
    SELECT * FROM QuizAnswer
END
GO

-------------------------------------------------proc_update_QuizAnswer-------------------------------------------------
IF OBJECT_ID('proc_update_QuizAnswer') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_update_QuizAnswer
END
GO
CREATE PROCEDURE proc_update_QuizAnswer
    @IDQuizAnswer int,
    @QuizQuestionID int,
    @AnswerText varchar(512),
    @QuestionOrder smallint
AS
BEGIN
    UPDATE QuizAnswer SET QuizQuestionID = @QuizQuestionID, AnswerText = @AnswerText, QuestionOrder = @QuestionOrder WHERE IDQuizAnswer = @IDQuizAnswer 
END
GO

-------------------------------------------------proc_delete_QuizAnswer-------------------------------------------------
IF OBJECT_ID('proc_delete_QuizAnswer') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_delete_QuizAnswer
END
GO
CREATE PROCEDURE proc_delete_QuizAnswer
    @IDQuizAnswer int
AS 
BEGIN 
    DELETE FROM QuizAnswer WHERE IDQuizAnswer = @IDQuizAnswer
END
GO

------------------------------------------------proc_create_QuizSession-------------------------------------------------
IF OBJECT_ID('proc_create_QuizSession') IS NOT NULL
BEGIN 
    DROP PROCEDURE proc_create_QuizSession 
END
GO
CREATE PROCEDURE proc_create_QuizSession
    @IDQuizSession int OUTPUT,
    @QuizID int,
    @OccurredAt datetimeoffset,
    @SessionCode char(6)
AS
BEGIN
INSERT INTO QuizSession
    VALUES (@QuizID, @OccurredAt, @SessionCode)
 
SET @IDQuizSession = SCOPE_IDENTITY()
END
GO
------------------------------------------------proc_select_QuizSession-------------------------------------------------
IF OBJECT_ID('proc_select_QuizSession') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_QuizSession
END
GO
CREATE PROCEDURE proc_select_QuizSession
    @IDQuizSession int
AS
BEGIN
    SELECT * FROM QuizSession WHERE IDQuizSession = @IDQuizSession
END
GO

--------------------------------------------proc_select_multiple_QuizSession--------------------------------------------
IF OBJECT_ID('proc_select_multiple_QuizSession') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_QuizSession
END
GO
CREATE PROCEDURE proc_select_multiple_QuizSession
AS
BEGIN
    SELECT * FROM QuizSession
END
GO

------------------------------------------------proc_update_QuizSession-------------------------------------------------
IF OBJECT_ID('proc_update_QuizSession') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_update_QuizSession
END
GO
CREATE PROCEDURE proc_update_QuizSession
    @IDQuizSession int,
    @QuizID int,
    @OccurredAt datetimeoffset,
    @SessionCode char(6)
AS
BEGIN
    UPDATE QuizSession SET QuizID = @QuizID, OccurredAt = @OccurredAt, SessionCode = @SessionCode WHERE IDQuizSession = @IDQuizSession 
END
GO

------------------------------------------------proc_delete_QuizSession-------------------------------------------------
IF OBJECT_ID('proc_delete_QuizSession') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_delete_QuizSession
END
GO
CREATE PROCEDURE proc_delete_QuizSession
    @IDQuizSession int
AS 
BEGIN 
    DELETE FROM QuizSession WHERE IDQuizSession = @IDQuizSession
END
GO

--------------------------------------------------proc_create_Attendee--------------------------------------------------
IF OBJECT_ID('proc_create_Attendee') IS NOT NULL
BEGIN 
    DROP PROCEDURE proc_create_Attendee 
END
GO
CREATE PROCEDURE proc_create_Attendee
    @IDAttendee int OUTPUT,
    @Username varchar(64),
    @SessionID int
AS
BEGIN
INSERT INTO Attendee
    VALUES (@Username, @SessionID)
 
SET @IDAttendee = SCOPE_IDENTITY()
END
GO
--------------------------------------------------proc_select_Attendee--------------------------------------------------
IF OBJECT_ID('proc_select_Attendee') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_Attendee
END
GO
CREATE PROCEDURE proc_select_Attendee
    @IDAttendee int
AS
BEGIN
    SELECT * FROM Attendee WHERE IDAttendee = @IDAttendee
END
GO

----------------------------------------------proc_select_multiple_Attendee-----------------------------------------------
IF OBJECT_ID('proc_select_multiple_Attendee') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_Attendee
END
GO
CREATE PROCEDURE proc_select_multiple_Attendee
AS
BEGIN
    SELECT * FROM Attendee
END
GO

--------------------------------------------------proc_update_Attendee--------------------------------------------------
IF OBJECT_ID('proc_update_Attendee') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_update_Attendee
END
GO
CREATE PROCEDURE proc_update_Attendee
    @IDAttendee int,
    @Username varchar(64),
    @SessionID int
AS
BEGIN
    UPDATE Attendee SET Username = @Username, SessionID = @SessionID WHERE IDAttendee = @IDAttendee 
END
GO

--------------------------------------------------proc_delete_Attendee--------------------------------------------------
IF OBJECT_ID('proc_delete_Attendee') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_delete_Attendee
END
GO
CREATE PROCEDURE proc_delete_Attendee
    @IDAttendee int
AS 
BEGIN 
    DELETE FROM Attendee WHERE IDAttendee = @IDAttendee
END
GO

--------------------------------------------------proc_create_LogItem---------------------------------------------------
IF OBJECT_ID('proc_create_LogItem') IS NOT NULL
BEGIN 
    DROP PROCEDURE proc_create_LogItem 
END
GO
CREATE PROCEDURE proc_create_LogItem
    @IDLogItem int OUTPUT,
    @QuizSessionID int,
    @QuizQuestionID int,
    @QuizAnswerID int,
    @AttendeeID int,
    @Points int
AS
BEGIN
INSERT INTO LogItem
    VALUES (@QuizSessionID, @QuizQuestionID, @QuizAnswerID, @AttendeeID, @Points)
 
SET @IDLogItem = SCOPE_IDENTITY()
END
GO
--------------------------------------------------proc_select_LogItem---------------------------------------------------
IF OBJECT_ID('proc_select_LogItem') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_LogItem
END
GO
CREATE PROCEDURE proc_select_LogItem
    @IDLogItem int
AS
BEGIN
    SELECT * FROM LogItem WHERE IDLogItem = @IDLogItem
END
GO

----------------------------------------------proc_select_multiple_LogItem----------------------------------------------
IF OBJECT_ID('proc_select_multiple_LogItem') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_LogItem
END
GO
CREATE PROCEDURE proc_select_multiple_LogItem
AS
BEGIN
    SELECT * FROM LogItem
END
GO

--------------------------------------------------proc_update_LogItem---------------------------------------------------
IF OBJECT_ID('proc_update_LogItem') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_update_LogItem
END
GO
CREATE PROCEDURE proc_update_LogItem
    @IDLogItem int,
    @QuizSessionID int,
    @QuizQuestionID int,
    @QuizAnswerID int,
    @AttendeeID int,
    @Points int
AS
BEGIN
    UPDATE LogItem SET QuizSessionID = @QuizSessionID, QuizQuestionID = @QuizQuestionID, QuizAnswerID = @QuizAnswerID, AttendeeID = @AttendeeID, Points = @Points WHERE IDLogItem = @IDLogItem 
END
GO

--------------------------------------------------proc_delete_LogItem---------------------------------------------------
IF OBJECT_ID('proc_delete_LogItem') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_delete_LogItem
END
GO
CREATE PROCEDURE proc_delete_LogItem
    @IDLogItem int
AS 
BEGIN 
    DELETE FROM LogItem WHERE IDLogItem = @IDLogItem
END
GO

-------------------------------------------------proc_create_RecentQuiz-------------------------------------------------
IF OBJECT_ID('proc_create_RecentQuiz') IS NOT NULL
BEGIN 
    DROP PROCEDURE proc_create_RecentQuiz 
END
GO
CREATE PROCEDURE proc_create_RecentQuiz
    @IDRecentQuiz int OUTPUT,
    @QuizID int,
    @LastEvent datetimeoffset
AS
BEGIN
INSERT INTO RecentQuiz
    VALUES (@QuizID, @LastEvent)
 
SET @IDRecentQuiz = SCOPE_IDENTITY()
END
GO
-------------------------------------------------proc_select_RecentQuiz-------------------------------------------------
IF OBJECT_ID('proc_select_RecentQuiz') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_RecentQuiz
END
GO
CREATE PROCEDURE proc_select_RecentQuiz
    @IDRecentQuiz int
AS
BEGIN
    SELECT * FROM RecentQuiz WHERE IDRecentQuiz = @IDRecentQuiz
END
GO

--------------------------------------------proc_select_multiple_RecentQuiz---------------------------------------------
IF OBJECT_ID('proc_select_multiple_RecentQuiz') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_RecentQuiz
END
GO
CREATE PROCEDURE proc_select_multiple_RecentQuiz
AS
BEGIN
    SELECT * FROM RecentQuiz
END
GO

-------------------------------------------------proc_update_RecentQuiz-------------------------------------------------
IF OBJECT_ID('proc_update_RecentQuiz') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_update_RecentQuiz
END
GO
CREATE PROCEDURE proc_update_RecentQuiz
    @IDRecentQuiz int,
    @QuizID int,
    @LastEvent datetimeoffset
AS
BEGIN
    UPDATE RecentQuiz SET QuizID = @QuizID, LastEvent = @LastEvent WHERE IDRecentQuiz = @IDRecentQuiz 
END
GO

-------------------------------------------------proc_delete_RecentQuiz-------------------------------------------------
IF OBJECT_ID('proc_delete_RecentQuiz') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_delete_RecentQuiz
END
GO
CREATE PROCEDURE proc_delete_RecentQuiz
    @IDRecentQuiz int
AS 
BEGIN 
    DELETE FROM RecentQuiz WHERE IDRecentQuiz = @IDRecentQuiz
END
GO

