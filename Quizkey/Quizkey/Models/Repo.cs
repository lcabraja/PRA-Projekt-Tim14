using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
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
            int IDAuthor = int.Parse(SqlHelper.ExecuteScalar(cs, "proc_create_Author", author.Username, author.PasswordHash, author.Email).ToString());
            if (IDAuthor > 0)
            {
                Add(author);
                return IDAuthor;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static Author GetAuthor(int IDAuthor)
        {
            if (authorCache != null)
                if (authorCache.Contains(new Author { IDAuthor = IDAuthor }))
                    return authorCache.Find(x => x.IDAuthor == IDAuthor);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_Author", IDAuthor);
            return ds.Tables[0].Rows.Count > 0 ? GetAuthorFromDataRow(ds.Tables[0].Rows[0]) : null;
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
            int IDQuiz = int.Parse(SqlHelper.ExecuteScalar(cs, "proc_create_Quiz", quiz.AuthorID, quiz.QuizName).ToString());
            if (IDQuiz > 0)
            {
                Add(quiz);
                return IDQuiz;
            }
            throw new SQLInsertException("Could not insert values into table \"Quiz\"");
        }

        public static Quiz GetQuiz(int IDQuiz)
        {
            if (quizCache != null)
                if (quizCache.Contains(new Quiz { IDQuiz = IDQuiz }))
                    return quizCache.Find(x => x.IDQuiz == IDQuiz);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_Quiz", IDQuiz);
            return ds.Tables[0].Rows.Count > 0 ? GetQuizFromDataRow(ds.Tables[0].Rows[0]) : null;
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
            int IDQuizQuestion = int.Parse(SqlHelper.ExecuteScalar(
                cs,
                "proc_create_QuizQuestion",
                quizquestion.QuizID,
                quizquestion.QuestionNumber,
                quizquestion.QuestionText,
                quizquestion.CorrectAnswer,
                quizquestion.AnswerTimeSeconds
            ).ToString());
            if (IDQuizQuestion > 0)
            {
                Add(quizquestion);
                return IDQuizQuestion;
            }
            throw new SQLInsertException("Could not insert values into table \"QuizQuestion\"");
        }

        public static QuizQuestion GetQuizQuestion(int IDQuizQuestion)
        {
            if (quizquestionCache != null)
                if (quizquestionCache.Contains(new QuizQuestion { IDQuizQuestion = IDQuizQuestion }))
                    return quizquestionCache.Find(x => x.IDQuizQuestion == IDQuizQuestion);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_QuizQuestion", IDQuizQuestion);
            return ds.Tables[0].Rows.Count > 0 ? GetQuizQuestionFromDataRow(ds.Tables[0].Rows[0]) : null;
        }

        // TODO multiple with quiz ID
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
                CorrectAnswer = (short)row["CorrectAnswer"],
                AnswerTimeSeconds = (int)row["AnswerTimeSeconds"]
            };
        }
        //-------------------------------------------------------QuizAnswer-------------------------------------------------------
        public static int CreateQuizAnswer(QuizAnswer quizanswer)
        {
            int IDQuizAnswer = int.Parse(SqlHelper.ExecuteScalar(cs, "proc_create_QuizAnswer", quizanswer.QuizQuestionID, quizanswer.AnswerText, quizanswer.QuestionOrder).ToString());
            if (IDQuizAnswer > 0)
            {
                Add(quizanswer);
                return IDQuizAnswer;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static QuizAnswer GetQuizAnswer(int IDQuizAnswer)
        {
            if (quizanswerCache != null)
                if (quizanswerCache.Contains(new QuizAnswer { IDQuizAnswer = IDQuizAnswer }))
                    return quizanswerCache.Find(x => x.IDQuizAnswer == IDQuizAnswer);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_QuizAnswer", IDQuizAnswer);
            return ds.Tables[0].Rows.Count > 0 ? GetQuizAnswerFromDataRow(ds.Tables[0].Rows[0]) : null;
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
                QuestionOrder = (short)row["QuestionOrder"]
            };
        }
        //------------------------------------------------------QuizSession-------------------------------------------------------
        public static int CreateQuizSession(QuizSession quizsession)
        {
            int IDQuizSession = int.Parse(SqlHelper.ExecuteScalar(cs, "proc_create_QuizSession", quizsession.QuizID, quizsession.OccurredAt, quizsession.SessionCode).ToString());
            if (IDQuizSession > 0)
            {
                Add(quizsession);
                return IDQuizSession;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static QuizSession GetQuizSession(int IDQuizSession)
        {
            if (quizsessionCache != null)
                if (quizsessionCache.Contains(new QuizSession { IDQuizSession = IDQuizSession }))
                    return quizsessionCache.Find(x => x.IDQuizSession == IDQuizSession);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_QuizSession", IDQuizSession);
            return ds.Tables[0].Rows.Count > 0 ? GetQuizSessionFromDataRow(ds.Tables[0].Rows[0]) : null;
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
            int IDAttendee = int.Parse(SqlHelper.ExecuteScalar(cs, "proc_create_Attendee", attendee.Username, attendee.SessionID).ToString());
            if (IDAttendee > 0)
            {
                Add(attendee);
                return IDAttendee;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static Attendee GetAttendee(int IDAttendee)
        {
            if (attendeeCache != null)
                if (attendeeCache.Contains(new Attendee { IDAttendee = IDAttendee }))
                    return attendeeCache.Find(x => x.IDAttendee == IDAttendee);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_Attendee", IDAttendee);
            return ds.Tables[0].Rows.Count > 0 ? GetAttendeeFromDataRow(ds.Tables[0].Rows[0]) : null;
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
            int IDAuthor = int.Parse(SqlHelper.ExecuteScalar(cs, "proc_create_LogItem", logitem.QuizSessionID, logitem.QuizQuestionID, logitem.QuizAnswerID, logitem.AttendeeID, logitem.Points).ToString());
            if (IDAuthor > 0)
            {
                Add(logitem);
                return IDAuthor;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static LogItem GetLogItem(int IDLogItem)
        {
            if (logitemCache != null)
                if (logitemCache.Contains(new LogItem { IDLogItem = IDLogItem }))
                    return logitemCache.Find(x => x.IDLogItem == IDLogItem);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_LogItem", IDLogItem);
            return ds.Tables[0].Rows.Count > 0 ? GetLogItemFromDataRow(ds.Tables[0].Rows[0]) : null;
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
            int IDRecentQuiz = int.Parse(SqlHelper.ExecuteScalar(cs, "proc_create_RecentQuiz", recentquiz.QuizID, recentquiz.LastEvent).ToString());
            if (IDRecentQuiz > 0)
            {
                Add(recentquiz);
                return IDRecentQuiz;
            }
            throw new SQLInsertException("Could not insert values into table \"Author\"");
        }

        public static RecentQuiz GetRecentQuiz(int IDRecentQuiz)
        {
            if (recentquizCache != null)
                if (recentquizCache.Contains(new RecentQuiz { IDRecentQuiz = IDRecentQuiz }))
                    return recentquizCache.Find(x => x.IDRecentQuiz == IDRecentQuiz);
            DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_RecentQuiz", IDRecentQuiz);
            return ds.Tables[0].Rows.Count > 0 ? GetRecentQuizFromDataRow(ds.Tables[0].Rows[0]) : null;
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
        //---------------------------------------------------------Cache----------------------------------------------------------
        private static void Add(object item)
        {
            if (item.GetType().Equals(typeof(Attendee)))
            {
                if (attendeeCache != null)
                {
                    attendeeCache.Add(item as Attendee);
                }
                else
                {
                    attendeeCache = new List<Attendee> { item as Attendee };
                }
            }
            else if (item.GetType().Equals(typeof(Author)))
            {
                if (authorCache != null)
                {
                    authorCache.Add(item as Author);
                }
                else
                {
                    authorCache = new List<Author> { item as Author };
                }
            }
            else if (item.GetType().Equals(typeof(LogItem)))
            {
                if (logitemCache != null)
                {
                    logitemCache.Add(item as LogItem);
                }
                else
                {
                    logitemCache = new List<LogItem> { item as LogItem };
                }
            }
            else if (item.GetType().Equals(typeof(Quiz)))
            {
                if (quizCache != null)
                {
                    quizCache.Add(item as Quiz);
                }
                else
                {
                    quizCache = new List<Quiz> { item as Quiz };
                }
            }
            else if (item.GetType().Equals(typeof(QuizAnswer)))
            {
                if (quizanswerCache != null)
                {
                    quizanswerCache.Add(item as QuizAnswer);
                }
                else
                {
                    quizanswerCache = new List<QuizAnswer> { item as QuizAnswer };
                }
            }
            else if (item.GetType().Equals(typeof(QuizQuestion)))
            {
                if (quizquestionCache != null)
                {
                    quizquestionCache.Add(item as QuizQuestion);
                }
                else
                {
                    quizquestionCache = new List<QuizQuestion> { item as QuizQuestion };
                }
            }
            else if (item.GetType().Equals(typeof(QuizSession)))
            {
                if (quizsessionCache != null)
                {
                    quizsessionCache.Add(item as QuizSession);
                }
                else
                {
                    quizsessionCache = new List<QuizSession> { item as QuizSession };
                }
            }
            else if (item.GetType().Equals(typeof(RecentQuiz)))
            {
                if (recentquizCache != null)
                {
                    recentquizCache.Add(item as RecentQuiz);
                }
                else
                {
                    recentquizCache = new List<RecentQuiz> { item as RecentQuiz };
                }
            }
        }
    }
}