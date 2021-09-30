using DemoSelenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoSelenium
{
    public class XPathTests
    {
        private IWebDriver driver;
        private MainPage mainPage;
        private DressesPage dressesPage;
        private SummerDressesPage summerDressesPage;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            mainPage = new MainPage(driver);
        }


        [Test, Description("Navigate to Summer Dresses and Count items")]
        public void SummerDressesTest()
        {
            dressesPage = mainPage.GoToDressesPage();
            summerDressesPage = dressesPage.GoToSummerDressesPage();
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual("SUMMER DRESSES ", summerDressesPage.ReturnCategoryName().Text);
                Assert.AreEqual(3, summerDressesPage.FindItems().Count);
            }
            );
        }


        [Test, Description("Items count is not Zero")]
        public void ItemTest()
        {
            Assert.AreNotEqual(0, mainPage.FindItems().Count);
        }


        [Test, Description("Add to card button is enabled")]
        public void AddToCartTest()
        {
            var addToCartButton = mainPage.FindAddToCartButton();
            Assert.AreEqual(true, addToCartButton.Enabled);
        }


        [Test, Description("Message of successfull addition is shown")]
        public void ConfirmCartTest()
        {
            mainPage.addItemToCart();
            Assert.AreEqual("Product successfully added to your shopping cart", mainPage.ReturnConfirmationMessage().Text);
        }


        [Test, Description("Continue shopping, check the item is in the cart")]
        public void ContinueShoppingTest()
        {
            mainPage.addItemToCart();
            mainPage.ContinueShopping();
            mainPage.MoveToCartList();
            var productName = mainPage.FindProductName();
            Assert.AreEqual(true, productName.Displayed);
        }


        [Test, Description("Run an empty search query")]
        public void SearchfiledTest()
        {
            var navigationBar = mainPage.RunEmptySearch();
            Assert.AreEqual("Search", navigationBar.Text);
        }


        [Test, Description("Select a checkbox")]
        public void CheckBoxTest()
        {
            dressesPage = mainPage.GoToDressesPage();
            var checkbox = dressesPage.SelectCheckbox();
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
    }
}