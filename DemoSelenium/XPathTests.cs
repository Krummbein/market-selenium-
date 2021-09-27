using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoSelenium
{
    public class XPathTests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }


        [Test, Description("Navigate to Summer Dresses and Count items")]
        public void SummerDressesTest()
        {
            driver.FindElement(By.XPath("//*[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/*[a[@title='Dresses']]")).Click();
            var waitForPage = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.UrlToBe("http://automationpractice.com/index.php?id_category=8&controller=category"));
            driver.FindElement(By.XPath("//div[@id='subcategories']//a[@title='Summer Dresses']")).Click();
            waitForPage = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.UrlToBe("http://automationpractice.com/index.php?id_category=11&controller=category"));

            Assert.Multiple(() =>
            {
                Assert.AreEqual("SUMMER DRESSES ", driver.FindElement(By.XPath("//span[@class='cat-name']")).Text);
                Assert.AreEqual(3, driver.FindElements(By.XPath("//div[@class='product-container']")).Count);
            }
            );
        }


        [Test, Description("Items count is not Zero")]
        public void ItemTest()
        {
            Assert.AreNotEqual(0, driver.FindElements(By.XPath("//div[@class='product-container']")).Count);
        }


        [Test, Description("Add to card button is enabled")]
        public void AddToCartTest()
        {
            var addToCartButton = findAddToCartButton();
            Assert.AreEqual(true, addToCartButton.Enabled);
        }


        [Test, Description("Message of successfull addition is shown")]
        public void ConfirmCartTest()
        {
            var addToCartButton = findAddToCartButton();
            addToCartButton.Click();

            var waitForConfirm = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible
                (By.XPath("//*[@class='layer_cart_product col-xs-12 col-md-6']")));
            
            Assert.AreEqual("Product successfully added to your shopping cart", driver.FindElement
                (By.XPath("//*[@class='layer_cart_product col-xs-12 col-md-6']//h2")).Text);
        }


        [Test, Description("Continue shopping, check the item is in the cart")]
        public void ContinueShoppingTest()
        {
            var addToCartButton = findAddToCartButton();
            addToCartButton.Click();

            var waitForConfirmAppear = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible
                (By.XPath("//*[@class='clearfix']//*[@class='icon-ok']")));

            driver.FindElement(By.XPath("//*[@class='continue btn btn-default button exclusive-medium']")).Click();

            var waitForConfirmHide = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.InvisibilityOfElementLocated
                (By.XPath("//*[@class='clearfix']//*[@class='icon-ok']")));

            var shoppingCartMenu = driver.FindElement(By.XPath("//div[@class='shopping_cart']/a[@title='View my shopping cart']"));
            var moveToCart = new Actions(driver).MoveToElement(shoppingCartMenu);
            moveToCart.Perform();

            var waitForCartOpened = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible
                (By.XPath("//*[@class='block_content']//*[@class='cart_block_list']")));

            Assert.AreEqual(true, driver.FindElement(By.XPath("//div[@class='shopping_cart']//div[@class='product-name']")).Displayed);
        }


        [Test, Description("Run an empty search query")]
        public void SearchfiledTest()
        {
            var searchField = driver.FindElement(By.XPath("//input[@class='search_query form-control ac_input']"));
            searchField.Submit();

            var waitForPage = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible
                (By.XPath("//span[@class='navigation_page']")));

            Assert.AreEqual("Search", driver.FindElement(By.XPath("//span[@class='navigation_page']")).Text);
        }


        [Test, Description("Select a checkbox")]
        public void CheckBoxTest()
        {
            driver.FindElement(By.XPath("//*[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/*[a[@title='Dresses']]")).Click();
            var checkbox = driver.FindElement(By.XPath("//input[@class='checkbox' and @name='layered_category_9']"));
            checkbox.Click();
            Assert.AreEqual(true, checkbox.Selected);
        }


        [Test, Description("Get logo's alternative text'")]
        public void GetAttributeTest()
        {
            var logo = driver.FindElement(By.XPath("//img[@class='logo img-responsive']"));
            Assert.AreEqual("My Store", logo.GetAttribute("alt"));
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        //this method looks for product container, moves the cursor to it and finds the button "Add to cart"
        //method is used in AddToCartTest, ConfirmCartTest, ContinueShoppingTest
        public IWebElement findAddToCartButton()
        {
            var productContainer = driver.FindElement(By.XPath("//div[@class='product-container']"));
            Actions moveToContainer = new Actions(driver).MoveToElement(productContainer);
            moveToContainer.Perform();
            IWebElement addToCartButton = driver.FindElement(By.XPath("//a[@class='button ajax_add_to_cart_button btn btn-default']"));
            return addToCartButton;
        }
    }
}