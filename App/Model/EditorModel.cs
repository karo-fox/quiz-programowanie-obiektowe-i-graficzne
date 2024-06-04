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

    internal class EditorModel
    {
        public ObservableCollection<Quiz> Quizes { get; set; } = new ObservableCollection<Quiz>();
        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();
        public ObservableCollection<Answer> Answers { get; set; } = new ObservableCollection<Answer>();
        public EditorModel() 
        {
            var q = QuizRepository.GetAllQuizes();
            foreach (var w in q)
                Quizes.Add(w);
        }

        public void RefreshQuizes()
        {
            Quizes.Clear();
            var q = QuizRepository.GetAllQuizes();
            foreach (var w in q)
                Quizes.Add(w);
        }
        
        public void RefreshQuestions(int quizID)
        {
            Questions = new ObservableCollection<Question>();
            var ids = QuestionRepository.GetQuestionsByQuizId(quizID);
            foreach (var id in ids) 
                Questions.Add(id);
        }

        public void RefreshAnswers(int questionID)
        {
            Answers = new ObservableCollection<Answer>();
            var ids = AnswerRepository.GetAnswersByQuestionId(questionID);
            foreach (var id in ids) 
                Answers.Add(id);
        }

        public bool UpdateQuiz(Quiz quiz)
        {
            if(QuizRepository.UpdateQuiz(quiz))
            {
                return true;
            }
            return false;
        }

        public bool UpdateQuestion(Question question)
        {
            if (QuestionRepository.UpdateQuestion(question))
            {
                return true;
            }
            return false;
        }

        public bool UpdateAnswer(Answer answer)
        {
            if (AnswerRepository.UpdateAnswer(answer))
            {
                return true;
            }
            return false;
        }
    }
}
