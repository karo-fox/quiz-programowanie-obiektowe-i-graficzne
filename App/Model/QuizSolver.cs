using App.DAL.Entities;
using App.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    class QuizSolver
    {
        private Quiz quiz;
        private List<Question> questions;
        private int currentQuestionIdx;
        private bool end = false;
        private int points = 0;
        public QuizSolver(Quiz selectedQuiz) 
        {
            quiz = selectedQuiz;
            questions = QuestionRepository.GetQuestionsByQuizId((int)quiz.Id);
            currentQuestionIdx = 0;
        }

        public Question CurrentQuestion
        {
            get
            {
                return questions[currentQuestionIdx];
            }
        }

        public void NextQuestion()
        {
            if (currentQuestionIdx < Length)
            {
                currentQuestionIdx++;
            }
        }

        public int Points
        {
            get
            {
                return points;
            }
        }

        public int Length
        {
            get
            {
                return questions.Count;
            }
        }

        public Quiz Quiz
        {
            get { return quiz; }
        }
    }
}
