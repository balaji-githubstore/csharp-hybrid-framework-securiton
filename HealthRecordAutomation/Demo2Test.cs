using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.HealthRecordAutomation
{
    [TestFixture("ch")]
    [TestFixture("edge")]
    [Parallelizable(ParallelScope.All)]
    public class Demo2Test
    {
        IWebDriver driver;
        readonly string browser;

        public Demo2Test(string browser)
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
        public void T2() {
            Thread.Sleep(5000);
            Console.WriteLine(driver.Title);
            driver.Quit();
        }
    }
}
