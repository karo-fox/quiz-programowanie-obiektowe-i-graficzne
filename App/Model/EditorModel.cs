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
        public ObservableCollection<int> QuestionIds;
        public EditorModel() 
        { 
            
        }
    }
}
