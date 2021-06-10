﻿using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    //return (int)SqlHelper.ExecuteScalar(cs, "proc_create_Author", "Username", "password", "Email"); //returns id of newly created row
    public static class Repo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cloud"].ConnectionString;

        //---------------------------------------------------------Cache----------------------------------------------------------
        private static List<Author> authorCache = null;
        private static List<Quiz> quizCache = null;
        private static List<QuizQuestion> quizquestionCache = null;
        private static List<QuizAnswer> quizanswerCache = null;
        private static List<QuizSession> quizsessionCache = null;
        private static List<Attendee> attendeeCache = null;
        private static List<LogItem> logitemCache = null;
        private static List<RecentQuiz> recentquizCache = null;

        //---------------------------------------------------------Author---------------------------------------------------------
        public static int CreateAuthor(Author author)
        {
            int IDAuthor = (int)SqlHelper.ExecuteScalar(cs, "proc_create_Author", author.Username, author.PasswordHash, author.Email);
            if (IDAuthor > 0)
            {
                authorCache.Add(author);
                return IDAuthor;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static Author GetAuthor(int IDAuthor)
        {
            if (authorCache.Contains(new Author { IDAuthor = IDAuthor }))
                return authorCache.Find(x => x.IDAuthor == IDAuthor);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_Author", IDAuthor);
            return GetAuthorFromDataRow(ds.Tables[0].Rows[0]);
        }

        public static List<Author> GetMultipleAuthor()
        {
            List<Author> collection = new List<Author>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_Author");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                collection.Add(GetAuthorFromDataRow(row));
            }
            authorCache = collection;
            return collection;
        }

        public static void UpdateAuthor(Author author)
        {
            SqlHelper.ExecuteDataset(cs, "proc_update_Author", author.IDAuthor, author.Username, author.PasswordHash, author.Email);
        }

        public static void DeleteAuthor(int IDAuthor)
        {
            SqlHelper.ExecuteDataset(cs, "proc_delete_Author", IDAuthor);
        }

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
        //----------------------------------------------------------Quiz----------------------------------------------------------
        public static int CreateQuiz(Quiz quiz)
        {
            int IDQuiz = (int)SqlHelper.ExecuteScalar(cs, "proc_create_Quiz", quiz.AuthorID, quiz.QuizName);
            if (IDQuiz > 0)
            {
                quizCache.Add(quiz);
                return IDQuiz;
            }
            throw new SQLInsertException("Could not insert values into table \"Quiz\"");
        }

        public static Quiz GetQuiz(int IDQuiz)
        {
            if (quizCache.Contains(new Quiz { IDQuiz = IDQuiz }))
                return quizCache.Find(x => x.IDQuiz == IDQuiz);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_Quiz", IDQuiz);
            return GetQuizFromDataRow(ds.Tables[0].Rows[0]);
        }

        public static List<Quiz> GetMultipleQuiz()
        {
            List<Quiz> collection = new List<Quiz>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_Quiz");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                collection.Add(GetQuizFromDataRow(row));
            }
            quizCache = collection;
            return collection;
        }

        public static void UpdateQuiz(Quiz quiz)
        {
            SqlHelper.ExecuteDataset(cs, "proc_update_Quiz", quiz.IDQuiz, quiz.AuthorID, quiz.QuizName);
        }

        public static void DeleteQuiz(int IDQuiz)
        {
            SqlHelper.ExecuteDataset(cs, "proc_delete_Quiz", IDQuiz);
        }
        private static Quiz GetQuizFromDataRow(DataRow row)
        {
            return new Quiz
            {
                IDQuiz = (int)row["IDQuiz"],
                AuthorID = (int)row["AuthorID"],
                QuizName = row["QuizName"].ToString()
            };
        }
        //------------------------------------------------------QuizQuestion------------------------------------------------------
        public static int CreateQuizQuestion(QuizQuestion quizquestion)
        {
            int IDQuizQuestion = (int)SqlHelper.ExecuteScalar(
                cs,
                "proc_create_QuizQuestion",
                quizquestion.QuizID,
                quizquestion.QuestionNumber,
                quizquestion.QuestionText,
                quizquestion.CorrectAnswer,
                quizquestion.AnswerTimeSeconds
            );
            if (IDQuizQuestion > 0)
            {
                quizquestionCache.Add(quizquestion);
                return IDQuizQuestion;
            }
            throw new SQLInsertException("Could not insert values into table \"QuizQuestion\"");
        }

        public static QuizQuestion GetQuizQuestion(int IDQuizQuestion)
        {
            if (quizquestionCache.Contains(new QuizQuestion { IDQuizQuestion = IDQuizQuestion }))
                return quizquestionCache.Find(x => x.IDQuizQuestion == IDQuizQuestion);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_QuizQuestion", IDQuizQuestion);
            return GetQuizQuestionFromDataRow(ds.Tables[0].Rows[0]);
        }

        public static List<QuizQuestion> GetMultipleQuizQuestion()
        {
            List<QuizQuestion> collection = new List<QuizQuestion>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_QuizQuestion");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                collection.Add(GetQuizQuestionFromDataRow(row));
            }
            quizquestionCache = collection;
            return collection;
        }

        public static void UpdateQuizQuestion(QuizQuestion quizquestion)
        {
            SqlHelper.ExecuteDataset(cs, "proc_update_QuizQuestion", quizquestion.IDQuizQuestion, quizquestion.QuizID, quizquestion.QuestionNumber, quizquestion.QuestionText, quizquestion.CorrectAnswer, quizquestion.AnswerTimeSeconds);
        }

        public static void DeleteQuizQuestion(int IDQuizQuestion)
        {
            SqlHelper.ExecuteDataset(cs, "proc_delete_QuizQuestion", IDQuizQuestion);
        }
        private static QuizQuestion GetQuizQuestionFromDataRow(DataRow row)
        {
            return new QuizQuestion
            {
                IDQuizQuestion = (int)row["IDQuizQuestion"],
                QuizID = (int)row["QuizID"],
                QuestionNumber = (int)row["QuestionNumber"],
                QuestionText = row["QuestionText"].ToString(),
                CorrectAnswer = row["CorrectAnswer"].ToString(),
                AnswerTimeSeconds = (int)row["AnswerTimeSeconds"]
            };
        }
        //-------------------------------------------------------QuizAnswer-------------------------------------------------------
        public static int CreateQuizAnswer(QuizAnswer quizanswer)
        {
            int IDQuizAnswer = (int)SqlHelper.ExecuteScalar(cs, "proc_create_QuizAnswer", quizanswer.QuizQuestionID, quizanswer.AnswerText, quizanswer.QuestionOrder);
            if (IDQuizAnswer > 0)
            {
                quizanswerCache.Add(quizanswer);
                return IDQuizAnswer;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static QuizAnswer GetQuizAnswer(int IDQuizAnswer)
        {
            if (quizanswerCache.Contains(new QuizAnswer { IDQuizAnswer = IDQuizAnswer }))
                return quizanswerCache.Find(x => x.IDQuizAnswer == IDQuizAnswer);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_QuizAnswer", IDQuizAnswer);
            return GetQuizAnswerFromDataRow(ds.Tables[0].Rows[0]);
        }

        public static List<QuizAnswer> GetMultipleQuizAnswer()
        {
            List<QuizAnswer> collection = new List<QuizAnswer>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_QuizAnswer");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                collection.Add(GetQuizAnswerFromDataRow(row));
            }
            quizanswerCache = collection;
            return collection;
        }

        public static void UpdateQuizAnswer(QuizAnswer quizanswer)
        {
            SqlHelper.ExecuteDataset(cs, "proc_update_QuizAnswer", quizanswer.IDQuizAnswer, quizanswer.QuizQuestionID, quizanswer.AnswerText, quizanswer.QuestionOrder);
        }

        public static void DeleteQuizAnswer(int IDQuizAnswer)
        {
            SqlHelper.ExecuteDataset(cs, "proc_delete_QuizAnswer", IDQuizAnswer);
        }

        private static QuizAnswer GetQuizAnswerFromDataRow(DataRow row)

        {
            return new QuizAnswer
            {
                IDQuizAnswer = (int)row["IDQuizAnswer"],
                QuizQuestionID = (int)row["QuizQuestionID"],
                AnswerText = row["AnswerText"].ToString(),
                QuestionOrder = row["QuestionOrder"].ToString()
            };
        }
        //------------------------------------------------------QuizSession-------------------------------------------------------
        public static int CreateQuizSession(QuizSession quizsession)
        {
            int IDQuizSession = (int)SqlHelper.ExecuteScalar(cs, "proc_create_QuizSession", quizsession.QuizID, quizsession.OccurredAt, quizsession.SessionCode);
            if (IDQuizSession > 0)
            {
                quizsessionCache.Add(quizsession);
                return IDQuizSession;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static QuizSession GetQuizSession(int IDQuizSession)
        {
            if (quizsessionCache.Contains(new QuizSession { IDQuizSession = IDQuizSession }))
                return quizsessionCache.Find(x => x.IDQuizSession == IDQuizSession);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_QuizSession", IDQuizSession);
            return GetQuizSessionFromDataRow(ds.Tables[0].Rows[0]);
        }

        public static List<QuizSession> GetMultipleQuizSession()
        {
            List<QuizSession> collection = new List<QuizSession>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_QuizSession");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                collection.Add(GetQuizSessionFromDataRow(row));
            }
            quizsessionCache = collection;
            return collection;
        }

        public static void UpdateQuizSession(QuizSession quizsession)
        {
            SqlHelper.ExecuteDataset(cs, "proc_update_QuizSession", quizsession.IDQuizSession, quizsession.QuizID, quizsession.OccurredAt, quizsession.SessionCode);
        }

        public static void DeleteQuizSession(int IDQuizSession)
        {
            SqlHelper.ExecuteDataset(cs, "proc_delete_QuizSession", IDQuizSession);
        }
        private static QuizSession GetQuizSessionFromDataRow(DataRow row)
        {
            return new QuizSession
            {
                IDQuizSession = (int)row["IDQuizSession"],
                QuizID = (int)row["QuizID"],
                OccurredAt = DateTimeOffset.Parse(row["OccurredAt"].ToString()),
                SessionCode = row["SessionCode"].ToString()
            };
        }
        //--------------------------------------------------------Attendee--------------------------------------------------------
        public static int CreateAttendee(Attendee attendee)
        {
            int IDAttendee = (int)SqlHelper.ExecuteScalar(cs, "proc_create_Attendee", attendee.Username, attendee.SessionID);
            if (IDAttendee > 0)
            {
                attendeeCache.Add(attendee);
                return IDAttendee;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static Attendee GetAttendee(int IDAttendee)
        {
            if (attendeeCache.Contains(new Attendee { IDAttendee = IDAttendee }))
                return attendeeCache.Find(x => x.IDAttendee == IDAttendee);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_Attendee", IDAttendee);
            return GetAttendeeFromDataRow(ds.Tables[0].Rows[0]);
        }

        public static List<Attendee> GetMultipleAttendee()
        {
            List<Attendee> collection = new List<Attendee>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_Attendee");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                collection.Add(GetAttendeeFromDataRow(row));
            }
            attendeeCache = collection;
            return collection;
        }

        public static void UpdateAttendee(Attendee attendee)
        {
            SqlHelper.ExecuteDataset(cs, "proc_update_Attendee", attendee.IDAttendee, attendee.Username, attendee.SessionID);
        }

        public static void DeleteAttendee(int IDAttendee)
        {
            SqlHelper.ExecuteDataset(cs, "proc_delete_Attendee", IDAttendee);
        }
        private static Attendee GetAttendeeFromDataRow(DataRow row)
        {
            return new Attendee
            {
                IDAttendee = (int)row["IDAttendee"],
                Username = row["Username"].ToString(),
                SessionID = (int)row["SessionID"]
            };
        }
        //--------------------------------------------------------LogItem---------------------------------------------------------
        public static int CreateLogItem(LogItem logitem)
        {
            int IDAuthor = (int)SqlHelper.ExecuteScalar(cs, "proc_create_LogItem", logitem.QuizSessionID, logitem.QuizQuestionID, logitem.QuizAnswerID, logitem.AttendeeID, logitem.Points);
            if (IDAuthor > 0)
            {
                logitemCache.Add(logitem);
                return IDAuthor;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static LogItem GetLogItem(int IDLogItem)
        {
            if (logitemCache.Contains(new LogItem { IDLogItem = IDLogItem }))
                return logitemCache.Find(x => x.IDLogItem == IDLogItem);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_LogItem", IDLogItem);
            return GetLogItemFromDataRow(ds.Tables[0].Rows[0]);
        }

        public static List<LogItem> GetMultipleLogItem()
        {
            List<LogItem> collection = new List<LogItem>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_LogItem");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                collection.Add(GetLogItemFromDataRow(row));
            }
            logitemCache = collection;
            return collection;
        }

        public static void UpdateLogItem(LogItem logitem)
        {
            SqlHelper.ExecuteDataset(cs, "proc_update_LogItem", logitem.IDLogItem, logitem.QuizSessionID, logitem.QuizQuestionID, logitem.QuizAnswerID, logitem.AttendeeID, logitem.Points);
        }

        public static void DeleteLogItem(int IDLogItem)
        {
            SqlHelper.ExecuteDataset(cs, "proc_delete_LogItem", IDLogItem);
        }
        private static LogItem GetLogItemFromDataRow(DataRow row)
        {
            return new LogItem
            {
                IDLogItem = (int)row["IDLogItem"],
                QuizSessionID = (int)row["QuizSessionID"],
                QuizQuestionID = (int)row["QuizQuestionID"],
                QuizAnswerID = (int)row["QuizAnswerID"],
                AttendeeID = (int)row["AttendeeID"],
                Points = (int)row["Points"]
            };
        }
        //-------------------------------------------------------RecentQuiz-------------------------------------------------------
        public static int CreateRecentQuiz(RecentQuiz recentquiz)
        {
            int IDRecentQuiz = (int)SqlHelper.ExecuteScalar(cs, "proc_create_RecentQuiz", recentquiz.QuizID, recentquiz.LastEvent);
            if (IDRecentQuiz > 0)
            {
                recentquizCache.Add(recentquiz);
                return IDRecentQuiz;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static RecentQuiz GetRecentQuiz(int IDRecentQuiz)
        {
            if (recentquizCache.Contains(new RecentQuiz { IDRecentQuiz = IDRecentQuiz }))
                return recentquizCache.Find(x => x.IDRecentQuiz == IDRecentQuiz);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_RecentQuiz", IDRecentQuiz);
            return GetRecentQuizFromDataRow(ds.Tables[0].Rows[0]);
        }

        public static List<RecentQuiz> GetMultipleRecentQuiz()
        {
            List<RecentQuiz> collection = new List<RecentQuiz>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_RecentQuiz");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                collection.Add(GetRecentQuizFromDataRow(row));
            }
            recentquizCache = collection;
            return collection;
        }

        public static void UpdateRecentQuiz(RecentQuiz recentquiz)
        {
            SqlHelper.ExecuteDataset(cs, "proc_update_RecentQuiz", recentquiz.IDRecentQuiz, recentquiz.QuizID, recentquiz.LastEvent);
        }

        public static void DeleteRecentQuiz(int IDRecentQuiz)
        {
            SqlHelper.ExecuteDataset(cs, "proc_delete_RecentQuiz", IDRecentQuiz);
        }
        private static RecentQuiz GetRecentQuizFromDataRow(DataRow row)
        {
            return new RecentQuiz
            {
                IDRecentQuiz = (int)row["IDRecentQuiz"],
                QuizID = (int)row["QuizID"],
                LastEvent = DateTimeOffset.Parse(row["LastEvent"].ToString())
            };
        }
    }
}