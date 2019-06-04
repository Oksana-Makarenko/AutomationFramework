using FWRun.Helpers;
using OpenQA.Selenium;

namespace FWRun.Pages
{
    public class MainPage
    {
        private readonly IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public IWebElement SighIn 
            => _driver.FindElement(By.ClassName("login"));

        public AuthenticationPage OpenAuthenticationPage()
        {
            SighIn.Click();
            PageWait.WaitForLoad(_driver, 10);
            return new AuthenticationPage(_driver);
        }
    }
}
