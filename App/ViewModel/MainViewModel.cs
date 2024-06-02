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
        private CreatorModel model = new CreatorModel();
        public TabCreateQuizViewModel TabCreateQuizVM { get; set; }
        public TabEditQuizViewModel TabEditQuizVM { get; set;}
        public MainViewModel() 
        {
            TabCreateQuizVM = new TabCreateQuizViewModel(model);
            TabEditQuizVM = new TabEditQuizViewModel(model);
        }
    }
}
