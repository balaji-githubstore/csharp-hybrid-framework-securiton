using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Securiton.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securiton.HealthRecordAutomation
{
    
    public class LoginUITest : AutomationWrapper
    {
        [Test,Category("UI"),Category("smoke")]
        public void VerifyTitleTest()
        {
            string actualTitle = driver.Title;
            Assert.That(actualTitle, Is.EqualTo("OpenEMR Login"));
        }

        [Test, Category("UI")]
        public void VerifyPlaceholderTest()
        {
          string actualUserNamePlaceholder=  driver.FindElement(By.Id("authUser")).GetAttribute("placeholder");
          string actualPasswordPlaceholder = driver.FindElement(By.CssSelector("#clearPass"))
                .GetAttribute("placeholder");

            Assert.That(actualUserNamePlaceholder, Is.EqualTo("Username"));
            Assert.That(actualPasswordPlaceholder, Is.EqualTo("Password"));
        }

    }
}
