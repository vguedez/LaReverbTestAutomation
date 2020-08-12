using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TestFramework
{
    public static class Browser
    {
        private static string baseUrl;
        private static string defaultProfile;
        private static IWebDriver webDriver = new ChromeDriver(@"C:\Users\Vicente\source\repos\LaReverbTestAutomation\TestFramework");
        private static Dictionary<string, string[]> profiles;

        public static void Initialize()
        {
            LoadSettings();
            webDriver.Manage().Window.Maximize();
            GoTo("");
        }

        public static string Title
        {
            get { return webDriver.Title; }
        }

        public static void GoTo(string url)
        {
            webDriver.Navigate().GoToUrl(baseUrl + url);
        }

        public static IWebDriver Driver
        {
            get { return webDriver; }
        }

        public static void Close()
        {
            webDriver.Close();
        }

        public static void WaitForElements(IList<IWebElement> elements)
        {
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromMinutes(1));

            foreach (IWebElement element in elements)
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
        }

        public static string getUser()
        {
            return profiles[defaultProfile][0];
        }

        public static string getPassword()
        {
            return profiles[defaultProfile][1];
        }

        public static void LoadSettings()
        {
            string directory = Path.GetDirectoryName(
              System.Reflection.Assembly.GetExecutingAssembly().Location);

            //using (StreamReader configFile = new StreamReader(directory + @"\Settings\Config.json"))
            using (StreamReader configFile = new StreamReader(@"Settings\Config.json"))
            {
                string json = configFile.ReadToEnd();
                var config = JObject.Parse(json);
                baseUrl = (string)config["site"];
                defaultProfile = (string)config["defaultProfile"];
                profiles = new Dictionary<string, string[]>();

                var profileIndex = 0;

                foreach (JObject userProfile in config["userProfiles"].Children<JObject>())
                {
                    var profile = config["userProfiles"][profileIndex].First;
                    var profileName = (string)profile.GetType().GetProperty("Name").GetValue(profile, null);
                    var user = (string)config["userProfiles"][profileIndex][profileName]["user"];
                    var password = (string)config["userProfiles"][profileIndex][profileName]["password"];
                    profiles[profileName] = new string[] { user, password };

                    profileIndex++;
                }
            }
        }

        public static void JavaScriptClick(IWebElement WebElement)
        {
             IJavaScriptExecutor jse = (IJavaScriptExecutor) Driver;
             jse.ExecuteScript("arguments[0].click();", WebElement); 
        }
    }
}
