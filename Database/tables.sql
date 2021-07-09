USE master
GO
IF OBJECT_ID('Quizkey') IS NOT NULL
BEGIN
    USE master
    GO
    DROP DATABASE Quizkey
END
GO
CREATE DATABASE Quizkey
GO
-- Creating tables
USE Quizkey
GO
IF OBJECT_ID('LogItem') IS NOT NULL
BEGIN
	DROP TABLE LogItem
END
IF OBJECT_ID('QuizAnswer') IS NOT NULL
BEGIN
	DROP TABLE QuizAnswer
END
IF OBJECT_ID('QuizQuestion') IS NOT NULL
BEGIN
	DROP TABLE QuizQuestion
END
IF OBJECT_ID('Attendee') IS NOT NULL
BEGIN
	DROP TABLE Attendee
END
IF OBJECT_ID('QuizSession') IS NOT NULL
BEGIN
	DROP TABLE QuizSession
END
IF OBJECT_ID('RecentQuiz') IS NOT NULL
BEGIN
	DROP TABLE RecentQuiz
END
IF OBJECT_ID('Quiz') IS NOT NULL
BEGIN
	DROP TABLE Quiz
END
IF OBJECT_ID('Author') IS NOT NULL
BEGIN
	DROP TABLE Author
END
CREATE TABLE Author (
	IDAuthor int identity(1,1),
	Username varchar(64) not null,
	PasswordHash varchar(128) not null,
	Email varchar(128) not null
	constraint pk_Author primary key clustered (IDAuthor)
)
GO
CREATE TABLE Quiz (
	IDQuiz int identity(1,1),
	AuthorID int not null,
	QuizName varchar(256) not null
	constraint pk_IDQuiz primary key clustered (IDQuiz)
)
GO
CREATE TABLE QuizQuestion (
	IDQuizQuestion int identity(1,1),
	QuizID int not null,
	QuestionNumber int not null,
	QuestionText varchar(512) not null,
	CorrectAnswer smallint not null,
	AnswerTimeSeconds int not null
	constraint fk_QuizQuestion_Quiz foreign key (QuizID) references Quiz(IDQuiz),
	constraint pk_IDQuizQuestion primary key clustered (IDQuizQuestion)
)
GO
CREATE TABLE QuizAnswer (
	IDQuizAnswer int identity(1,1),
	QuizQuestionID int not null,
	AnswerText varchar(512) not null,
	QuestionOrder smallint not null
	constraint fk_QuizAnswer_QuizQuestion foreign key (QuizQuestionID) references QuizQuestion(IDQuizQuestion),
	constraint pk_IDQuizAnswer primary key clustered (IDQuizAnswer)
)
GO
CREATE TABLE QuizSession (
	IDQuizSession int identity(1,1),
	QuizID int not null,
	OccurredAt datetimeoffset not null,
	SessionCode char(6) not null,
	constraint fk_QuizSession_Quiz foreign key (QuizID) references Quiz(IDQuiz),
	constraint pk_QuizSession primary key clustered (IDQuizSession)	,
)
GO
CREATE TABLE Attendee (
	IDAttendee int identity(1,1),
	Username varchar(64) not null,
	SessionID int not null,
	constraint fk_SessionID_QuizSession foreign key (SessionID) references QuizSession(IDQuizSession),
	constraint pk_Attendee primary key clustered (IDAttendee)
)
GO
CREATE TABLE LogItem (
	IDLogItem int identity(1,1),
	QuizSessionID int not null,
	QuizQuestionID int not null,
	QuizAnswerID int not null, -- reffers to submitted quiz answer
	AttendeeID int not null,
	Points int not null
	constraint fk_LogItem_QuizSession foreign key (QuizSessionID) references QuizSession(IDQuizSession),
	constraint fk_LogItem_QuizQuestion foreign key (QuizQuestionID) references QuizQuestion(IDQuizQuestion),
	constraint fk_LogItem_QuizAnswer foreign key (QuizAnswerID) references QuizAnswer(IDQuizAnswer),
	constraint fk_LogItem_Attendee foreign key (AttendeeID) references Attendee(IDAttendee),
	constraint pk_IDLogItem primary key clustered (IDLogItem)
)
GO
CREATE TABLE RecentQuiz (
	IDRecentQuiz int identity(1,1),
	QuizID int not null,
	LastEvent datetimeoffset not null
	constraint fk_RecentQuiz_Quiz foreign key (QuizID) references Quiz(IDQuiz),
	constraint pk_IDRecentQuiz primary key clustered (IDRecentQuiz)
)
GO