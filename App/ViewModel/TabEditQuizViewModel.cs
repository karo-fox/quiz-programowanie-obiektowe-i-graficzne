using App.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    using App.Model;
    internal class TabEditQuizViewModel:ViewModelBase
    {
        private CreatorModel model = null;
        public TabEditQuizViewModel(CreatorModel model)
        {
            this.model = model;
        }
    }
}
