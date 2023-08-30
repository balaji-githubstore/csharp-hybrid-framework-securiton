using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Securiton.Base
{
    public class AutomationWrapper
    {
        protected IWebDriver driver;
        private static ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void Start()
        {
            if(extent == null)
            {
                extent = new ExtentReports();
                var spark = new ExtentHtmlReporter("Spark.html");
                extent.AttachReporter(spark);
            }
        }

        [OneTimeTearDown]
        public void End()
        {
            extent.Flush();
        }


        [SetUp]
        public void Setup()
        {
             test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            driver = new ChromeDriver("C:\\Users\\Balaji_Dinakaran\\.cache\\selenium\\chromedriver\\win64\\116.0.5845.96");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            //driver.Url = "https://demo.openemr.io/b/openemr";
            driver.Url = "https://google.com";
        }

        [TearDown]
        public void TearDown()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;

            if (testStatus == TestStatus.Failed)
            {
                //TestContext.CurrentContext.Test.FullName
                //write to text file-
                string stackTrace = TestContext.CurrentContext.Result.StackTrace;
                string message = TestContext.CurrentContext.Result.Message;


                test.Log(Status.Fail, "Failed " + stackTrace + "</pre>" + message);

                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();

                test.AddScreenCaptureFromBase64String(screenshot.AsBase64EncodedString);
            }
            else if (testStatus == TestStatus.Passed)
            {
                test.Log(Status.Pass, "Passed - Snapshot Below");
            }
            else
            {
                test.Log(Status.Skip, "MyFirstTestCasePassed");
            }


            driver.Quit();
        }

    }
}
