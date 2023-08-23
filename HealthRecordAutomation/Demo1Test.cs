using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.HealthRecordAutomation
{
    /// <summary>
    /// Will be deleted - not part of the framework
    /// 
    /// </summary>
    public class Demo1Test
    {

        public static object[] LoginData()
        {
            object[] data1 = new object[2];
            data1[0] = "saul";
            data1[1] = "saul123";

            object[] data2=new object[2];
            data2[0] = "peter";
            data2[1] = "peter123";

            object[] data3=new object[2];
            data3[0] = "kim";
            data3[1] = "kim122";

            object[] allData=new object[3]; //number of test case
            allData[0] = data1;
            allData[1] = data2;
            allData[2] = data3;

            return allData;
        }

        [Test,TestCaseSource(nameof(LoginData))]
        public void LoginTest(string user,string password)
        {
            Console.WriteLine(user+password);
        }

    }
}






