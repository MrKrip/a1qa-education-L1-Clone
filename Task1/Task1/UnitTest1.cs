using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task1
{
    public class Tests
    {
        
        [Test]
        public void Task1_TestCase1_Chrome()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            var driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
            var Title = driver.FindElements(By.XPath("//div[contains(@id,\"content\")]//following::h3"));
            Assert.IsTrue(Title.Count>0,"Title not found");
            var TableHeaders = driver.FindElements(By.XPath("//table[contains(@id,\"table1\")]//thead//th"));
            Assert.IsTrue(TableHeaders.Count > 3, "Table Headers not found");
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
            var AddElementButton = driver.FindElements(By.XPath("//button[@onclick=\"addElement()\"]"));
            Assert.IsTrue(AddElementButton.Count>0,"Add element button not found");
            var DeleteButton = driver.FindElements(By.XPath("//button[@onclick=\"deleteElement()\"]"));
            Assert.IsTrue(DeleteButton.Count == 0, "Delete button found");
            driver.Quit();
        }
    }
}