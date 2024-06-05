using App.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    using App.DAL.Entities;
    using App.DAL.Repositories;
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
            questions = model.Questions;
            answers = model.Answers;
        }

        private void refreshAnswers()
        {
            currentAnswer = null;
            answers.Clear();
            if (currentQuestion != null)
            {
                foreach (var answer in AnswerRepository.GetAnswersByQuestionId(currentQuestion.Id))
                    answers.Add(answer);
            }
            else
            {
                foreach (var answer in AnswerRepository.GetAllAnswers())
                    answers.Add(answer);
            }
        }
        private void refreshQuestions()
        {
            currentQuestion = null;
            questions.Clear();
            if (currentQuiz != null)
            {
                foreach (var question in QuestionRepository.GetQuestionsByQuizId(currentQuiz.Id))
                    questions.Add(question);
            }
            else
            {
                foreach (var question in QuestionRepository.GetAllQuestions())
                    questions.Add(question);
            }
        }

        private void refreshQuizes()
        {
            currentQuiz = null;
            quizes.Clear();
            foreach (var quiz in QuizRepository.GetAllQuizes())
                quizes.Add(quiz);
        }

        #region Właściwości

        public Quiz CurrentQuiz
        {
            get { return currentQuiz; }
            set
            {
                currentQuiz = value;
                onPropertyChanged(nameof(CurrentQuiz));
                refreshQuestions();
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
                refreshAnswers();
                
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
                            refreshQuizes();
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
                            refreshQuestions();
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
                            refreshAnswers();
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
