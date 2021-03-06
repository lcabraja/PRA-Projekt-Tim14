USE Quizkey
GO
---------------------------------------------------proc_create_Author---------------------------------------------------
IF OBJECT_ID('proc_create_Author') IS NOT NULL
BEGIN 
    DROP PROCEDURE proc_create_Author 
END
GO
CREATE PROCEDURE proc_create_Author
    @Username varchar(64),
    @PasswordHash varchar(128),
    @Email varchar(128)
AS
BEGIN
INSERT INTO Author
    VALUES (@Username, @PasswordHash, @Email)
 
SELECT SCOPE_IDENTITY() AS IDkupac
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

-----------------------------------------------proc_delete_Author_Complete----------------------------------------------
IF OBJECT_ID('PROC_DELETE_AUTHOR_COMPLETE') IS NOT NULL
BEGIN
    DROP PROCEDURE PROC_DELETE_AUTHOR_COMPLETE
END
GO
CREATE PROCEDURE PROC_DELETE_AUTHOR_COMPLETE
    @IDAUTHOR INT
AS 
BEGIN 
    DELETE FROM LogItem WHERE QuizSessionID IN (SELECT IDQuizSession FROM QuizSession WHERE QuizID IN (SELECT IDQuiz FROM QUIZ WHERE AuthorID = @IDAuthor))
    DELETE FROM Attendee WHERE SessionID IN (SELECT IDQuizSession FROM QuizSession WHERE QuizID IN (SELECT IDQuiz FROM QUIZ WHERE AuthorID = @IDAuthor))
    DELETE FROM QuizSession WHERE QuizID IN (SELECT IDQuiz FROM QUIZ WHERE AuthorID = @IDAuthor)
    DELETE FROM RecentQuiz WHERE QuizID IN (SELECT IDQuiz FROM QUIZ WHERE AuthorID = @IDAuthor)
    DELETE FROM QuizAnswer WHERE QuizQuestionID IN (SELECT IDQuizQuestion FROM QuizQuestion WHERE QuizID IN (SELECT IDQuiz FROM QUIZ WHERE AuthorID = @IDAuthor))
    DELETE FROM QuizQuestion WHERE QuizID IN (SELECT IDQuiz FROM QUIZ WHERE AuthorID = @IDAuthor) 
    DELETE FROM Quiz WHERE IDQuiz IN (SELECT IDQuiz FROM QUIZ WHERE AuthorID = @IDAuthor)
    DELETE FROM AUTHOR WHERE IDAuthor = @IDAuthor
END
GO

----------------------------------------------------proc_create_Quiz----------------------------------------------------
IF OBJECT_ID('proc_create_Quiz') IS NOT NULL
BEGIN 
    DROP PROCEDURE proc_create_Quiz 
END
GO
CREATE PROCEDURE proc_create_Quiz
    @AuthorID int,
    @QuizName varchar(256)
AS
BEGIN
INSERT INTO Quiz
    VALUES (@AuthorID, @QuizName)
 
SELECT SCOPE_IDENTITY() AS IDQuiz
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

--------------------------------------------proc_select_multiple_Quiz_targeted---------------------------------------------
IF OBJECT_ID('proc_select_multiple_Quiz_targeted') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_Quiz_targeted
END
GO
CREATE PROCEDURE proc_select_multiple_Quiz_targeted
    @AuthorID int
AS
BEGIN
    SELECT * FROM Quiz WHERE AuthorID = @AuthorID
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

------------------------------------------------proc_delete_Quiz_complete-----------------------------------------------
IF OBJECT_ID('proc_delete_Quiz_complete') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_delete_Quiz_complete
END
GO
CREATE PROCEDURE proc_delete_Quiz_complete
    @IDQuiz int
