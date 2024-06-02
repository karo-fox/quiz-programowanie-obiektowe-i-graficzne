using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    using DAL.Entities;
    using DAL.Repositories;
    using System.Collections.ObjectModel;
    using System.Security.Cryptography.X509Certificates;

    internal class CreatorModel
    {
        public ObservableCollection<String> QuizNames { get; set; } = new ObservableCollection<String>();

        public CreatorModel()
        {
            var quizes = QuizRepository.GetAllQuizNames();
            foreach (var quiz in quizes)
                QuizNames.Add(quiz);
        }

        public bool IsQuizInRepo(string name) => QuizNames.Contains(name);

        public bool AddQuiz(string name)
        {
            if (!IsQuizInRepo(name))
            {
                if (QuizRepository.AddNewQuiz(name))
                {
                    QuizNames.Add(name);
                    return true;
                }
            }
            return false;
        }

        public bool AddQuestion(string name, int quizId, string ans1, string ans2, string ans3, string ans4, bool bans1, bool bans2, bool bans3, bool bans4)
        {
            if(QuestionRepository.AddNewQuestionWithAnswers(name, quizId, ans1, ans2, ans3, ans4, bans1, bans2, bans3, bans4))
                return true;
            return false;
        }
    }
}
