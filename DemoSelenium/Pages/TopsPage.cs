using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace DemoSelenium.Pages
{
    class TopsPage : Page
    {
        private string CatNameXPath = "//span[@class='cat-name']";

        private string SSizeCheckboxXPath = "//*[@id='layered_id_attribute_group_1']";
        private string MSizeCheckboxXPath = "//*[@id='layered_id_attribute_group_2']";
        private string LSizeCheckboxXPath = "//*[@id='layered_id_attribute_group_3']";

        private string WhiteColorXPath = "//*[@id='layered_id_attribute_group_8']";
        private string BlackColorXPath = "//*[@id='layered_id_attribute_group_11']";
        private string OrangeColorXPath = "//*[@id='layered_id_attribute_group_13']";
        private string BlueColorXPath = "//*[@id='layered_id_attribute_group_14']";

        public TopsPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ReturnCategoryName()
        {
            return driver.FindElement(By.XPath(CatNameXPath));
        }

        public IWebElement SelectSSize()
        {
            var checkbox = driver.FindElement(By.XPath(SSizeCheckboxXPath));
            checkbox.Click();
            return checkbox;
        }

        public IWebElement SelectMSize()
        {
            var checkbox = driver.FindElement(By.XPath(MSizeCheckboxXPath));
            checkbox.Click();
            return checkbox;
        }

        public IWebElement SelectLSize()
        {
            var checkbox = driver.FindElement(By.XPath(LSizeCheckboxXPath));
            checkbox.Click();
            return checkbox;
        }

        public Boolean WhiteColorEnabled()
        {
            return driver.FindElement(By.XPath(WhiteColorXPath)).Enabled;
        }

        public Boolean BlackColorEnabled()
        {
            return driver.FindElement(By.XPath(BlackColorXPath)).Enabled;
        }

        public Boolean OrangeColorEnabled()
        {
            return driver.FindElement(By.XPath(OrangeColorXPath)).Enabled;
        }

        public Boolean BlueColorEnabled()
        {
            return driver.FindElement(By.XPath(BlueColorXPath)).Enabled;
        }
    }
}
