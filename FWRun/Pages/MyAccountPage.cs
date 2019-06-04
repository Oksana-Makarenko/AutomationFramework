using OpenQA.Selenium;

namespace FWRun.Pages
{
    public class MyAccountPage
    {
        private IWebDriver _driver;

        public MyAccountPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public IWebElement PageHeaderName 
            => _driver.FindElement(By.ClassName("page-heading"));

        public string GetPageHeaderName() 
            => PageHeaderName.Text;
    }
}
