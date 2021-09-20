using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoSelenium
{
    public class CssTests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1600, 900);

        }

        [Test]
        public void SummerDressesTest()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.CssSelector(".sf-menu.clearfix.menu-content.sf-js-enabled.sf-arrows > li > a[title=Dresses]")).Click();
            driver.FindElement(By.CssSelector("div#subcategories a[title='Summer Dresses']")).Click();
        }

        [Test]
        public void ItemTest()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            var element = driver.FindElement(By.CssSelector("div.product-container"));
            Actions moveToItem = new Actions(driver).MoveToElement(element);
            moveToItem.Perform();
        }

        [Test]
        public void AddToCartTest()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            var element = driver.FindElement(By.CssSelector("div.product-container"));
            Actions moveToItem = new Actions(driver).MoveToElement(element);
            moveToItem.Perform();
            var elementToClick = driver.FindElement(By.CssSelector("a.button.ajax_add_to_cart_button.btn.btn-default"));
            elementToClick.Click();
            Thread.Sleep(5000);
        }

        [Test]
        public void ConfirmCartTest()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            var element = driver.FindElement(By.CssSelector("div.product-container"));
            Actions moveToItem = new Actions(driver).MoveToElement(element);
            moveToItem.Perform();
            var elementToClick = driver.FindElement(By.CssSelector("a.button.ajax_add_to_cart_button.btn.btn-default"));
            elementToClick.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".icon-ok"));
        }

        [Test]
        public void ContinueShoppingTest()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            var element = driver.FindElement(By.CssSelector("div.product-container"));
            Actions moveToItem = new Actions(driver).MoveToElement(element);
            moveToItem.Perform();
            var elementToClick = driver.FindElement(By.CssSelector("a.button.ajax_add_to_cart_button.btn.btn-default"));
            elementToClick.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".continue.btn.btn-default.button.exclusive-medium")).Click();
            Thread.Sleep(3000);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}