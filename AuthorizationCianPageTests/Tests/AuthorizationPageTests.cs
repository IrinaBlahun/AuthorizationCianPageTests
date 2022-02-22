using AuthorizationCianPageTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace AuthorizationCianPageTests
{
    public class AuthorizationPageTests
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Navigate().GoToUrl("https://realt.by");
            _webDriver.Manage().Window.Maximize();

        }

        [Test]
        public void LoginAsUser_StandartBehavior_Logined()
        {

            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu
                .SignIn()
                .Login(UserNameForTest.StartLogin, UserNameForTest.StarLoginPssword);

            Thread.Sleep(1000);
            string actualLogin = mainMenu.GetUserLogin();

            Assert.AreEqual(UserNameForTest.UserLogin, actualLogin, "Login is wrong");
        }

        [TearDown]
        public void TaerDown()
        {
            _webDriver.Quit();
        }

    }
}