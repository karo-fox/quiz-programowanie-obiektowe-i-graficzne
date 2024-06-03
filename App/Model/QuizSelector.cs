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
    class QuizSelector
    {
        private Quiz selected;
        private static readonly QuizSelector instance = new QuizSelector();

        public static QuizSelector Instance
        {
            get
            {
                return instance;
            }
        }

        private QuizSelector()
        {
            selected = Quizes[0];
        }

        public ObservableCollection<Quiz> Quizes { get { return QuizRepository.GetAllQuizes(); } }
        public Quiz Selected { get { return selected; } }

        public void SelectQuiz(int id)
        {
            selected = (Quiz)Quizes.Where(quiz => quiz.Id == id).Take(1).ToList()[0];
        }
    }
}
