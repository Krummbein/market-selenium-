using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace DemoSelenium.Pages
{
    class MainPage : Page
    {
        private string ShopItemXPath = "//div[@class='product-container']";
        private string AddToCartButtonXPath = "//a[@class='button ajax_add_to_cart_button btn btn-default']";

        private string ConfirmWindowXPath = "//*[@class='layer_cart_product col-xs-12 col-md-6']";
        private string ConfirmIconXPath = "//*[@class='clearfix']//*[@class='icon-ok']";
        private string ContinueShoppingButtonXPath = "//*[@class='continue btn btn-default button exclusive-medium']";

        private string CartMenuXPath = "//div[@class='shopping_cart']/a[@title='View my shopping cart']";
        private string CartListXPath = "//*[@class='block_content']//*[@class='cart_block_list']";
        private string CartMenuItemNameXPath = "//div[@class='shopping_cart']//div[@class='product-name']";

        private string SearchFieldXPath = "//input[@class='search_query form-control ac_input']";
        private string NavigationBarXPath = "//span[@class='navigation_page']";

        private string BarDressesButtonXPath = "//*[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/*[a[@title='Dresses']]";
        private string BarWomenButtonXPath = "//*[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/*[a[@title='Women']]";

        private string ConfirmMessageXPath = "//*[@class='layer_cart_product col-xs-12 col-md-6']//h2";

        public readonly string pageURL = "http://automationpractice.com/index.php";

        private List<IWebElement> ShopItemList;


        public MainPage(IWebDriver driver) : base(driver)
        {
        }


        public IWebElement FindAddToCartButton()
        {
            var productContainer = driver.FindElement(By.XPath(ShopItemXPath));
            Actions moveToContainer = new Actions(driver).MoveToElement(productContainer);
            moveToContainer.Perform();
            IWebElement addToCartButton = driver.FindElement(By.XPath(AddToCartButtonXPath));
            return addToCartButton;
        }


        public void AddItemToCart()
        {
            var addToCartButton = FindAddToCartButton();
            addToCartButton.Click();
            var waitForConfirm = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible
                (By.XPath(ConfirmWindowXPath)));
        }


        public void MoveToCartList()
        {
            var shoppingCartMenu = driver.FindElement(By.XPath(CartMenuXPath));
            var moveToCart = new Actions(driver).MoveToElement(shoppingCartMenu);
            moveToCart.Perform();
            var waitForCartOpened = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible
                (By.XPath(CartListXPath)));
        }

        public void ClicklContinueShoppingButton()
        {
            ClickButton(ContinueShoppingButtonXPath);
            var waitForConfirmHide = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.InvisibilityOfElementLocated
                (By.XPath(ConfirmIconXPath)));
        }

        public IWebElement FindProductName()
        {
            return driver.FindElement(By.XPath(CartMenuItemNameXPath));
        }

        public IWebElement RunEmptySearch()
        {
            var searchField = driver.FindElement(By.XPath(SearchFieldXPath));
            searchField.Submit();
            var waitForPage = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementIsVisible
                (By.XPath(NavigationBarXPath)));
            return driver.FindElement(By.XPath(NavigationBarXPath));
        }

        public List<IWebElement> FindItems()
        {
            ShopItemList = new List<IWebElement>(driver.FindElements(By.XPath(ShopItemXPath)));
            return ShopItemList;
        }

        public DressesPage ClickBarDressesButton()
        {
            ClickButton(BarDressesButtonXPath);
            return new DressesPage(driver);
        }

        public WomenPage ClickBarWomenButton()
        {
            ClickButton(BarWomenButtonXPath);
            return new WomenPage(driver);
        }

        public IWebElement ReturnConfirmationMessage()
        {
            return driver.FindElement(By.XPath(ConfirmMessageXPath));
        }

    }
}
