using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securiton.Utilities
{
    public class JsonUtils
    {

        public static object[] GetJsonIntoObjectArray(string jsonPath, string key)
        {
            StreamReader reader = new StreamReader(jsonPath);
            string text = reader.ReadToEnd();

            Console.WriteLine(text);

            dynamic? json = JsonConvert.DeserializeObject(text);

            object[] allData = new object[json?[key].Count];

            //print all the values
            for (int i = 0; i < json?[key].Count; i++) //number of testcase
            {
                object[] data = new object[json[key][0].Count];

                for (int j = 0; j < json[key][i].Count; j++) //number of test data
                {
                    data[j] = json[key][i][j];
                }
                allData[i] = data;
            }

            return allData;
        }

    }
}
