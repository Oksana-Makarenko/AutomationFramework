using FWRun.Helpers;
using FWRun.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace FWRun.Tests
{
    [Binding]
    public sealed class Hooks
    {
        private static IWebDriver _driver;
        private string URL = ConfigurationManager.AppSettings["environmentUrl"];
        private MainPage _mainPage;
        private Browser _browser;

        [BeforeFeature]
        public void BeforeFeature()
        {
            _browser = (Browser)Enum.Parse(typeof(Browser), ConfigurationManager.AppSettings["browser"]);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            switch (_browser)
            {
                case Browser.IE:
                    SetInternetExplorer();
                    break;
                case Browser.Chrome:
                    SetChrome();
                    break;
                default:
                    break;
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
            _driver.Navigate().GoToUrl(URL);
            _driver.Manage().Window.Maximize();
            _mainPage = new MainPage(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Close();
            _driver.Quit();
        }

        private void SetInternetExplorer()
        {
            InternetExplorerOptions options = new InternetExplorerOptions
            {
                UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore,
                IgnoreZoomLevel = true,
                EnablePersistentHover = true,
                EnableNativeEvents = true,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                EnsureCleanSession = true,
                RequireWindowFocus = true,
            };

            _driver = new InternetExplorerDriver(options);
        }

        private void SetChrome()
        {
            if (ConfigurationManager.AppSettings["chromeMode"].ToLower().Equals("headless"))
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--headless");
                _driver = new ChromeDriver(chromeOptions);
            }
            else
            {
                _driver = new ChromeDriver();
            }
        }

        protected static IWebDriver Driver => _driver;
        protected MainPage MainPage => _mainPage;
    }
}
