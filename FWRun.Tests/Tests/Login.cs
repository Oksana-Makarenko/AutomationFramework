using NUnit.Framework;

namespace FWRun.Tests
{
    [TestFixture]
    public class Login : TestsFunctional
    {
        [Test]
        public void LoginTest()
        {
            var authPage = MainPage.OpenAuthenticationPage();
            var myAccountPage = authPage.SignIn(@"oksanamakarenko92@gmail.com", "260520");
            Assert.That(myAccountPage.GetPageHeaderName(), Is.EqualTo("MY ACCOUNT"));
        }
    }
}