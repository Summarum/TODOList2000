using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace TODOList2000
{
    internal class FileReader
    {
        public string[] readFile(string fileName) {
            string[] lines = System.IO.File.ReadAllLines(fileName);


            return lines;
        }
        public void saveTodoList(List<ModelData> list) {
            string jsonser = JsonSerializer.Serialize(list);
            ModelData tempData = new ModelData();
            File.WriteAllText("file.txt", jsonser);



        }

        public void testtodofun() {
            List<ModelData> tempList = new List<ModelData>();
            ModelData tempData = new ModelData();
            tempData.TodoDate = DateTime.Now;
            tempData.IsChecked.Add(false);
            tempData.IsChecked.Add(false);
            tempData.TodoID.Add(0);
            tempData.TodoID.Add(1);
            tempData.TodoText.Add("first one");
            tempData.TodoText.Add("secondone");
            tempList.Add(tempData);

            tempData = new ModelData();
            tempData.TodoDate = DateTime.Now;
            tempData.IsChecked.Add(false);
            tempData.IsChecked.Add(false);
            tempData.TodoID.Add(2);
            tempData.TodoID.Add(3);
            tempData.TodoText.Add("third one");
            tempData.TodoText.Add("fourth");
            tempList.Add(tempData);
            saveTodoList(tempList);

        }

        public List<ModelData> buildTodoList(string[] lines) { 
            List <ModelData> tempList = new List<ModelData>();
            ModelData tempData;

            for (int i = 0; i < lines.Length; i++) {
                



            }
        
           return tempList;
        }




    }
}
