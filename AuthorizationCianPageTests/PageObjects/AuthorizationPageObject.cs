using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AuthorizationCianPageTests.PageObjects
{
    class AuthorizationPageObject
    {
        private IWebDriver _webdriver;

        private readonly By _loginInputButton = By.XPath("//input[@name='username']");
        private readonly By _continueButton = By.XPath("//button[@type ='submit']");
        private readonly By _passwordInpudButton = By.XPath("//*[@id='new_password']");
        private readonly By _confirmedPasswordInpudButton = By.XPath("//*[@id='confirmed_password']");
        private readonly By _createButton = By.XPath("//span[normalize-space(text()) = 'Создать аккаунт']");

        public AuthorizationPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }

        public MainMenuPageObject Login(string login, string password)
        {
            _webdriver.FindElement(_loginInputButton).SendKeys(login);
            _webdriver.FindElement(_continueButton).Click();
            Thread.Sleep(100);
            _webdriver.FindElement(_passwordInpudButton).SendKeys(password);
            _webdriver.FindElement(_confirmedPasswordInpudButton).SendKeys(password);
            _webdriver.FindElement(_createButton).Click();

            return new MainMenuPageObject(_webdriver);
        }
    }
}
