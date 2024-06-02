using App.DAL.Entities;
using App.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    class QuizSelector
    {
        private readonly List<Quiz> quizes = [];
        private Quiz? selected = null;
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
            quizes = QuizRepository.GetAllQuizes();
        }

        public Quiz? Selected { get { return selected; } }

        public void SelectQuiz(int id)
        {
            selected = (Quiz)quizes.Where(quiz => quiz.Id == id);
        }
    }
}
