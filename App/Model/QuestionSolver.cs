using App.DAL.Entities;
using App.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    class QuestionSolver
    {
        private ObservableCollection<Answer> answers;
        private List<Answer> correctAnswers;
        private ObservableCollection<Answer> currentAnswers = [];

        public QuestionSolver(Question question)
        {
            answers = AnswerRepository.GetAnswersByQuestionId(question.Id);
            correctAnswers = answers.Where(answer => answer.IsCorrect).ToList<Answer>();
        }

        public ObservableCollection<Answer> GetAllAnswers()
        {
            return answers;
        }

        public void SelectAnswer(int answerId)
        {
            currentAnswers.Add((Answer)answers.Where(answer => answer.Id == answerId).Take(1).ToList()[0]);
        }

        public bool IsCorrect()
        {
            return currentAnswers.All(answer => answer.IsCorrect);
        }
    }
}
