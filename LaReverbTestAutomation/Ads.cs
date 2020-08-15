using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestFramework;
using TestFramework.Pages;
using TestFramework.Generators;
using System.Diagnostics;

namespace TestAutomation
{
    [TestClass()]
    public class Ads
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
        public void TestAllAdsOptions()
        {
            Pages.Dashboard.GoToAds();
            Pages.Ads.GoToMainAdsMenu();

            Assert.IsTrue(Pages.Ads.PromoConcertRadioButtonIsPresent());
            Assert.IsTrue(Pages.Ads.PromoAlbumRadioButtonIsPresent());
            Assert.IsTrue(Pages.Ads.PromoEventRadioButtonIsPresent());
            Assert.IsTrue(Pages.Ads.SearchBandOrProjectRadioButtonIsPresent());
            Assert.IsTrue(Pages.Ads.SearchServiceRadioButtonIsPresent());
            Assert.IsTrue(Pages.Ads.EquipmentSalesRadioButtonIsPresent());
            Assert.IsTrue(Pages.Ads.EquipmentBuyRadioButtonIsPresent());
        }

        [TestMethod]
        public void CanPublishNewAd()
        {
            Pages.Dashboard.GoToAds();
            Pages.Ads.GoToMainAdsMenu();
            Pages.Ads.SelectNewSearchBandAd();
            Pages.Ads.CreateNewAd();

            FillAndSaveAd();
        }

        [TestMethod]
        public void CanEditPublishedAd()
        {
            Pages.Dashboard.GoToAds();
            Pages.Ads.ClickOnFirstAdLink();

            FillAndSaveAd();
        }

        private void FillAndSaveAd()
        {
            List<string> randomText = RandomGenerator.GetRandomStringList(2, 7);
            Pages.Ads.SetPostTitleText(randomText[0]);
            Pages.Ads.SetPostContentText(randomText[1]);
            Pages.Ads.MarkProfileAsSinger();
            Pages.Ads.MarkProfileAsBackupSinger();
            Pages.Ads.PostAdForm();

            Assert.IsTrue(Pages.Ads.AdIsSaved());

            Pages.Ads.ClickOnAdLink(randomText[0]);

            Assert.AreEqual(randomText[0], Pages.Ads.GetPostTitleText());
            Assert.AreEqual(randomText[1], Pages.Ads.GetPostContentText());
        }

        [TestMethod]
        public void CanDeletePublishedAd()
        {
            CanPublishNewAd();
            Pages.Dashboard.GoToAds();
            Pages.Ads.SelectFirstAd();
            Pages.Ads.DeleteSelectedPosts();
            Pages.Ads.ConfirmDeleteSelectedPosts();

            Assert.IsTrue(Pages.Ads.AdIsDeleted());
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
