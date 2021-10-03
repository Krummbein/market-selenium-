using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSelenium.Pages
{
    public abstract class Page
    {
        protected IWebDriver driver;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateOnPage(string pageURL)
        {
            driver.Navigate().GoToUrl(pageURL);
        }

        public void ClickButton(string XPath)
        {
            driver.FindElement(By.XPath(XPath)).Click();
        }


    }
}
