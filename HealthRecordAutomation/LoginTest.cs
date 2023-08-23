using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Securiton.Base;
using OpenQA.Selenium.Support.UI;

namespace Securiton.HealthRecordAutomation
{
    public class LoginTest : AutomationWrapper
    {
        
        [Test]
        public void ValidLoginTest()
        {
            driver.FindElement(By.Id("authUser")).SendKeys("physician");
            driver.FindElement(By.CssSelector("#clearPass")).SendKeys("physician");
            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.CssSelector("select[name='languageChoice']")));
            selectLanguage.SelectByText("English (Indian)");
            driver.FindElement(By.Id("login-button")).Click();

            //wait for page load to complete 
            Assert.That(driver.Title, Is.EqualTo("OpenEMR"));
        }

        [Test]
        public void InvalidLoginTest()
        {
            driver.FindElement(By.Id("authUser")).SendKeys("john");
            driver.FindElement(By.CssSelector("#clearPass")).SendKeys("john123");
            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.CssSelector("select[name='languageChoice']")));
            selectLanguage.SelectByText("English (Indian)");
            driver.FindElement(By.Id("login-button")).Click();

            string actualError= driver.FindElement(By.XPath("//p[contains(text(),'Invalid')]")).Text;

            //assert the error Invalid username or password
            Assert.True(actualError.Contains("invalid username"),
                "Assertion on Error message - actual error: "+actualError);
        }

    }
}
