
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoSelenium.Pages
{
    class DressesPage
    {
        private IWebDriver driver;

        public DressesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SelectCheckbox()
        {
            var checkbox = driver.FindElement(By.XPath("//input[@class='checkbox' and @name='layered_category_9']"));
            checkbox.Click();
            return checkbox;
        }

        public SummerDressesPage GoToSummerDressesPage()
        {
            driver.FindElement(By.XPath("//div[@id='subcategories']//a[@title='Summer Dresses']")).Click();
            var waitForPage = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.UrlToBe("http://automationpractice.com/index.php?id_category=11&controller=category"));
            return new SummerDressesPage(driver);
        }
    }
}
