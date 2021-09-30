using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace DemoSelenium.Pages
{
    class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement FindAddToCartButton()
        {
            var productContainer = driver.FindElement(By.XPath("//div[@class='product-container']"));
            Actions moveToContainer = new Actions(driver).MoveToElement(productContainer);
            moveToContainer.Perform();
            IWebElement addToCartButton = driver.FindElement(By.XPath("//a[@class='button ajax_add_to_cart_button btn btn-default']"));
            return addToCartButton;
        }


        public void addItemToCart()
        {
            var addToCartButton = FindAddToCartButton();
            addToCartButton.Click();
            var waitForConfirm = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible
                (By.XPath("//*[@class='layer_cart_product col-xs-12 col-md-6']")));
        }


        public void MoveToCartList()
        {
            var shoppingCartMenu = driver.FindElement(By.XPath("//div[@class='shopping_cart']/a[@title='View my shopping cart']"));
            var moveToCart = new Actions(driver).MoveToElement(shoppingCartMenu);
            moveToCart.Perform();
            var waitForCartOpened = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible
                (By.XPath("//*[@class='block_content']//*[@class='cart_block_list']")));
        }

        public void ContinueShopping()
        {
            driver.FindElement(By.XPath("//*[@class='continue btn btn-default button exclusive-medium']")).Click();
            var waitForConfirmHide = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.InvisibilityOfElementLocated
                (By.XPath("//*[@class='clearfix']//*[@class='icon-ok']")));
        }

        public IWebElement FindProductName()
        {
            return driver.FindElement(By.XPath("//div[@class='shopping_cart']//div[@class='product-name']"));
        }

        public IWebElement RunEmptySearch()
        {
            var searchField = driver.FindElement(By.XPath("//input[@class='search_query form-control ac_input']"));
            searchField.Submit();
            var waitForPage = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible
                (By.XPath("//span[@class='navigation_page']")));
            return driver.FindElement(By.XPath("//span[@class='navigation_page']"));
        }

        public List<IWebElement> FindItems()
        {
            return new List<IWebElement>(driver.FindElements(By.XPath("//div[@class='product-container']")));
        }

        public DressesPage GoToDressesPage()
        {
            driver.FindElement(By.XPath("//*[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/*[a[@title='Dresses']]")).Click();
            return new DressesPage(driver);
        }

        public IWebElement ReturnConfirmationMessage()
        {
            return driver.FindElement(By.XPath("//*[@class='layer_cart_product col-xs-12 col-md-6']//h2"));
        }

    }
}
