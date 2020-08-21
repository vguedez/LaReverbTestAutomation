using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestFramework;
using TestFramework.Pages;
using TestFramework.Generators;
using TechTalk.SpecFlow;

namespace LaReverbTestAutomation
{
    [Binding]
    public class AdsModuleSteps
    {
        private readonly List<string> randomText = RandomGenerator.GetRandomStringList(2, 7);

        [Given(@"a session for a Musician")]
        public void GivenASessionForAMusician()
        {
            Browser.Initialize();
            Pages.Login.GoTo();
            Pages.Login.LogIn();
            Pages.Dashboard.GoTo();
        }

        [When(@"Ad is created and saved")]
        public void WhenAdIsCreatedAndSaved()
        {
            PublishNewAd();
        }

        [When(@"Ad is edited and saved")]
        public void WhenAdIsEditedAndSaved()
        {
            Pages.Dashboard.GoToAds();
            Pages.Ads.ClickOnFirstAdLink();
            EnterDataAndSave();
        }

        [When(@"and ad is deleted")]
        public void WhenAndAdIsDeleted()
        {
            PublishNewAd();
            Pages.Dashboard.GoToAds();
            Pages.Ads.SelectFirstAd();
            Pages.Ads.DeleteSelectedAd();
        }

        [Then(@"the new ad should be visible in the ads admin panel")]
        public void ThenTheNewAdShouldBeVisibleInTheAdsAdminPanel()
        {
            ValidateAdChanges();
        }

        [Then(@"modifications should be visible in the ads admin panel")]
        public void ThenModificationsShouldBeVisibleInTheAdsAdminPanel()
        {
            ValidateAdChanges();
        }

        [Then(@"the ad should dissapear from the ads admin")]
        public void ThenTheAdShouldDissapearFromTheAdsAdmin()
        {
            Pages.Ads.ConfirmDeleteSelectedAds();
        }

        private void PublishNewAd()
        {
            Pages.Dashboard.GoToAds();
            Pages.Ads.GoToMainAdsMenu();
            Pages.Ads.SelectNewSearchBandAd();
            Pages.Ads.CreateNewAd();
            EnterDataAndSave();
        }
        private void ValidateAdChanges()
        {
            Assert.IsTrue(Pages.Ads.AdIsSaved());

            Pages.Ads.ClickOnAdLink(randomText[0]);

            Assert.AreEqual(randomText[0], Pages.Ads.GetPostTitleText());
            Assert.AreEqual(randomText[1], Pages.Ads.GetPostContentText());
        }

        private void EnterDataAndSave()
        {
            Pages.Ads.SetPostTitleText(randomText[0]);
            Pages.Ads.SetPostContentText(randomText[1]);
            Pages.Ads.MarkProfileAsSinger();
            Pages.Ads.MarkProfileAsBackupSinger();
            Pages.Ads.PostAdForm();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Browser.Close();
        }
    }
}
