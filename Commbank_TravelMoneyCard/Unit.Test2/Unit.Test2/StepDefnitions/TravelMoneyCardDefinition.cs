using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Unit.Test2.PageObjects;

namespace Unit.Test2.StepDefnitions
{
    [Binding]
    public class TravelMoneyCardDefinition
    {
        private IWebDriver _driver;
        private CommbankLandingPage commbankLandingPage;
        private CommbankTravelHubPage commbankTravelHubPage;
        private CommbankTravelMoneyCardPage commbankTravelMoneyCardPage;

        [Given(@"user launches Commbank page")]
        public void GivenUserLaunchesCommbankPage()
        {
            _driver = (IWebDriver)ScenarioContext.Current["driver"];
            _driver.Url = ConfigurationManager.AppSettings["CommbankUrl"];
            _driver.Manage().Window.Maximize();
        }

        [When(@"user clicks Travel Products link")]
        public void WhenUserClicksTravelProductsLink()
        {
            commbankLandingPage = new CommbankLandingPage(_driver);
            commbankLandingPage.SearchAndClickTravelProductsLink();
        }

        [When(@"user clicks Discover more in Travel Money Card section")]
        public void WhenUserClicksDiscoverMoreInTravelMoneyCardSection()
        {
            commbankTravelHubPage = new CommbankTravelHubPage(_driver);
            Assert.IsTrue(commbankTravelHubPage.IsTryOurFxCalculatorButtonVisible(), "'Try our FX calculator' button is not visible!");
            commbankTravelHubPage.SearchAndClickTravelMoneyCardDiscoverMore();
        }

        [Then(@"user validates Order Online button")]
        public void ThenUserValidatesOrderOnlineButton()
        {
            commbankTravelMoneyCardPage = new CommbankTravelMoneyCardPage(_driver);
            Assert.IsTrue(commbankTravelMoneyCardPage.Is_btnOrderLineButtonVisible(), "'Order Online' button is not visible");
        }

        [Then(@"user enters netbankId as ""(.*)"" and password as ""(.*)"" followed by clicking login button")]
        public void ThenUserEntersNetbankIdAsAndPasswordAsFollowedByClickingLoginButton(string netbankId, string password)
        {
            commbankTravelMoneyCardPage.ClickLogonAndEnterLoginDetails(netbankId, password);
        }

    }
}
