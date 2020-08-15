using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestFramework;
using TestFramework.Pages;
using TestFramework.Generators;
using System.Diagnostics;

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

        [ClassCleanup()]
        public static void TearDown()
        {
            Browser.Close();
        }
    }
}
