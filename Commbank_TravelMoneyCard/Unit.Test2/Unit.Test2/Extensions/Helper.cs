using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit.Test2.Extensions
{
   public static class Helper
    {
        public static bool WaitAndClick(IWebElement elm)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(elm);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            bool element = wait.Until<bool>((d) =>
            {
                try
                {
                    if (d.Displayed & d.Enabled)
                    {
                        d.Click();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    string a = e.Message;
                    return false;
                }

            });
            return element;
        }


        public static bool WaitAndSwitchForFrame(ref IWebDriver d, IWebElement element)
        {

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(d);
            wait.Timeout = TimeSpan.FromSeconds(60);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            bool waitcondition = wait.Until<bool>((dd) =>
            {
                try
                {
                    dd.SwitchTo().DefaultContent();
                    dd.SwitchTo().Frame(0);
                    if (element.Enabled & element.Displayed)
                    {
                        return true;
                    }
                    else { return false; }
                }
                catch (Exception e)
                {
                    return false;
                }
            });

            return waitcondition;
        }
    }
}
