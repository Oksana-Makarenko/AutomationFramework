using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FWRun.Helpers
{
    public static class PageWait
    {
        public static void WaitForLoad(IWebDriver driver, int timeoutSec = 15)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(webDriver => js.ExecuteScript("return (document.readyState == 'complete' && jQuery.active == 0)"));
        }

        public static bool WaitUntilElementIsPresent(this IWebDriver driver, By by, int timeout = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(d => d.WaitUntilElementIsPresent(by));
        }
    }
}
