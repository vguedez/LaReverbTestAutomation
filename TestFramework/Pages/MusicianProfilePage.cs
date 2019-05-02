using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace TestFramework.Pages
{
    public class MusicianProfilePage
    {
        [FindsBy(How = How.Id, Using = "Musician_artistic_name")]
        private IWebElement MusicianNameText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_is_singer")]
        private IWebElement MusicianIsSingerCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_is_backup_singer")]
        private IWebElement MusicianIsBackupSingerCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_is_composer")]
        private IWebElement MusicianIsComposerCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_inflluences")]
        private IWebElement MusicianProfileText { get; set; }

        [FindsBy(How = How.Id, Using = "showInstruments")]
        private IWebElement ShowInstrumentsButton { get; set; }

        [FindsBy(How = How.Id, Using = "showAvatarLoad")]
        private IWebElement ShowAvatarLoadButton { get; set; }

        [FindsBy(How = How.Id, Using = "showGenres")]
        private IWebElement ShowGenresButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveInstruments")]
        private IWebElement SaveInstrumentsButton { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveGenre")]
        private IWebElement SaveGenreButton { get; set; }
        
        [FindsBy(How = How.Id, Using = "Musician_social_network")]
        private IWebElement MusicianSocialNetworkText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_gear")]
        private IWebElement MusicianGearText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_id_level")]
        private IWebElement MusicianLevelText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_music_education")]
        private IWebElement MusicianEducationText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_experience")]
        private IWebElement MusicianExperienceText { get; set; }

        [FindsBy(How = How.Id, Using = "Musician_website")]
        private IWebElement MusicianWebsiteText { get; set; }

        [FindsBy(How = How.Id, Using = "postForm")]
        private IWebElement SaveMusicianProfileButton { get; set; }
                
        [FindsBy(How = How.XPath, Using = "//div[@id='alert_enter_name']")]
        private IWebElement EmptyMusicianNameAlert { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='alert_enter_profile']")]
        private IWebElement EmptyMusicianProfileAlert { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()[contains(.,'Tu perfil ha sido almacenado')]]")]
        private IWebElement ProfileSavedMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and starts-with(@id,'instrument_')]")]
        private IList<IWebElement> InstrumentCheckboxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[starts-with(@id,'lbl_instrument_')]")]
        private IList<IWebElement> InstrumentCheckboxLabels { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and starts-with(@id,'family_')]")]
        private IList<IWebElement> GenreCheckboxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[starts-with(@id,'lbl_family_')]")]
        private IList<IWebElement> GenreCheckboxLabels { get; set; }

        public void SetMusicianNameText(string text)
        {
            MusicianNameText.Clear();
            MusicianNameText.SendKeys(text);
        }

        public void SetMusicianProfileText(string text)
        {
            MusicianProfileText.Clear();
            MusicianProfileText.SendKeys(text);
        }

        public void SetMusicianSocialNetworkText(string text)
        {
            MusicianSocialNetworkText.Clear();
            MusicianSocialNetworkText.SendKeys(text);
        }

        public void SetMusicianGearText(string text)
        {
            MusicianGearText.Clear();
            MusicianGearText.SendKeys(text);
        }

        public void SetMusicianLevelText(string text)
        {
            // Combo box
        }

        public void SetMusicianEducationText(string text)
        {
            MusicianEducationText.Clear();
            MusicianEducationText.SendKeys(text);
        }

        public void SetMusicianExperienceText(string text)
        {
            MusicianExperienceText.Clear();
            MusicianExperienceText.SendKeys(text);
        }

        public void SetMusicianWebsiteText(string text)
        {
            MusicianWebsiteText.Clear();
            MusicianWebsiteText.SendKeys(text);
        }

        public string GetMusicianNameText()
        {
            return MusicianNameText.GetAttribute("value");
        }

        public string GetMusicianProfileText()
        {
            return MusicianProfileText.GetAttribute("value");
        }

        public string GetMusicianSocialNetworkText()
        {
            return MusicianSocialNetworkText.GetAttribute("value");
        }

        public string GetMusicianGearText()
        {
            return MusicianGearText.GetAttribute("value");
        }

        public string GetMusicianEducationText()
        {
            return MusicianEducationText.GetAttribute("value");
        }

        public string GetMusicianExperienceText()
        {
            return MusicianExperienceText.GetAttribute("value");
        }

        public string GetMusicianWebsiteText()
        {
            return MusicianWebsiteText.GetAttribute("value");
        }

        public IList<IWebElement> GetInstrumentCheckboxes()
        {
            return InstrumentCheckboxes;
        }

        public void UncheckAllInstrumentBoxes()
        {
            UncheckAllBoxes(InstrumentCheckboxes);
        }

        public void UncheckAllGenreBoxes()
        {
            UncheckAllBoxes(GenreCheckboxes);
        }

        public void UncheckAllBoxes(IList<IWebElement> Checkboxes)
        {
            Browser.WaitForElements(Checkboxes);
            foreach (IWebElement checkbox in Checkboxes)
                if (checkbox.Selected) checkbox.Click();
        }

        public void CheckRandomInstrumentBoxes()
        {
            CheckRandomBoxes(InstrumentCheckboxes);
        }

        public void CheckRandomGenreBoxes()
        {
            CheckRandomBoxes(GenreCheckboxes);
        }

        public void CheckRandomBoxes(IList<IWebElement> Checkboxes)
        {
            var random = new System.Random();
            for (int index = 0; index < Checkboxes.Count; index++)
                if (random.Next(2) == 0) Checkboxes[index].Click();
        }

        public List<string> GetSelectedInstrumentLabels()
        {
            return GetSelectedLabels(InstrumentCheckboxes, InstrumentCheckboxLabels);
        }

        public List<string> GetSelectedGenreLabels()
        {
            return GetSelectedLabels(GenreCheckboxes, GenreCheckboxLabels);
        }

        public List<string> GetSelectedLabels(IList<IWebElement> Checkboxes, IList<IWebElement> CheckboxLabels)
        {
            List<string> selectedLabels = new List<string> { };
            for (int index = 0; index < Checkboxes.Count; index++)
                if (Checkboxes[index].Selected) selectedLabels.Add(CheckboxLabels[index].Text);

            return selectedLabels;
        }

        public void SetInstrumentSelection()
        {
            SaveInstrumentsButton.Click();
        }

        public IList<IWebElement> GetInstrumentCheckboxLabels()
        {
            return InstrumentCheckboxLabels;
        }

        public IList<IWebElement> GetGenreCheckboxes()
        {
            return GenreCheckboxes;
        }

        public void SetGenreSelection()
        {
            SaveGenreButton.Click();
        }

        public IList<IWebElement> GetGenreCheckboxLabels()
        {
            return GenreCheckboxLabels;
        }

        public void SubmitMusicianProfile()
        {
            Browser.WaitForElements(new List<IWebElement>() { SaveMusicianProfileButton });
            Browser.JavaScriptClick(SaveMusicianProfileButton);
        }

        public bool InvalidMusicianNameMessageIsDisplayed()
        {
            return EmptyMusicianNameAlert.Displayed;
        }

        public bool InvalidMusicianProfileMessageIsDisplayed()
        {
            return EmptyMusicianProfileAlert.Displayed;
        }

        public bool MusicianIsSingerIsDisplayed()
        {
            return MusicianIsSingerCheckBox.Displayed;
        }

        public bool MusicianIsBackupSingerIsDisplayed()
        {
            return MusicianIsBackupSingerCheckBox.Displayed;
        }

        public bool MusicianIsComposerIsDisplayed()
        {
            return MusicianIsComposerCheckBox.Displayed;
        }

        public bool MusicianProfileIsSaved()
        {
            return ProfileSavedMessage.Displayed;
        }

        public void ShowInstrumentsDialogBox()
        {
            ShowInstrumentsButton.Click();
        }

        public void ShowGenresDialogBox()
        {
            ShowGenresButton.Click();
        }

        public bool IsMusicianLabelPresent(string label)
        {
            var webElement = Browser.Driver.FindElement(By.XPath("//label[text()[contains(.,'" + label + "')]]"));
            return webElement.Displayed ? true : false;
        }
    }
}
