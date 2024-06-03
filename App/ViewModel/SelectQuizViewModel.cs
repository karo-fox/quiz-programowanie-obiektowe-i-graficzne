using App.DAL.Entities;
using App.Model;
using App.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App.ViewModel
{
    class SelectQuizViewModel : ViewModelBase
    {
        private Quiz selected = QuizSelector.Instance.Selected;

        public Quiz Selected
        {
            get { return QuizSelector.Instance.Selected; }
            set {
                if (value != null)
                {
                    selected = value;
                    QuizSelector.Instance.SelectQuiz((int)selected.Id);
                    onPropertyChanged(nameof(Selected));
                }

            }
        }

        public ObservableCollection<Quiz> Quizes 
        { 
            get 
            { 
                return QuizSelector.Instance.Quizes; 
            }
            set
            {
                _ = value;
                onPropertyChanged(nameof(Quizes));
            }
        }

        private ICommand reloadQuizesList = null;

        public ICommand ReloadQuizesList
        {
            get
            {
                if (reloadQuizesList == null)
                {
                    reloadQuizesList = new RelayCommand(_ => 
                    {
                        Quizes = QuizSelector.Instance.Quizes;
                    }, _ => true);
                }
                return reloadQuizesList;
            }
        }
    }
}