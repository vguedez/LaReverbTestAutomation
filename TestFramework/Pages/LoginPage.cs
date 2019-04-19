using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using TestFramework.Generators;

namespace TestFramework.Pages
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "LoginForm_username")]
        private IWebElement userName { get; set; }

        [FindsBy(How = How.Id, Using = "LoginForm_password")]
        private IWebElement userPassword { get; set; }

        [FindsBy(How = How.Name, Using = "yt1")]
        private IWebElement logInButton { get; set; }

        public void GoTo()
        {
            Pages.Navigation.DisplayLogIn();
        }

        public void LogIn()
        {
            Browser.WaitForElements(new List<IWebElement>() { userName, userPassword, logInButton });
            userName.SendKeys(Browser.getUser());
            userPassword.SendKeys(Browser.getPassword());

            logInButton.Click();
        }

        public void InvalidLogIn()
        {
            Browser.WaitForElements(new List<IWebElement>() { userName, userPassword, logInButton });
            userName.SendKeys(Browser.getUser());
            userPassword.SendKeys(PasswordGenerator.GetRandomPassword());

            logInButton.Click();
        }
    }
}
