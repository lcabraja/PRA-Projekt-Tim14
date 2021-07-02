using Quizkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey
{
    public static class LoadQuizData
    {
        public static QuizCreationModel GetQuizData(int sessionID)
        {
            QuizCreationModel model = new QuizCreationModel();
            var session = Repo.GetQuizSession(sessionID);
            var quiz = Repo.GetQuiz(session.QuizID);
            model.QuizName = quiz.QuizName;
            model.QuizID = quiz.IDQuiz;
            var quest = Repo.GetMultipleQuizQuestion();
            var questions = quest.Where(x => x.QuizID == quiz.IDQuiz);
            foreach (var question in questions)
            {
                QuizCreationPage page = new QuizCreationPage();
                page.Question = question.QuestionText;
                page.QuestionID = question.IDQuizQuestion;
                page.SelectedAnswer = question.CorrectAnswer;
                page.SelectedTime = question.AnswerTimeSeconds;
                var answers = Repo.GetMultipleQuizAnswer().Where(x => x.QuizQuestionID == question.IDQuizQuestion);
                page.Answer1 = answers.Where(x => x.QuestionOrder == 1)?.First()?.AnswerText;
                page.Answer2 = answers.Where(x => x.QuestionOrder == 2)?.First()?.AnswerText;
                page.Answer3 = answers.Where(x => x.QuestionOrder == 3).DefaultIfEmpty()?.First()?.AnswerText;
                page.Answer4 = answers.Where(x => x.QuestionOrder == 4).DefaultIfEmpty()?.First()?.AnswerText;
                model.Pages[question.QuestionNumber] = page;
            }
            return model;
        }
    }
}