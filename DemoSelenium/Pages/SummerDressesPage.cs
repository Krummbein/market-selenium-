using OpenQA.Selenium;
using System.Collections.Generic;

namespace DemoSelenium.Pages
{
    class SummerDressesPage : Page
    {
        private string CatNameXPath = "//span[@class='cat-name']";
        private string ShopItemXPath = "//div[@class='product-container']";

        public SummerDressesPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ReturnCategoryName()
        {
            return driver.FindElement(By.XPath(CatNameXPath));
        }

        public List<IWebElement> FindItems()
        {
            return new List<IWebElement>(driver.FindElements(By.XPath(ShopItemXPath)));
        }
    }
}
