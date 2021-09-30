using OpenQA.Selenium;
using System.Collections.Generic;

namespace DemoSelenium.Pages
{
    class SummerDressesPage
    {
        private IWebDriver driver;

        public SummerDressesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ReturnCategoryName()
        {
            return driver.FindElement(By.XPath("//span[@class='cat-name']"));
        }

        public List<IWebElement> FindItems()
        {
            return new List<IWebElement>(driver.FindElements(By.XPath("//div[@class='product-container']")));
        }
    }
}
