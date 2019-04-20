using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using TestFramework.Generators;

namespace TestFramework.Pages
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "LoginForm_username")]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "LoginForm_password")]
        private IWebElement UserPassword { get; set; }

        [FindsBy(How = How.Name, Using = "yt1")]
        private IWebElement LogInButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "close")]
        private IWebElement CloseLogInDialogButton { get; set; }

        public void GoTo()
        {
            Pages.Navigation.DisplayLogIn();
        }

        public void LogIn()
        {
            Browser.WaitForElements(new List<IWebElement>() { UserName, UserPassword, LogInButton });
            UserName.Clear();
            UserPassword.Clear();
            UserName.SendKeys(Browser.getUser());
            UserPassword.SendKeys(Browser.getPassword());

            LogInButton.Click();
        }

        public void InvalidLogIn()
        {
            Browser.WaitForElements(new List<IWebElement>() { UserName, UserPassword, LogInButton });
            UserName.SendKeys(Browser.getUser());
            UserPassword.SendKeys(PasswordGenerator.GetRandomPassword());

            LogInButton.Click();
        }

        public void CloseLoginDialog()
        {
            CloseLogInDialogButton.Click();
        }
    }
}
