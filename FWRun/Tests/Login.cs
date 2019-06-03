using NUnit.Framework;
using OpenQA.Selenium;

namespace FWRun.Tests
{
    public class Login : TestsFunctional
    {
        [Test]
        public void LoginTest()
        {
            var authPage = MainPage.OpenAuthenticationPage();
            authPage.SignIn(@"oksanamakarenko92@gmail.com", "260520");
            Assert.That(Driver.FindElement(By.ClassName("page-heading")).Text, Is.EqualTo("MY ACCOUNT"));
        }

        [Test]
        public void ApiTest()
        {

        }
    }
}