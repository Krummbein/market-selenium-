using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DemoSelenium
{
    public class Tests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            var xPathLocator = "\\div";
            var cSShLocator = "div";
            var element = driver.FindElement(By.XPath(xPathLocator));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}