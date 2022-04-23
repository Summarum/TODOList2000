using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList2000
{
    internal class ModelData
    {
        private DateTime todoDate;
        private List<Boolean> isChecked;
        private List<int> todoID;
        private List<string> todoText;

        public ModelData() {
            isChecked = new List<Boolean>();
            todoID = new List<int>();
            todoText = new List<string>();
        }

        public DateTime TodoDate { get => todoDate; set => todoDate = value; }
        public List<bool> IsChecked { get => isChecked; set => isChecked = value; }
        public List<int> TodoID { get => todoID; set => todoID = value; }
        public List<string> TodoText { get => todoText; set => todoText = value; }
    }
}
