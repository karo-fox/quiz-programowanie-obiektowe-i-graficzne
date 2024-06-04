using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    using App.Model;
    internal class MainViewModel
    {
        private CreatorModel cmodel = new CreatorModel();
        private EditorModel emodel = new EditorModel();
        public TabCreateQuizViewModel TabCreateQuizVM { get; set; }
        public TabEditQuizViewModel TabEditQuizVM { get; set; }
        public SelectQuizViewModel SelectQuizVM { get; set; }
        public SolveQuizViewModel SolveQuizVM { get; set; }
        public MainViewModel() 
        {
            TabCreateQuizVM = new TabCreateQuizViewModel(cmodel);
            TabEditQuizVM = new TabEditQuizViewModel(emodel);
            SelectQuizVM = new SelectQuizViewModel();
            SolveQuizVM = new SolveQuizViewModel();
        }
    }
}
