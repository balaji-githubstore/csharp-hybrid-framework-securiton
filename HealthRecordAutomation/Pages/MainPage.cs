using OpenQA.Selenium;
using Securiton.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecordAutomation.Pages
{
    public class MainPage : WebDriverKeywords
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver):base(driver) 
        {
            this.driver = driver;
        }

        public void ClickOnPatient()
        {
            driver.FindElement(By.XPath("")).Click();   
        }

        public string MainPageTitle
        {
            get { return driver.Title; }
        }
    }
}
