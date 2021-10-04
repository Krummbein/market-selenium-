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
        private WomenPage womenPage;
        private TopsPage topsPage;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            mainPage = new MainPage(driver);
        }


        [Test, Description("Navigate to Summer Dresses and Count items")]
        public void SummerDressesTest()
        {
            mainPage.NavigateOnPage(mainPage.pageURL);
            dressesPage = mainPage.ClickBarDressesButton();
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
            mainPage.NavigateOnPage(mainPage.pageURL);
            Assert.AreNotEqual(0, mainPage.FindItems().Count);
        }


        [Test, Description("Add to card button is enabled, confirm shows, continue shopping and chek the cart")]
        public void AddToCartTest()
        {
            mainPage.NavigateOnPage(mainPage.pageURL);

            var addToCartButton = mainPage.MoveToItemAndFindAddButton();
            Assert.AreEqual(true, addToCartButton.Enabled); 
        
            mainPage.AddItemToCart(); 
            Assert.AreEqual("Product successfully added to your shopping cart", mainPage.ReturnConfirmationMessage().Text);
        
            mainPage.ClicklContinueShoppingButton();
            mainPage.MoveToCartList();
            var productName = mainPage.FindProductName();
            Assert.AreEqual(true, productName.Displayed); 
        }


        [Test, Description("Run an empty search query")]
        public void SearchfiledTest()
        {
            mainPage.NavigateOnPage(mainPage.pageURL);

            var navigationBar = mainPage.RunEmptySearch();
            Assert.AreEqual("Search", navigationBar.Text);
        }


        [Test, Description("Select a checkbox")]
        public void CheckBoxTest()
        {
            mainPage.NavigateOnPage(mainPage.pageURL);

            dressesPage = mainPage.ClickBarDressesButton();
            var checkbox = dressesPage.SelectCheckbox();
            Assert.AreEqual(true, checkbox.Selected);
        }


        [Test, Description("Get logo's alternative text")]
        public void GetAttributeTest()
        {
            mainPage.NavigateOnPage(mainPage.pageURL);

            var logo = driver.FindElement(By.XPath("//img[@class='logo img-responsive']"));
            Assert.AreEqual("My Store", logo.GetAttribute("alt"));
        }


        [Test, Description("Navigate to women page, check names the number of subcategories")]
        public void GoToWomenPage()
        {
            mainPage.NavigateOnPage(mainPage.pageURL);
            womenPage = mainPage.ClickBarWomenButton();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("WOMEN ", womenPage.ReturnCategoryName().Text);
                Assert.AreEqual(2, womenPage.FindSubCategories().Count);
                Assert.AreEqual("TOPS", womenPage.ReturnTopsSubCatText().Text);
                Assert.AreEqual("DRESSES", womenPage.ReturnDressesSubCatText().Text);
            }
            );
        }

        [Test]
        public void GoToTopsPage()
        {
            mainPage.NavigateOnPage(mainPage.pageURL);
            womenPage = mainPage.ClickBarWomenButton();
            topsPage = womenPage.ClickTopsSubCatButton();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("TOPS ", topsPage.ReturnCategoryName().Text);
                Assert.AreEqual(true, topsPage.SelectSizeCheckbox(topsPage.SSizeCheckboxXPath).Selected);
                Assert.AreEqual(true, topsPage.SelectSizeCheckbox(topsPage.MSizeCheckboxXPath).Selected);
                Assert.AreEqual(true, topsPage.SelectSizeCheckbox(topsPage.LSizeCheckboxXPath).Selected);
                Assert.AreEqual(true, topsPage.isColorButtonEnabled(topsPage.WhiteColorXPath));
                Assert.AreEqual(true, topsPage.isColorButtonEnabled(topsPage.BlackColorXPath));
                Assert.AreEqual(true, topsPage.isColorButtonEnabled(topsPage.OrangeColorXPath));
                Assert.AreEqual(true, topsPage.isColorButtonEnabled(topsPage.BlueColorXPath));
            }
            );
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}