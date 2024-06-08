using App.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    using App.DAL.Repositories;
    using App.Model;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using System.Windows.Input;

    internal class TabCreateQuizViewModel:ViewModelBase
    {
        private CreatorModel model = null;

        private string currentQuizName, newQuizName, question, ans1, ans2, ans3, ans4;
        private bool bans1, bans2, bans3, bans4;
        private ObservableCollection<String> quizNames = null;
        public TabCreateQuizViewModel(CreatorModel m)
        {
            model = m;
            quizNames = model.QuizNames;
        }

        #region Właściwości

        public ObservableCollection<String> QuizNames
        {
            get { return quizNames; }
            set
            {
                quizNames = value;
                onPropertyChanged(nameof(QuizNames));
            }
        }

        public string CurrentQuizName
        {
            get { return currentQuizName; }
            set
            {
                currentQuizName = value;
                onPropertyChanged(nameof(CurrentQuizName)); 
            }
        }
        public string NewQuizName
        {  
            get { return newQuizName; }
            set 
            { 
                newQuizName = value;
                onPropertyChanged(nameof(NewQuizName));
            }
        }

        public string Question
        {
            get { return question; }
            set
            {
                question = value;
                onPropertyChanged(nameof(Question));
            }
        }

        public string Ans1
        {
            get { return ans1; }
            set
            {
                ans1 = value;
                onPropertyChanged(nameof(Ans1));
            }
        }

        public string Ans2
        {
            get { return ans2; }
            set
            {
                ans2 = value;
                onPropertyChanged(nameof(Ans2));
            }
        }

        public string Ans3
        {
            get { return ans3; }
            set
            {
                ans3 = value;
                onPropertyChanged(nameof(Ans3));
            }
        }

        public string Ans4
        {
            get { return ans4; }
            set
            {
                ans4 = value;
                onPropertyChanged(nameof(Ans4));
            }
        }

        public bool BAns1
        {
            get { return bans1; }
            set
            {
                bans1 = value;
                onPropertyChanged(nameof(BAns1));
            }
        }

        public bool BAns2
        {
            get { return bans2; }
            set
            {
                bans2 = value;
                onPropertyChanged(nameof(BAns2));
            }
        }

        public bool BAns3
        {
            get { return bans3; }
            set
            {
                bans3 = value;
                onPropertyChanged(nameof(BAns3));
            }
        }

        public bool BAns4
        {
            get { return bans4; }
            set
            {
                bans4 = value;
                onPropertyChanged(nameof(BAns4));
            }
        }

        #endregion

        private void ClearNewQuiz()
        {
            NewQuizName = "";
        }
        private void ClearNewQuestion()
        {
            Question = "";
            Ans1 = "";
            Ans2 = "";
            Ans3 = "";
            Ans4 = "";
            BAns1 = false;
            BAns2 = false;
            BAns3 = false;
            BAns4 = false;
        }

        #region Polecenia

        private ICommand dodajQuiz = null;
        
        public ICommand DodajQuiz
        {
            get {
                if (dodajQuiz == null)
                    dodajQuiz = new RelayCommand(
                        arg =>
                        {
                            model.AddQuiz(newQuizName);
                            ClearNewQuiz();
                        }
                        ,
                        arg => (newQuizName != "") && newQuizName != null
                        ); ;
                return dodajQuiz;
            }
        }

        private ICommand dodajPytanie = null;
        public ICommand DodajPytanie
        {
            get
            {
                if (dodajPytanie == null)
                    dodajPytanie = new RelayCommand(
                        arg =>
                        {
                            model.AddQuestion(question, QuizRepository.GetQuizIdByName(currentQuizName), ans1, ans2, ans3, ans4, bans1, bans2, bans3, bans4);
                            ClearNewQuestion();
                        }
                        ,
                        arg => (question != "") && (ans1 != "") && (ans2 != "") && (ans3 != "") && (ans4 != "") && (question != null) && (ans1 != null) && (ans2 != null) && (ans3 != null) && (ans4 != null)
                        );
                return dodajPytanie;
            }
        }


        #endregion
    }
}
