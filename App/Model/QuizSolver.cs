using App.DAL.Entities;
using App.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    class QuizSolver
    {
        private Quiz quiz;
        private List<Question> questions;
        private int currentQuestion;
        private bool end = false;
        private int points = 0;
        public QuizSolver(Quiz selectedQuiz) 
        {
            quiz = selectedQuiz;
            questions = QuestionRepository.GetQuestionsByQuizId((int)quiz.Id);
            currentQuestion = 0;
        }

        public void NextQuestion()
        {
            if (currentQuestion < questions.Count)
            {
                currentQuestion++;
            } else
            {
                end = true;
            }
        }

        public void AddPoint()
        {
            points++;
        }

        public Question CurrentQuestion
        {
            get
            {
                return questions[currentQuestion];
            }
        }

        public bool IsEnded
        {
            get
            {
                return end;
            }
        }

        public int Points
        {
            get
            {
                return points;
            }
        }
    }
}
