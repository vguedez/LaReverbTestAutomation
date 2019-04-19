using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestFramework.Pages
{
    public class DashboardPage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='/musician/update']")]
        private IWebElement profileLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/gallery']")]
        private IWebElement galleryLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/videos']")]
        private IWebElement videosLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/post/?bas=1']")]
        private IWebElement adsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/messages']")]
        private IWebElement messagesLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/contacts']")]
        private IWebElement contactsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/settings']")]
        private IWebElement settingsLink { get; set; }

        public void GoTo()
        {
            Pages.Navigation.GoToDashboard();
        }

        public void GoToProfile()
        {
            profileLink.Click();
        }

        public bool ProfileLinkIsPresent()
        {
            return profileLink.Displayed;
        }

        public bool GalleryLinkIsPresent()
        {
            return galleryLink.Displayed;
        }

        public bool VideosLinkIsPresent()
        {
            return videosLink.Displayed;
        }

        public bool AdsLinkIsPresent()
        {
            return adsLink.Displayed;
        }

        public bool MessagesLinkIsPresent()
        {
            return messagesLink.Displayed;
        }

        public bool ContactsLinkIsPresent()
        {
            return contactsLink.Displayed;
        }

        public bool SettingsLinkIsPresent()
        {
            return settingsLink.Displayed;
        }
    }
}
