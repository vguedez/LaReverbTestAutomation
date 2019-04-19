using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace TestFramework.Pages
{
    public class NavigationPage
    {
        [FindsBy(How = How.LinkText, Using = "Regístrate")]
        private IWebElement registerLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a/strong[text()='Accede']")]
        private IWebElement logInLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/site/logout']")]
        private IWebElement logOutLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/user/dashboard']")]
        private IWebElement dashboardLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='alertMessage' and text()='Usuario o contraseña inválida']")]
        private IWebElement invalidLoginMessage { get; set; }

        public void GoToDashboard()
        {
            dashboardLink.Click();
        }

        public void DisplayLogIn()
        {
            logInLink.Click();
        }

        public void LogOut()
        {
            if (logOutLink.Displayed)
                logOutLink.Click();
        }

        public bool IsLoggedIn()
        {
            try
            {
                return logOutLink.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            
        }

        public bool LoggedInAsRegisteredUser()
        {
            Browser.WaitForElements(new List<IWebElement>() { logOutLink });

            if (!logOutLink.Displayed)
                return false;

            return true;
        }

        public bool InvalidLoginAttempt()
        {
            return invalidLoginMessage.Displayed;
        }
    }
}
