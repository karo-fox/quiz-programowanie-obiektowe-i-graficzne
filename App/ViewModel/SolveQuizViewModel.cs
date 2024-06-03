using App.DAL.Entities;
using App.Model;
using App.ViewModel.BaseClasses;
using Org.BouncyCastle.Asn1.X509;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Input;
using System.Windows.Threading;

namespace App.ViewModel
{
    class SolveQuizViewModel : ViewModelBase
    {
        private QuizSolver quizSolver;
        private QuestionSolver questionSolver;
        private string quizName = "";
        private string questionText = "";
        private string questionNoText = "";
        private int points = 0;
        private int currentQuestionIdx = 0;
        private int length;
        private string currentTime;
        private DispatcherTimer timer;
        private DateTime startTime;

        public SolveQuizViewModel()
        {
            quizSolver = new QuizSolver(QuizSelector.Instance.Selected);
            length = quizSolver.Length;
            questionSolver = new QuestionSolver(quizSolver.CurrentQuestion);
            timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, args) => CurrentTime = (DateTime.Now - startTime).ToString(@"mm\:ss");
            startTime = DateTime.Now;
            timer.Start();
        }

        public string QuizName
        {
            get
            {
                return quizSolver.Quiz.Name;
            }
            set
            {
                quizName = value;
                onPropertyChanged(nameof(QuizName));
            }
        }

        public string QuestionText
        {
            get
            {
                return quizSolver.CurrentQuestion.Text;
            }
            set
            {
                questionText = value;
                onPropertyChanged(nameof(QuestionText));
            }
        }

        public string QuestionNoText
        {
            get
            {
                return $"{currentQuestionIdx + 1} / {length}";
            }
            set
            {
                questionNoText = value;
                onPropertyChanged(nameof(QuestionNoText));
            }
        }

        public ObservableCollection<Answer> Answers
        {
            get
            {
                return questionSolver.GetAllAnswers();
            }
            set
            {
                _ = value;
                onPropertyChanged(nameof(Answers));
            }
        }

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
                onPropertyChanged(nameof(Points));
            }
        }

        private bool checked1, checked2, checked3, checked4 = false;
        public bool Checked1
        {
            get
            {
                return checked1;
            }
            set
            {
                checked1 = value;
                onPropertyChanged(nameof(Checked1));
            }
        }

        public bool Checked3
        {
            get
            {
                return checked3;
            }
            set
            {
                checked3 = value;
                onPropertyChanged(nameof(Checked3));
            }
        }

        public bool Checked2
        {
            get
            {
                return checked2;
            }
            set
            {
                checked2 = value;
                onPropertyChanged(nameof(Checked2));
            }
        }

        public bool Checked4
        {
            get
            {
                return checked4;
            }
            set
            {
                checked4 = value;
                onPropertyChanged(nameof(Checked4));
            }
        }

        private bool isNextQuestionEnabled = true;
        public bool IsNextQuestionEnabled
        {
            get
            {
                return currentQuestionIdx + 1 < length;
            }
            set
            {
                isNextQuestionEnabled = currentQuestionIdx + 1 < length;
                onPropertyChanged(nameof(IsNextQuestionEnabled));
            }
        }

        public string CurrentTime
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value;
                onPropertyChanged(nameof(CurrentTime));
            }
        }

        private int tabIndex = 0;
        public int TabIndex
        {
            get
            {
                return tabIndex;
            }
            set
            {
                tabIndex = value;
                onPropertyChanged(nameof(TabIndex));
            }
        }

        private ICommand reloadQuizSolver = null;
        public ICommand ReloadQuizSolver
        {
            get
            {
                if (reloadQuizSolver == null)
                {
                    reloadQuizSolver = new RelayCommand(_ =>
                    {
                        this.quizSolver = new QuizSolver(QuizSelector.Instance.Selected);
                        questionSolver = new QuestionSolver(quizSolver.CurrentQuestion);
                        Points = 0;
                        currentQuestionIdx = 0;
                        length = quizSolver.Length;
                        QuizName = quizSolver.Quiz.Name;
                        QuestionText = quizSolver.CurrentQuestion.Text;
                        QuestionNoText = $"{currentQuestionIdx + 1} / {length}";
                        Answers = questionSolver.GetAllAnswers();
                        IsNextQuestionEnabled = currentQuestionIdx + 1 < length;

                        Checked1 = false;
                        Checked2 = false;
                        Checked3 = false;
                        Checked4 = false;

                        startTime = DateTime.Now;
                        timer.Start();

                        TabIndex = 1;
                    },
                    _ => true);
                }
                return reloadQuizSolver;
            }
        }

        private ICommand nextQuestion = null;
        public ICommand NextQuestion
        {
            get
            {
                if (nextQuestion == null)
                {
                    nextQuestion = new RelayCommand(
                        _ =>
                        {
                            bool[] checkList = [Checked1, Checked2, Checked3, Checked4];
                            foreach (Answer answer in Answers.Where(answer => checkList[Answers.IndexOf(answer)]))
                            {
                                questionSolver.SelectAnswer(answer.Id);
                            }
                            if (questionSolver.IsCorrect())
                            {
                                Points++;
                            }
                            currentQuestionIdx++;
                            quizSolver.NextQuestion();

                            questionSolver = new QuestionSolver(quizSolver.CurrentQuestion);
                            QuestionText = quizSolver.CurrentQuestion.Text;
                            QuestionNoText = $"{currentQuestionIdx + 1} / {length}";
                            Answers = questionSolver.GetAllAnswers();
                            IsNextQuestionEnabled = currentQuestionIdx + 1 < length;

                            Checked1 = false;
                            Checked2 = false;
                            Checked3 = false;
                            Checked4 = false;
                        },
                        _ => currentQuestionIdx + 1 < length);
                }
                return nextQuestion;
            }
        }

        private ICommand endQuiz = null;
        public ICommand EndQuiz
        {
            get
            {
                if (endQuiz == null)
                {
                    endQuiz = new RelayCommand(
                    _ =>
                    {
                        timer.Stop();
                        TabIndex = 2;
                    },
                    _ => true
                        );
                }
                return endQuiz;
            }
        }
    }
}
