using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework;
using TestFramework.Pages;

namespace TestAutomation
{
    [TestClass]
    public class Login
    {
        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            Browser.Initialize();
        }

        [TestMethod]
        public void CantLoginWithInvalidCredentials()
        {
            Pages.Login.GoTo();
            Pages.Login.InvalidLogIn();

            Assert.IsTrue(Pages.Navigation.InvalidLoginAttempt());
        }

        [TestMethod]
        public void CanLogin()
        {
            Pages.Login.GoTo();
            Pages.Login.LogIn();

            Assert.IsTrue(Pages.Navigation.LoggedInAsRegisteredUser());

            Pages.Navigation.LogOut();
        }

        [ClassCleanup()]
        public static void TearDown()
        {
            Browser.Close();
        }
    }
}
