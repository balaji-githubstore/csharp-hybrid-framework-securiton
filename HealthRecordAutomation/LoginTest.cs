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
        [TestCase("admin","pass","English (Indian)","OpenEMR")]
        [TestCase("accountant", "accountant", "English (Indian)", "OpenEMR")]
        public void ValidLoginTest(string username,string password,string language,string expectedTitle)
        {
            driver.FindElement(By.Id("authUser")).SendKeys(username);
            driver.FindElement(By.CssSelector("#clearPass")).SendKeys(password);
            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.CssSelector("select[name='languageChoice']")));
            selectLanguage.SelectByText(language);
            driver.FindElement(By.Id("login-button")).Click();

            //wait for page load to complete 
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
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
