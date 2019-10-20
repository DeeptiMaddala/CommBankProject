using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit.Test2.Extensions;

namespace Unit.Test2.PageObjects
{
    public class CommbankTravelHubPage
    {
        private IWebDriver _driver;

        public CommbankTravelHubPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h3/following-sibling::p/a[text()='Discover more']")]
        private IWebElement _btnTravelMoneyCardDiscoverMore;

        [FindsBy(How = How.XPath, Using = "//a[text()='Try our FX calculator']")]
        private IWebElement _btnTryOurFxCalculator;

        public void SearchAndClickTravelMoneyCardDiscoverMore()
        {
            Helper.WaitAndClick(_btnTravelMoneyCardDiscoverMore);
        }

        public bool IsTryOurFxCalculatorButtonVisible() => _btnTryOurFxCalculator.Displayed && _btnTryOurFxCalculator.Enabled;
        
    }
}
