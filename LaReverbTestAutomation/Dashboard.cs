using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework;
using TestFramework.Pages;

namespace TestAutomation
{
    [TestClass]
    public class Dashboard
    {
        [TestMethod]
        public void CheckDashboardLinks()
        {
            Browser.Initialize();

            Pages.Login.GoTo();
            Pages.Login.LogIn();
            Pages.Dashboard.GoTo();

            Assert.IsTrue(Pages.Dashboard.ProfileLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.GalleryLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.VideosLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.AdsLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.MessagesLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.ContactsLinkIsPresent());
            Assert.IsTrue(Pages.Dashboard.SettingsLinkIsPresent());

            Browser.Close();
        }
    }
}
