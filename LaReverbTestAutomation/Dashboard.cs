using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TestFramework;
using TestFramework.Pages;

namespace TestAutomation
{
    [TestClass()]
    public class Dashboard
    {
        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            Browser.Initialize();
            Pages.Login.GoTo();
            Pages.Login.LogIn();
            Pages.Dashboard.GoTo();
        }

        [TestMethod]
        public void TestDashboardLinks()
        {
            Assert.IsTrue(Pages.Dashboard.ProfileLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.GalleryLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.VideosLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.AdsLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.MessagesLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.ContactsLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.SettingsLinkIsPresent());
        }

        [ClassCleanup()]
        public static void TearDown()
        {
            Browser.Close();
        }
    }
}
