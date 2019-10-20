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
    public class CommbankTravelMoneyCardPage
    {
        private IWebDriver _driver;

        public CommbankTravelMoneyCardPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Order online']")]
        private IWebElement _btnOrderLine;

        [FindsBy(How = How.XPath, Using = "//*[@id='gloNavUnauth']/nav[1]/div/div/ul[2]/li[2]/a[1]")]
        private IWebElement _btnLogonAtTop;

        [FindsBy(How = How.Id, Using = "txtMyClientNumber_field")]
        private IWebElement _txtNetbankId;

        [FindsBy(How = How.Id, Using = "txtMyPassword_field")]
        private IWebElement _txtPassword;

        [FindsBy(How = How.Id, Using = "btnLogon_field")]
        private IWebElement _btnLogon;
        

        public bool Is_btnOrderLineButtonVisible() => _btnOrderLine.Displayed && _btnOrderLine.Enabled;

        public void ClickLogonAndEnterLoginDetails(string netbankId, string password)
        {
            Helper.WaitAndClick(_btnLogonAtTop);
            Helper.WaitAndSwitchForFrame(ref _driver, _txtNetbankId);
            _txtNetbankId.SendKeys(netbankId);
            _txtPassword.SendKeys(password);
            Helper.WaitAndClick(_btnLogon);
        }
    }
}
