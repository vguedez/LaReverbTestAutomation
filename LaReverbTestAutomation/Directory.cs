using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestFramework;
using TestFramework.Pages;
using TestFramework.Generators;

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
        public void TestLeftSideMenu()
        {

        }

        [TestMethod]
        public void TestDirectoryCount()
        {

        }

        [TestMethod]
        public void CanEditPublishedAd()
        {

        }

        private void FillAndSaveAd()
        {

        }

        [TestMethod]
        public void CanDeletePublishedAd()
        {

        }

        [ClassCleanup()]
        public static void TearDown()
        {
            Browser.Close();
        }
    }
}
