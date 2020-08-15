using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TestFramework;
using TestFramework.Pages;

namespace TestAutomation
{
    [TestClass()]
    public class Login
    {
        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            Browser.Initialize();
        }

        [TestMethod]
        public void CanLogin()
        {
            Pages.Login.GoTo();
            Pages.Login.LogIn();

            Assert.IsTrue(Pages.Navigation.LoggedInAsRegisteredUser());
        }

        [TestMethod]
        public void CantLoginWithInvalidCredentials()
        {
            Pages.Login.LogOut();
            Pages.Login.GoTo();
            Pages.Login.InvalidLogIn();

            Assert.IsTrue(Pages.Navigation.InvalidLoginAttempt());
        }

        [ClassCleanup()]
        public static void TearDown()
        {
            Browser.Close();
            var chromeAndChomiumProcesses = Process.GetProcessesByName("chrome");
            foreach (var chromeAndChomiumProcess in chromeAndChomiumProcesses)
            {
                chromeAndChomiumProcess.Kill();
            }
        }
    }
}
