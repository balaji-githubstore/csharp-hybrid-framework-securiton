using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securiton.Base
{
    public class WebDriverKeywords
    {
        private IWebDriver driver;
        private DefaultWait<IWebDriver> wait;

        public WebDriverKeywords(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(Exception));
        }

        public void ClickByLocator(By locator)
        {
            //driver.FindElement(locator).Click();
          
            wait.Until(x=>x.FindElement(locator)).Click();

        }

        public void TypeByLocator(By locator,string text)
        {
            //driver.FindElement(locator).SendKeys(text);
            wait.Until(x => x.FindElement(locator))
        }

    }
}
