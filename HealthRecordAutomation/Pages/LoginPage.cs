using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Securiton.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securiton.HealthRecordAutomation.Pages
{
    public class LoginPage : WebDriverKeywords
    {
        private By _usernameLocator = By.Id("authUser");
        private By _passwordLocator = By.CssSelector("#clearPass");
        private By _languageLocator = By.CssSelector("select[name='languageChoice']");
        private By _loginLocator = By.Id("login-button");
        private By _errorLocator = By.XPath("//p[contains(text(),'Invalid')]");

        private IWebDriver driver;

        public LoginPage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
        }

        public void EnterUsername(string username)
        {
            //driver.FindElement(_usernameLocator).SendKeys(username);
            base.TypeByLocator(_usernameLocator,username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(_passwordLocator).SendKeys(password);
        }

        public void SelectLanaguageByText(string language)
        {
            SelectElement selectLanguage = new SelectElement
                (driver.FindElement(_languageLocator));
            selectLanguage.SelectByText(language);
        }

        public void ClickOnLogin()
        {
            driver.FindElement(_loginLocator).Click();
        }

        public string GetInvalidErrorMessage()
        {
            return driver.FindElement(_errorLocator).Text;
        }

        public string GetUsernamePlaceholder()
        {
            return driver.FindElement(_usernameLocator).GetAttribute("placeholder");
        }
    }
}
