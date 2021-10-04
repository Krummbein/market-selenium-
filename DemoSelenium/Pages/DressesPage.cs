
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoSelenium.Pages
{
    class DressesPage : Page
    {
        private string CheckboxXPath = "//input[@class='checkbox']";
        private string SubCatSummerDressesXPath = "//div[@id='subcategories']//a[@title='Summer Dresses']";
        public DressesPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement SelectCheckbox()
        {
            var checkbox = driver.FindElement(By.XPath(CheckboxXPath));
            checkbox.Click();
            return checkbox;
        }

        public SummerDressesPage GoToSummerDressesPage()
        {
            ClickButton(SubCatSummerDressesXPath);
            var waitForPage = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                c => string.Equals(driver.Url, "http://automationpractice.com/index.php?id_category=11&controller=category"));
            return new SummerDressesPage(driver);
        }
    }
}
