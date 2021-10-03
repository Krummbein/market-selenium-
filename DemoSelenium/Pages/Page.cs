using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
            var waitForPage = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.UrlToBe(pageURL));
        }

        public void ClickButton(string XPath)
        {
            driver.FindElement(By.XPath(XPath)).Click();
        }


    }
}
