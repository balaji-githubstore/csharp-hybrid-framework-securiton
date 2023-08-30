using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo5.HealthRecordAutomation
{
    public class Demo5Json
    {
        [Test]
        public void Demo()
        {
            
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(5.2, 5);
                Assert.AreEqual(3.9, 3.0);
            });

            Console.WriteLine("done");
        }
        [Test]
        public void ExtentReportDemo()
        {
            //only once for the entire session - [OneTimeSetup]
            var extent = new ExtentReports();
            var spark = new ExtentHtmlReporter("Spark.html");
            extent.AttachReporter(spark);

            //before each [Test] method 
            ExtentTest test= extent.CreateTest("MyFirstTest");

            //[Test]
            test.Log(Status.Info, "Entered username");
            test.Log(Status.Info, "Entered password");

            //after each [Test] method 
            test.Log(Status.Pass, "This is a logging event for MyFirstTest, and it passed!");
            
            
            //at the end - [OneTimeTearDown]
            extent.Flush();
        }


        [Test]
        public void ReadJSonDemo()
        {
            StreamReader reader = new StreamReader("C:\\Mine\\Company\\Securiton\\HealthRecordAutomationSln\\HealthRecordAutomation\\TestData\\data.json");
            string text = reader.ReadToEnd();

            Console.WriteLine(text);

            dynamic json = JsonConvert.DeserializeObject(text);

            Console.WriteLine(json["browser"]);

            Console.WriteLine(json["validLoginData"]);
            Console.WriteLine(json["validLoginData"][0]);

            //total number of test case
            Console.WriteLine(json["validLoginData"].Count);
            Console.WriteLine(json["validLoginData"][0][0]);

            //total number of test data - arguments
            Console.WriteLine(json["validLoginData"][0].Count);
        }

        [Test]
        public void ReadJSonDemo2()
        {
            StreamReader reader = new StreamReader("C:\\Mine\\Company\\Securiton\\HealthRecordAutomationSln\\HealthRecordAutomation\\TestData\\data.json");
            string text = reader.ReadToEnd();

            Console.WriteLine(text);

            dynamic json = JsonConvert.DeserializeObject(text);

            object[] allData = new object[json["validLoginData"].Count];

            //print all the values
            for(int i = 0; i < json["validLoginData"].Count; i++) //number of testcase
            {
                object[] data = new object[json["validLoginData"][0].Count];

                for (int j = 0;j< json["validLoginData"][i].Count; j++) //number of test data
                {
                    Console.WriteLine(json["validLoginData"][i][j]);
                    data[j] = json["validLoginData"][i][j];
                }
                allData[i]=data;
            }
        }
    }
}
