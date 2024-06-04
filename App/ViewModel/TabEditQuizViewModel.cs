using App.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    using App.DAL.Entities;
    using App.Model;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    internal class TabEditQuizViewModel:ViewModelBase
    {
        private EditorModel model = null;
        private Quiz currentQuiz = null;
        private Answer currentAnswer = null;
        private Question currentQuestion = null;
        private ObservableCollection<Quiz> quizes = null;
        private ObservableCollection<Question> questions = null;
        private ObservableCollection<Answer> answers = null;
        public TabEditQuizViewModel(EditorModel model)
        {
            this.model = model;
            quizes = model.Quizes;
            currentQuiz = quizes.First();
            model.RefreshQuestions((int)currentQuiz.Id);
            questions = model.Questions;
            currentQuestion = questions.First();
            Questions = questions;
            model.RefreshAnswers((int)currentQuestion.Id);
            answers = model.Answers;
            currentAnswer = answers.First();
            Answers = answers;
        }

        #region Właściwości

        public Quiz CurrentQuiz
        {
            get { return currentQuiz; }
            set
            {
                currentQuiz = value;
                onPropertyChanged(nameof(CurrentQuiz));
                model.RefreshQuestions((int)currentQuiz.Id);
                questions = model.Questions;
                currentQuestion = questions.First();
                //Questions = questions;
            }
        }
        
        public Answer CurrentAnswer
        {
            get { return currentAnswer; }
            set
            {
                currentAnswer = value;
                onPropertyChanged(nameof(CurrentAnswer));
            }
        }
        public Question CurrentQuestion
        { 
            get { return currentQuestion; }
            set 
            { 
                currentQuestion = value;
                onPropertyChanged(nameof(CurrentQuestion));
                model.RefreshAnswers((int)currentQuestion.Id);
                answers = model.Answers;
                currentAnswer = answers.First();
                Answers = answers;
            }
        }
        public ObservableCollection<Quiz> Quizes
        {
            get { return quizes; }
            set 
            { 
                quizes = value;
                onPropertyChanged(nameof(Quizes));
            }
        }
        public ObservableCollection<Question> Questions
        { 
            get { return questions; }
            set 
            { 
                questions = value;
                onPropertyChanged(nameof(Questions)); 
            }
        }
        public ObservableCollection<Answer> Answers
        { 
            get { return answers; }
            set 
            { 
                answers = value;
                onPropertyChanged(nameof(Answers));
            }
        }

        #endregion

        #region Polecenia

        private ICommand updateQuiz = null;
        public ICommand UpdateQuiz
        {
            get
            {
                if (updateQuiz == null)
                    updateQuiz = new RelayCommand(
                        arg =>
                        {
                            model.UpdateQuiz(currentQuiz);
                            //ClearNewQuiz();
                        }
                        ,
                        arg => (currentQuiz != null)
                        );
                return updateQuiz;
            }
        }

        private ICommand updateQuestion = null;
        public ICommand UpdateQuestion
        {
            get
            {
                if (updateQuestion == null)
                    updateQuestion = new RelayCommand(
                        arg =>
                        {
                            model.UpdateQuestion(currentQuestion);
                            //ClearNewQuiz();
                        }
                        ,
                        arg => (currentQuestion != null)
                        );
                return updateQuestion;
            }
        }

        private ICommand updateAnswer = null;
        public ICommand UpdateAnswer
        {
            get
            {
                if (updateAnswer == null)
                    updateAnswer = new RelayCommand(
                        arg =>
                        {
                            model.UpdateAnswer(currentAnswer);
                            //currentAnswer = null;
                        }
                        ,
                        arg => (currentAnswer != null)
                        );
                return updateAnswer;
            }
        }

        #endregion
    }
}
