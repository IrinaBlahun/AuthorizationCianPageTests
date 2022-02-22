using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationCianPageTests.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _SingInButton = By.XPath("//span[normalize-space(text()) = 'Войти']");
        private readonly By _userLogin = By.XPath("//span[@class='c-header-user-login-full']");
        private readonly By _personalAccountButton = By.XPath("");


        public MainMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AuthorizationPageObject SignIn()
        {
            _webDriver.FindElement(_SingInButton).Click();

            return new AuthorizationPageObject(_webDriver);
        }

        public string GetUserLogin()
        {
            string userLogin = _webDriver.FindElement(_userLogin).Text;
            return userLogin;
        }

        public PersonalAccountPageObject GoToPersonalAccount()
        {
            WaitUntil.WaitElement(_webDriver, _personalAccountButton);
            _webDriver.FindElement(_personalAccountButton).Click();

            return new PersonalAccountPageObject(_webDriver);
        }
    }
}
