using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestFramework.Pages
{
    public class MusicianProfilePage
    {
        [FindsBy(How = How.Id, Using = "Musician_artistic_name")]
        private IWebElement musicianNameText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_is_singer")]
        private IWebElement musicianIsSingerCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_is_backup_singer")]
        private IWebElement musicianIsBackupSingerCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_is_composer")]
        private IWebElement musicianIsComposerCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_inflluences")]
        private IWebElement musicianProfileText { get; set; }

        [FindsBy(How = How.Id, Using = "showInstruments")]
        private IWebElement showInstrumentsButton { get; set; }

        [FindsBy(How = How.Id, Using = "showAvatarLoad")]
        private IWebElement showAvatarLoadButton { get; set; }

        [FindsBy(How = How.Id, Using = "showGenres")]
        private IWebElement showGenresButton { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_social_network")]
        private IWebElement musicianSocialNetworkText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_gear")]
        private IWebElement musicianGearText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_id_level")]
        private IWebElement musicianLevelText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_music_education")]
        private IWebElement musicianEducationText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_experience")]
        private IWebElement musicianExperienceText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_website")]
        private IWebElement musicianWebsiteText { get; set; }

        [FindsBy(How = How.Id, Using = "postForm")]
        private IWebElement saveMusicianProfileButton { get; set; }
                
        [FindsBy(How = How.XPath, Using = "//div[@id='alert_enter_name']")]
        private IWebElement emptyMusicianNameAlert { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='alert_enter_profile']")]
        private IWebElement emptyMusicianProfileAlert { get; set; }

        public void SetMusicianNameText(string text)
        {
            musicianNameText.Clear();
            musicianNameText.SendKeys(text);
        }

        public void SetMusicianProfileText(string text)
        {
            musicianProfileText.Clear();
            musicianProfileText.SendKeys(text);
        }

        public void SubmitMusicianProfile()
        {
            saveMusicianProfileButton.Click();
        }

        public bool InvalidMusicianNameMessageIsDisplayed()
        {
            return emptyMusicianNameAlert.Displayed;
        }

        public bool InvalidMusicianProfileMessageIsDisplayed()
        {
            return emptyMusicianProfileAlert.Displayed;
        }
    }
}
