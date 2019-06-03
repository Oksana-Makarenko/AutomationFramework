using OpenQA.Selenium;

namespace FWRun.Pages
{
    public class AuthenticationPage
    {
        private readonly IWebDriver _driver;

        public AuthenticationPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public IWebElement Email => _driver.FindElement(By.Id("email"));
        public IWebElement Password => _driver.FindElement(By.Id("passwd"));
        public IWebElement SignInButton => _driver.FindElement(By.Id("SubmitLogin"));

        public void SignIn(string email, string password)
        {
            EnterEmail(email);
            Password.SendKeys(password);
            SignInButton.Click();
        }

        private void EnterEmail(string email)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;
            jse.ExecuteScript($"arguments[0].value='{email}';", Email);
        }
    }
}
