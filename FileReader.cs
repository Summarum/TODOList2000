using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList2000
{
    internal class FileReader
    {
        public string[] readFile(string fileName) {
            string[] lines = System.IO.File.ReadAllLines(fileName);


            return lines;
        }

        public List<ModelData> buildTodoList(string[] lines) { 
            List <ModelData> tempList = new List<ModelData>();
            
        
           return tempList;
        }




    }
}
