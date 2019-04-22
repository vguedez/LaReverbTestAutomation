using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestFramework.Pages
{
    public class DashboardPage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='/musician/update']")]
        private IWebElement ProfileLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/gallery']")]
        private IWebElement GalleryLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/videos']")]
        private IWebElement VideosLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/post']")]
        private IWebElement AdsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/messages']")]
        private IWebElement MessagesLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/contacts']")]
        private IWebElement ContactsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/settings']")]
        private IWebElement SettingsLink { get; set; }

        public void GoTo()
        {
            Pages.Navigation.GoToDashboard();
        }

        public void GoToProfile()
        {
            ProfileLink.Click();
        }

        public void GoToAds()
        {
            AdsLink.Click();
        }

        public bool ProfileLinkIsPresent()
        {
            return ProfileLink.Displayed;
        }

        public bool GalleryLinkIsPresent()
        {
            return GalleryLink.Displayed;
        }

        public bool VideosLinkIsPresent()
        {
            return VideosLink.Displayed;
        }

        public bool AdsLinkIsPresent()
        {
            return AdsLink.Displayed;
        }

        public bool MessagesLinkIsPresent()
        {
            return MessagesLink.Displayed;
        }

        public bool ContactsLinkIsPresent()
        {
            return ContactsLink.Displayed;
        }

        public bool SettingsLinkIsPresent()
        {
            return SettingsLink.Displayed;
        }
    }
}
