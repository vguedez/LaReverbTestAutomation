using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace TestFramework.Pages
{
    public class NavigationPage
    {
        [FindsBy(How = How.LinkText, Using = "Regístrate")]
        private IWebElement RegisterLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a/strong[text()='Accede']")]
        private IWebElement LogInLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/site/logout']")]
        private IWebElement LogOutLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/user/dashboard']")]
        private IWebElement DashboardLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='alertMessage' and text()='Usuario o contraseña inválida']")]
        private IWebElement InvalidLoginMessage { get; set; }

        public void GoToDashboard()
        {
            DashboardLink.Click();
        }

        public void DisplayLogIn()
        {
            Browser.WaitForElements(new List<IWebElement>() { LogInLink });
            LogInLink.Click();
        }

        public void LogOut()
        {
            if (LogOutLink.Displayed)
                LogOutLink.Click();
        }

        public bool IsLoggedIn()
        {
            try
            {
                return LogOutLink.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            
        }

        public bool LoggedInAsRegisteredUser()
        {
            Browser.WaitForElements(new List<IWebElement>() { LogOutLink });

            if (!LogOutLink.Displayed)
                return false;

            return true;
        }

        public bool InvalidLoginAttempt()
        {
            return InvalidLoginMessage.Displayed;
        }
    }
}
