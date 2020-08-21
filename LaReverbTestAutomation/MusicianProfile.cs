using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework;
using TestFramework.Pages;
using TestFramework.Generators;
using System.Collections.Generic;

namespace TestAutomation
{
    [TestClass()]
    public class MusicianProfile
    {
        [ClassInitialize()]
        public static void Initialize(TestContext context) 
        {
            Browser.Initialize();
            Pages.Login.GoTo();
            Pages.Login.LogIn();
            Pages.Dashboard.GoTo();
            Pages.Dashboard.GoToProfile();
        }

        [TestMethod]
        public void CanEditProfile()
        {
            List<string> randomText = RandomGenerator.GetRandomStringList(7, 7);

            Pages.MusicianProfile.SetMusicianNameText(randomText[0]);
            Pages.MusicianProfile.SetMusicianProfileText(randomText[1]);
            Pages.MusicianProfile.SetMusicianGearText(randomText[2]);
            Pages.MusicianProfile.SetMusicianEducationText(randomText[3]);
            Pages.MusicianProfile.SetMusicianExperienceText(randomText[4]);
            Pages.MusicianProfile.SetMusicianWebsiteText(randomText[5]);
            Pages.MusicianProfile.SetMusicianSocialNetworkText(randomText[6]);
            Pages.MusicianProfile.SubmitMusicianProfile();

            Assert.IsTrue(Pages.MusicianProfile.MusicianProfileIsSaved());

            Pages.Dashboard.GoToProfile();

            Assert.AreEqual(Pages.MusicianProfile.GetMusicianNameText(), randomText[0]);
            Assert.AreEqual(Pages.MusicianProfile.GetMusicianProfileText(), randomText[1]);
            Assert.AreEqual(Pages.MusicianProfile.GetMusicianGearText(), randomText[2]);
            Assert.AreEqual(Pages.MusicianProfile.GetMusicianEducationText(), randomText[3]);
            Assert.AreEqual(Pages.MusicianProfile.GetMusicianExperienceText(), randomText[4]);
            Assert.AreEqual(Pages.MusicianProfile.GetMusicianWebsiteText(), randomText[5]);
            Assert.AreEqual(Pages.MusicianProfile.GetMusicianSocialNetworkText(), randomText[6]);
        }

        [TestMethod]
        public void TestEmptyNameIsNotAllowed()
        {
            Pages.MusicianProfile.SetMusicianNameText("");
            Pages.MusicianProfile.SubmitMusicianProfile();

            Assert.IsTrue(Pages.MusicianProfile.InvalidMusicianNameMessageIsDisplayed()); 
        }

        [TestMethod]
        public void TestEmptyProfileIsNotAllowed()
        {
            Pages.MusicianProfile.SetMusicianNameText("musician name text");
            Pages.MusicianProfile.SetMusicianProfileText("");
            Pages.MusicianProfile.SubmitMusicianProfile();

            Assert.IsTrue(Pages.MusicianProfile.InvalidMusicianProfileMessageIsDisplayed());
        }

        [TestMethod]
        public void TestProfileCheckBoxes()
        {
            Assert.IsTrue(Pages.MusicianProfile.MusicianIsSingerIsDisplayed());
            Assert.IsTrue(Pages.MusicianProfile.MusicianIsBackupSingerIsDisplayed());
            Assert.IsTrue(Pages.MusicianProfile.MusicianIsComposerIsDisplayed());
        }

        [TestMethod]
        public void TestSelectInstruments()
        {
            Pages.Dashboard.GoToProfile();
            Pages.MusicianProfile.ShowInstrumentsDialogBox();
            var InstrumentCheckboxes = Pages.MusicianProfile.GetInstrumentCheckboxes();
            var InstrumentCheckboxLabels = Pages.MusicianProfile.GetInstrumentCheckboxLabels();

            Assert.AreEqual(InstrumentCheckboxes.Count, InstrumentCheckboxLabels.Count);

            Pages.MusicianProfile.UncheckAllInstrumentBoxes();
            Pages.MusicianProfile.CheckRandomInstrumentBoxes();
            var selectedInstrumentLabels = Pages.MusicianProfile.GetSelectedInstrumentLabels();
            Pages.MusicianProfile.SetInstrumentSelection();
            Pages.MusicianProfile.SubmitMusicianProfile();

            Assert.IsTrue(Pages.MusicianProfile.MusicianProfileIsSaved());

            Pages.Dashboard.GoToProfile();

            foreach (string label in selectedInstrumentLabels)
            {
                Assert.IsTrue(Pages.MusicianProfile.IsMusicianLabelPresent(label));
            }
        }

        [TestMethod]
        public void TestSelectGenres()
        {
            Pages.Dashboard.GoToProfile();
            Pages.MusicianProfile.ShowGenresDialogBox();
            var GenreCheckboxes = Pages.MusicianProfile.GetGenreCheckboxes();
            var GenreCheckboxLabels = Pages.MusicianProfile.GetGenreCheckboxLabels();

            Assert.AreEqual(GenreCheckboxes.Count, GenreCheckboxLabels.Count);

            Pages.MusicianProfile.UncheckAllGenreBoxes();
            Pages.MusicianProfile.CheckRandomGenreBoxes();
            var selectedGenreLabels = Pages.MusicianProfile.GetSelectedGenreLabels();
            Pages.MusicianProfile.SetGenreSelection();
            Pages.MusicianProfile.SubmitMusicianProfile();

            Assert.IsTrue(Pages.MusicianProfile.MusicianProfileIsSaved());

            Pages.Dashboard.GoToProfile();

            foreach (string label in selectedGenreLabels)
            {
                Assert.IsTrue(Pages.MusicianProfile.IsMusicianLabelPresent(label));
            }
        }

        [ClassCleanup()]
        public static void TearDown()
        {
             Browser.Close();
        }
    }
}
