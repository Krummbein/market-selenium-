using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace DemoSelenium.Pages
{
    class TopsPage : Page
    {
        private string CatNameXPath = "//span[@class='cat-name']";
        private readonly string sSizeCheckboxXPath = "//*[@id='layered_id_attribute_group_1']";
        private readonly string mSizeCheckboxXPath = "//*[@id='layered_id_attribute_group_2']";
        private readonly string lSizeCheckboxXPath = "//*[@id='layered_id_attribute_group_3']";
        private readonly string whiteColorXPath = "//*[@id='layered_id_attribute_group_8']";
        private readonly string blackColorXPath = "//*[@id='layered_id_attribute_group_11']";
        private readonly string orangeColorXPath = "//*[@id='layered_id_attribute_group_13']";
        private readonly string blueColorXPath = "//*[@id='layered_id_attribute_group_14']";

        public string SSizeCheckboxXPath { get => sSizeCheckboxXPath; }
        public string MSizeCheckboxXPath { get => mSizeCheckboxXPath; }
        public string LSizeCheckboxXPath { get => lSizeCheckboxXPath; }
        public string WhiteColorXPath { get => whiteColorXPath; }
        public string BlackColorXPath { get => blackColorXPath; }
        public string OrangeColorXPath { get => orangeColorXPath; }
        public string BlueColorXPath { get => blueColorXPath; }
        public TopsPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ReturnCategoryName()
        {
            return driver.FindElement(By.XPath(CatNameXPath));
        }

        public IWebElement SelectSizeCheckbox(string SizeCheckboxXPath)
        {
            var checkbox = driver.FindElement(By.XPath(SizeCheckboxXPath));
            checkbox.Click();
            return checkbox;
        }

        public bool isColorButtonEnabled(string ColorXPath)
        {
            return driver.FindElement(By.XPath(ColorXPath)).Enabled;
        }
    }
}
