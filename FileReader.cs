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
        public List<ModelData> readFile(string fileName) {
            List<ModelData> tempList = new List<ModelData>();
            string lines = System.IO.File.ReadAllText(fileName);
            tempList = JsonSerializer.Deserialize<List<ModelData>>(lines);

            return tempList;
        }

        public void saveTodoList(List<ModelData> list,string fileName) {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonser = JsonSerializer.Serialize(list,options);
            ModelData tempData = new ModelData();
            File.WriteAllText(fileName, jsonser);

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
            tempData.TodoText.Add("test with śćż");
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
            saveTodoList(tempList,"file.txt");

        }






    }
}
