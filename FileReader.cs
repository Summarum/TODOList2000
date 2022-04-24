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
    }
}
