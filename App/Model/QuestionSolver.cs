using App.DAL.Entities;
using App.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    class QuestionSolver
    {
        private List<Answer> answers;
        private List<Answer> correctAnswers;
        private List<Answer> currentAnswers = [];

        public QuestionSolver(Question question)
        {
            answers = AnswerRepository.GetAnswersByQuestionId(question.Id);
            correctAnswers = (List<Answer>)answers.Where(answer => answer.IsCorrect);
        }

        public List<Answer> GetAllAnswers()
        {
            return answers;
        }

        public void SelectAnswer(int answerId)
        {
            currentAnswers.Add((Answer)answers.Where(answer => answer.Id == answerId));
        }

        public bool IsCorrect()
        {
            return correctAnswers.All(answer => currentAnswers.Contains(answer));
        }
    }
}
