using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Task2.Test_conditions;
using Task3.Drivers;
using Task3.Pages;
using Task3.Util;

namespace Task3
{
    public class Tests : BaseTest
    {
        [Test]
        public void TestCase1()
        {
            HomePage Home = new HomePage("Home page");
            Dictionary<string, string> TestData = ParseJSON.GetDataFile<Dictionary<string, string>>(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\AlertData.json");
            AlertsPage Alerts = new AlertsPage("Alert Page");
            DriverUtil.GoToPage(Config["MainPageUrl"]);
            Assert.IsTrue(Home.IsPageOpened(), "Home page not open");
            Home.ClickAlertsLink();
            Assert.IsTrue(Alerts.ChooseAlertCategory(), "Alert not selected");
            Assert.IsTrue(Alerts.IsDefaultAlertOpened(), "Default alert not open");
            Assert.IsTrue(Alerts.IsAlertTextMatch(TestData["DefaultAlert"]), "Default alert text does not match test data");
            Assert.IsTrue(Alerts.ConfirmAlert().IsAlertClosed(), "Alert not closed");
            Assert.IsTrue(Alerts.IsConfirmAlertOpened(), "Confirm alert not open");
            Assert.IsTrue(Alerts.IsAlertTextMatch(TestData["ConfirmAlert"]), "Confirm alert text does not match test data");
            Assert.IsTrue(Alerts.ConfirmAlert().IsAlertClosed(), "Alert not closed");
            Assert.IsTrue(Alerts.IsConfirmAlertWork(TestData["ConfirmResult"]), $"The button '{TestData["ConfirmResult"]}' did not appear next to the button");
            Assert.IsTrue(Alerts.IsPromptAlertOpened(), "Prompt alert not open");
            string RandStr = Alerts.RandomFillAlertField();
            Assert.IsTrue(Alerts.ConfirmAlert().IsAlertClosed(), "Alert not closed");
            Assert.IsTrue(Alerts.IsPromptAlertWork(RandStr), $"Prompt alert text does not match rand string({RandStr})");
        }
    }
}