AS 
BEGIN 
    DELETE FROM LogItem WHERE QuizSessionID IN (SELECT IDQuizSession FROM QuizSession WHERE QuizID = @IDQuiz)
    DELETE FROM Attendee WHERE SessionID IN (SELECT IDQuizSession FROM QuizSession WHERE QuizID = @IDQuiz)
    DELETE FROM QuizSession WHERE QuizID = @IDQuiz
    DELETE FROM QuizAnswer WHERE QuizQuestionID IN (SELECT IDQuizQuestion FROM QuizQuestion WHERE QuizID = @IDQuiz)
    DELETE FROM QuizQuestion WHERE QuizID = @IDQuiz
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
    @QuizID int,
    @QuestionNumber int,
    @QuestionText varchar(512),
    @CorrectAnswer smallint,
    @AnswerTimeSeconds int
AS
BEGIN
INSERT INTO QuizQuestion
    VALUES (@QuizID, @QuestionNumber, @QuestionText, @CorrectAnswer, @AnswerTimeSeconds)
 
SELECT SCOPE_IDENTITY() AS IDQuizQuestion
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

----------------------------------------proc_select_multiple_QuizQuestion_targeted--------------------------------------
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

----------------------------------------proc_select_multiple_QuizQuestion_targeted--------------------------------------
IF OBJECT_ID('proc_select_multiple_QuizQuestion_targeted') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_QuizQuestion_targeted
END
GO
CREATE PROCEDURE proc_select_multiple_QuizQuestion_targeted
    @QuizID int
AS
BEGIN
    SELECT * FROM QuizQuestion WHERE QuizID = @QuizID
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
    @QuizQuestionID int,
    @AnswerText varchar(512),
    @QuestionOrder smallint
AS
BEGIN
INSERT INTO QuizAnswer
    VALUES (@QuizQuestionID, @AnswerText, @QuestionOrder)
 
SELECT SCOPE_IDENTITY() AS IDQuizAnswer
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
    @QuizID int,
    @OccurredAt datetimeoffset,
    @SessionCode char(6)
AS
BEGIN
INSERT INTO QuizSession
    VALUES (@QuizID, @OccurredAt, @SessionCode)
 
SELECT SCOPE_IDENTITY() AS IDQuizSession
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

----------------------------------------proc_select_multiple_QuizSession_targeted----------------------------------------
IF OBJECT_ID('proc_select_multiple_QuizSession_targeted') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_QuizSession_targeted
END
GO
CREATE PROCEDURE proc_select_multiple_QuizSession_targeted
    @AuthorID int
AS
BEGIN
    SELECT * FROM QuizSession WHERE QuizID IN (SELECT IDQuiz FROM Quiz WHERE AuthorID = @AuthorID)
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
    @Username varchar(64),
    @SessionID int
AS
BEGIN
INSERT INTO Attendee
    VALUES (@Username, @SessionID)
 
SELECT SCOPE_IDENTITY() AS IDAttendee
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
    @QuizSessionID int,
    @QuizQuestionID int,
    @QuizAnswerID int,
    @AttendeeID int,
    @Points int
AS
BEGIN
INSERT INTO LogItem
    VALUES (@QuizSessionID, @QuizQuestionID, @QuizAnswerID, @AttendeeID, @Points)
 
SELECT SCOPE_IDENTITY() AS IDLogItem
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

----------------------------------------------proc_select_multiple_LogItem----------------------------------------------
IF OBJECT_ID('proc_select_multiple_LogItem_targeted') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_LogItem_targeted
END
GO
CREATE PROCEDURE proc_select_multiple_LogItem_targeted
    @AuthorID int
AS
BEGIN
    SELECT * FROM LogItem WHERE QuizSessionID IN 
        (
            SELECT IDQuizSession FROM QuizSession WHERE QuizID IN
                (
                    SELECT IDQuiz FROM Quiz WHERE AuthorID = @AuthorID
                )
        )
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
    @QuizID int,
    @LastEvent datetimeoffset
AS
BEGIN
INSERT INTO RecentQuiz
    VALUES (@QuizID, @LastEvent)
 
SELECT SCOPE_IDENTITY() AS IDRecentQuiz
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

