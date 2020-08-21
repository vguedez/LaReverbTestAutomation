using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework;
using TestFramework.Pages;

namespace TestAutomation
{
    [TestClass()]
    public class Directory
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
        public void TestMusicProfileFilterLeftSideMenu()
        {

        }

        [TestMethod]
        public void TestLocationFilterLeftSideMenu()
        {

        }

        [TestMethod]
        public void TestGenreFilterLeftSideMenu()
        {

        }

        [TestMethod]
        public void TestDirectoryCount()
        {

        }

        [TestMethod]
        public void TestAdsCount()
        {

        }

        [ClassCleanup()]
        public static void TearDown()
        {
            Browser.Close();
        }
    }
}
