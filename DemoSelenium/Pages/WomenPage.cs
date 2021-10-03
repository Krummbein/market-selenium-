using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace DemoSelenium.Pages
{
    class WomenPage : Page
    {
        private string SubCatTopsXPath = "//div[@id='subcategories']//a[@title='Tops']";
        private string SubCategoriesXPath = "//div[@id='subcategories']//div[@class='subcategory-image']";

        private string DressesSubCatTextXPath = "//a[@class='subcategory-name' and text()='Dresses']";
        private string TopsSubCatTextXPath = "//a[@class='subcategory-name' and text()='Tops']";

        private string CatNameXPath = "//span[@class='cat-name']";

        private List<IWebElement> SubCatList;

        public WomenPage(IWebDriver driver) : base(driver)
        {
            SubCatList = new List<IWebElement>(driver.FindElements(By.XPath(SubCategoriesXPath)));
        }

        public List<IWebElement> FindSubCategories()
        {
            return SubCatList;
        }

        public TopsPage ClickTopsSubCatButton()
        {
            ClickButton(SubCatTopsXPath);
            var waitForPage = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.UrlToBe("http://automationpractice.com/index.php?id_category=4&controller=category"));
            return new TopsPage(driver);
        }

        public IWebElement ReturnTopsSubCatText()
        {
            return driver.FindElement(By.XPath(TopsSubCatTextXPath));
        }

        public IWebElement ReturnDressesSubCatText()
        {
            return driver.FindElement(By.XPath(DressesSubCatTextXPath));
        }

        public IWebElement ReturnCategoryName()
        {
            return driver.FindElement(By.XPath(CatNameXPath));
        }
    }
}
