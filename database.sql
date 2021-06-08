IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Quizkey')
	BEGIN
		CREATE DATABASE Quizkey
	END
ELSE
	BEGIN
		USE master
		DROP DATABASE Quizkey
		CREATE DATABASE Quizkey
	END

-- Creating tables
	
USE Quizkey
GO
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
	QuizName varchar(256) not null
	constraint pk_IDQuiz primary key clustered (IDQuiz)
)
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
	AnswerText varchar(512),
	QuestionOrder smallint
	constraint fk_QuizAnswer_QuizQuestion foreign key (QuizQuestionID) references QuizQuestion(IDQuizQuestion),
	constraint pk_IDQuizAnswer primary key clustered (IDQuizAnswer)
)
GO
CREATE TABLE QuizSession (
	IDQuizSession int identity(1,1),
	QuizID int not null,
	OccuredAt datetimeoffset not null,
	SessionCode char(6) not null,
	constraint fk_QuizSession_Quiz foreign key (QuizID) references Quiz(IDQuiz),
	constraint pk_QuizSession primary key clustered (IDQuizSession)	,
)
GO
CREATE TABLE Attendee (
	IDAttendee int identity(1,1),
	Username varchar(64),
	SessionID int,
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
