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
        public ObservableCollection<int> QuestionIds { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<int> QuizIds { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<int> AnswerIds { get; set; } = new ObservableCollection<int>();
        public EditorModel() 
        { 
            
        }
        
        public void RefreshQuestions(int quizID)
        {
            QuestionIds = new ObservableCollection<int>();
            var ids = QuestionRepository.GetQuestionIdByQuizId(quizID);
            foreach (var id in ids) 
                QuestionIds.Add(id);
        }

        public void RefreshAnswers(int questionID)
        {
            AnswerIds = new ObservableCollection<int>();
            var ids = AnswerRepository.GetAnswersIdByQuestionId(questionID);
            foreach (var id in ids) 
                AnswerIds.Add(id);
        }
    }
}
