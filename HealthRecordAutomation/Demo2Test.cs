using HealthRecordAutomation;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.HealthRecordAutomation
{

    public class MyFixtureData1
    {
        public static IEnumerable FixtureParams1
        {
            get
            {
                yield return new Demo2TestFixture("ch");
                //yield return new Demo2TestFixture("edge");
                //yield return new Demo2TestFixture("ff");
            }
        }
    }


    //[TestFixture("ch")]
    //[TestFixture("edge")]
    //[Parallelizable(ParallelScope.All)]
    [TestFixtureSource(typeof(MyFixtureData1), nameof(MyFixtureData1.FixtureParams1))]
    public class Demo2TestFixture
    {
        IWebDriver driver;
        readonly string browser;

        public Demo2TestFixture(string browser)
        {
            this.browser = browser;
        }


        [SetUp]
        public void Setup()
        {
           
            if(browser.Equals("ch"))
            {
                driver = new ChromeDriver("C:\\Users\\Balaji_Dinakaran\\.cache\\selenium\\chromedriver\\win64\\116.0.5845.96");
            }
            else
            {
                driver = new EdgeDriver("C:\\Users\\Balaji_Dinakaran\\.cache\\selenium\\msedgedriver\\win64\\116.0.1938.54");

            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.openemr.io/b/openemr";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void T1()
        {
            Thread.Sleep(5000);
            Console.WriteLine(driver.Title);
            driver.Quit();
        }

        [Test]
        public void T2([Random(23333, 99999, 5)] double d) {
            Thread.Sleep(5000);
            Console.WriteLine(driver.Title);
            driver.Quit();
        }
    }
}
