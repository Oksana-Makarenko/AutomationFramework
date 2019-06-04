using FWRun.Pages;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace FWRun.Tests.Steps
{
    [Binding]
    public sealed class LoginSteps : BaseSpecflowTest
    {
        private AuthenticationPage _authPage;
        private MyAccountPage _myAccountPage;

        [Given(@"I navigate to Log In page")]
        public void GivenINavigateToPage(string pageName)
        {
            _authPage = MainPage.OpenAuthenticationPage();
        }

        [When(@"I perform login")]
        public void WhenIPerformLogin(Table table)
        {
            var email = table.Rows.First()["email"];
            var password = table.Rows.First()["password"];
            _myAccountPage = _authPage.SignIn(email, password);
        } 

        [Then(@"the '(.*)' page (is|is not) displayed")]
        public void ThenThePageIsDisplayed(string pageHeaderName, bool isDisplayed)
        {
            string actualPageName = _myAccountPage.GetPageHeaderName();
            Assert.That(actualPageName, isDisplayed ? Is.EqualTo(pageHeaderName) : Is.Not.EqualTo(pageHeaderName),
                $"'{pageHeaderName}' {(isDisplayed ? "should not" : "should")} displayed");
        }
    }
}
