using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


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
            var waitForPage = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                c => string.Equals(driver.Url, pageURL));
        }

        public void ClickButton(string XPath)
        {
            driver.FindElement(By.XPath(XPath)).Click();
        }


    }
}
