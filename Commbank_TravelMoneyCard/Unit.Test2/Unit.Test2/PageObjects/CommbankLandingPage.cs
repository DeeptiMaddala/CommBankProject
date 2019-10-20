using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit.Test2.Extensions;

namespace Unit.Test2.PageObjects
{
    public class CommbankLandingPage
    {

        private IWebDriver _driver;

        public CommbankLandingPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//h3[text()= 'Travel products']")]
        private IWebElement _lnkTravelProducts;

        [FindsBy(How = How.XPath, Using = "//a[@class='toast-dismiss-button']")]
        private IWebElement _lnkDismiss;


        public void SearchAndClickTravelProductsLink()
        {
            Helper.WaitAndClick(_lnkDismiss);
            Helper.WaitAndClick(_lnkTravelProducts);
        }
    }
}
