--------------------------------------------------proc_create_Author--------------------------------------------------
IF OBJECT_ID('proc_create_Author') IS NOT NULL
BEGIN 
DROP PROC proc_create_Author 
END
GO
CREATE PROCEDURE proc_create_Author
	@IDAuthor int OUTPUT,
	@Username varchar(64),
	@PasswordHash varchar(128),
	@Email varchar(128)
AS
BEGIN
INSERT INTO Customer  (
    IDAuthor,
	Username,
	PasswordHash,
	Email)
    VALUES (
    @IDAuthor,
	@Username,
	@PasswordHash,
	@Email)
 
SET @IDAuthor = SCOPE_IDENTITY()
END
--------------------------------------------------proc_create_Quiz--------------------------------------------------
IF OBJECT_ID('proc_create_Quiz') IS NOT NULL
BEGIN 
DROP PROC proc_create_Quiz 
END
GO
CREATE PROCEDURE proc_create_Quiz
	@IDQuiz int OUTPUT,
	@QuizName varchar(256)
AS
BEGIN
INSERT INTO Customer  (
    IDQuiz,
	QuizName)
    VALUES (
    @IDQuiz,
	@QuizName)
 
SET @IDQuiz = SCOPE_IDENTITY()
END
--------------------------------------------------proc_create_QuizQuestion--------------------------------------------------
IF OBJECT_ID('proc_create_QuizQuestion') IS NOT NULL
BEGIN 
DROP PROC proc_create_QuizQuestion 
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
INSERT INTO Customer  (
    IDQuizQuestion,
	QuizID,
	QuestionNumber,
	QuestionText,
	CorrectAnswer,
	AnswerTimeSeconds)
    VALUES (
    @IDQuizQuestion,
	@QuizID,
	@QuestionNumber,
	@QuestionText,
	@CorrectAnswer,
	@AnswerTimeSeconds)
 
SET @IDQuizQuestion = SCOPE_IDENTITY()
END
--------------------------------------------------proc_create_QuizAnswer--------------------------------------------------
IF OBJECT_ID('proc_create_QuizAnswer') IS NOT NULL
BEGIN 
DROP PROC proc_create_QuizAnswer 
END
GO
CREATE PROCEDURE proc_create_QuizAnswer
	@IDQuizAnswer int OUTPUT,
	@QuizQuestionID int,
	@AnswerText varchar(512),,
	@QuestionOrder smallint
AS
BEGIN
INSERT INTO Customer  (
    IDQuizAnswer,
	QuizQuestionID,
	AnswerText,
	QuestionOrder)
    VALUES (
    @IDQuizAnswer,
	@QuizQuestionID,
	@AnswerText,
	@QuestionOrder)
 
SET @IDQuizAnswer = SCOPE_IDENTITY()
END
--------------------------------------------------proc_create_QuizSession--------------------------------------------------
IF OBJECT_ID('proc_create_QuizSession') IS NOT NULL
BEGIN 
DROP PROC proc_create_QuizSession 
END
GO
CREATE PROCEDURE proc_create_QuizSession
	@IDQuizSession int OUTPUT,
	@QuizID int,
	@OccuredAt datetimeoffset,
	@SessionCode char(6)
AS
BEGIN
INSERT INTO Customer  (
    IDQuizSession,
	QuizID,
	OccuredAt,
	SessionCode)
    VALUES (
    @IDQuizSession,
	@QuizID,
	@OccuredAt,
	@SessionCode)
 
SET @IDQuizSession = SCOPE_IDENTITY()
END
--------------------------------------------------proc_create_Attendee--------------------------------------------------
IF OBJECT_ID('proc_create_Attendee') IS NOT NULL
BEGIN 
DROP PROC proc_create_Attendee 
END
GO
CREATE PROCEDURE proc_create_Attendee
	@IDAttendee int OUTPUT,
	@Username varchar(64),,
	@SessionID int,
AS
BEGIN
INSERT INTO Customer  (
    IDAttendee,
	Username,
	SessionID)
    VALUES (
    @IDAttendee,
	@Username,
	@SessionID)
 
SET @IDAttendee = SCOPE_IDENTITY()
END
--------------------------------------------------proc_create_LogItem--------------------------------------------------
IF OBJECT_ID('proc_create_LogItem') IS NOT NULL
BEGIN 
DROP PROC proc_create_LogItem 
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
INSERT INTO Customer  (
    IDLogItem,
	QuizSessionID,
	QuizQuestionID,
	QuizAnswerID,
	AttendeeID,
	Points)
    VALUES (
    @IDLogItem,
	@QuizSessionID,
	@QuizQuestionID,
	@QuizAnswerID,
	@AttendeeID,
	@Points)
 
SET @IDLogItem = SCOPE_IDENTITY()
END
