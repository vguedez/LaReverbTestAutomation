using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace TestFramework
{
    public class Session
    {
        private string baseUrl;
        private string defaultProfile;
        private Dictionary<string, string[]> profiles;
        public ChromeDriver webDriver;

        public void Initialize()
        {
            var chromeOptions = new ChromeOptions();
            // chromeOptions.AddArguments("headless");
            webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            LoadSettings();
            webDriver.Manage().Window.Maximize();
            GoTo("");
        }

        public string Title
        {
            get { return webDriver.Title; }
        }

        public void GoTo(string url)
        {
            webDriver.Navigate().GoToUrl(baseUrl + url);
        }

        public IWebDriver Driver
        {
            get { return webDriver; }
        }

        public void Close()
        {
            webDriver.Close();
            webDriver.Quit();
            webDriver.Dispose();
        }

        public static void WaitForElements(IList<IWebElement> elements)
        {
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromMinutes(1));

            foreach (IWebElement element in elements)
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
        }

        public string getUser()
        {
            return profiles[defaultProfile][0];
        }

        public string getPassword()
        {
            return profiles[defaultProfile][1];
        }

        public void LoadSettings()
        {
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

        public void JavaScriptClick(IWebElement WebElement)
        {
             IJavaScriptExecutor jse = (IJavaScriptExecutor) Driver;
             jse.ExecuteScript("arguments[0].click();", WebElement); 
        }
    }
}
