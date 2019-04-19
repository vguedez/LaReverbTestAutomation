using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework;
using TestFramework.Pages;

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
        }

        [TestMethod]
        public void TestSelectInstruments()
        {
        }

        [TestMethod]
        public void TestSelectGenres()
        {
        }

        [ClassCleanup()]
        public static void TearDown()
        {
            Browser.Close();
        }
    }
}
