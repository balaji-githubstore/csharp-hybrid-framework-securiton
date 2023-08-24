using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecordAutomation
{
    [Parallelizable(ParallelScope.All)]
    public class Demo3Grid
    {
       static IWebDriver driver;

        [Test]
        public void ConnectNode1Test()
        {
            ChromeOptions options = new ChromeOptions();
             driver = new RemoteWebDriver(new Uri("http://192.168.202.202:4444"), options);

            driver.Url = "https://github.com/";
            Console.WriteLine(driver.Title);
            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        public void ConnectNode2Test()
        {
            ChromeOptions options = new ChromeOptions();
             driver = new RemoteWebDriver(new Uri("http://192.168.202.202:4444"), options);

            driver.Url = "https://github.com/";
            Console.WriteLine(driver.Title);
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
