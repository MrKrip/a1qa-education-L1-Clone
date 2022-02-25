using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Task2.Test_conditions;
using Task3.Drivers;
using Task3.Models;
using Task3.Pages;
using Task3.Util;

namespace Task3
{
    public class Tests : BaseTest
    {
        [Test]
        public void TestCase1()
        {            
            LoggerUtil.MakeLog(TestCaseMark+"Test Case 1 start"+TestCaseMark);
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

        [Test]
        public void TestCase2()
        {
            LoggerUtil.MakeLog(TestCaseMark + "Test Case 2 start" + TestCaseMark);
            HomePage Home = new HomePage("Home page");
            NestedFramesPage NestedFrames = new NestedFramesPage("Nested frames Page");
            FramesPage FramePage = new FramesPage("Frames Page");
            DriverUtil.GoToPage(Config["MainPageUrl"]);
            Dictionary<string, string> TestData = ParseJSON.GetDataFile<Dictionary<string, string>>(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\AlertData.json");
            Assert.IsTrue(Home.IsPageOpened(), "Home page not open");
            Home.ClickAlertsLink();
            NestedFrames.ChooseNestedFrameCategory();
            Assert.IsTrue(NestedFrames.IsPageOpened(), "Nested frames page not open");
            (bool Parent, bool Child) = NestedFrames.IsFramesCorrect(TestData["ParentFrameText"], TestData["ChildFarmeText"]);
            Assert.IsTrue(Parent, "Parent frame text does not match test data");
            Assert.IsTrue(Child, "Child frame text does not match test data");
            FramePage.ChooseFrameCategory();
            Assert.IsTrue(FramePage.IsPageOpened(), "Frames page not open");
            Assert.IsTrue(FramePage.IsFrameTextMatch(), "Frames texts does not match");
        }

        [Test]
        public void TestCase3()
        {
            LoggerUtil.MakeLog(TestCaseMark + "Test Case 3 start" + TestCaseMark);
            List<RegistrationModel> TestData = ParseJSON.GetDataFile<List<RegistrationModel>>(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\WebTablesData.json");
            HomePage Home = new HomePage("Home page");
            WebTabelsPage webTabels = new WebTabelsPage("Web tables page");
            DriverUtil.GoToPage(Config["MainPageUrl"]);
            Assert.IsTrue(Home.IsPageOpened(), "Home page not open");
            Home.CleckElementsLink();
            Assert.IsTrue(webTabels.ChooseWebTablesCategory().IsPageOpened(), "Web tables page not open");
            Assert.IsTrue(webTabels.ClickAddButton().IsRegistrationFromOpened(), "Registration form not open");
            webTabels.FillRegistrationForm(TestData[0]).SubmitRegistrationForm();
            Assert.IsTrue(webTabels.IsRecordAdded(TestData[0]), "New record not added");
            Assert.IsFalse(webTabels.DeleteRecord(TestData[0]).IsRecordAdded(TestData[0]), "Record is not deleted");
        }

        [Test]
        public void TestCase4()
        {
            LoggerUtil.MakeLog(TestCaseMark + "Test Case 4 start" + TestCaseMark);
            HomePage Home = new HomePage("Home page");
            BrowserWindowsPage browserWindows = new BrowserWindowsPage("Browser windows page");
            LinksPage Links = new LinksPage("Links page");
            Dictionary<string, string> TestData = ParseJSON.GetDataFile<Dictionary<string, string>>(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\BrowserWindowsData.json");
            DriverUtil.GoToPage(Config["MainPageUrl"]);
            Assert.IsTrue(Home.IsPageOpened(), "Home page not open");
            Home.ClickAlertsLink();
            browserWindows.ChooseWindowsCategory();
            Assert.IsTrue(browserWindows.IsPageOpened(), "Browser window page not open");
            (bool UrlCheck, bool TabTextCheck) = browserWindows.ClickNewTabButton().IsTabOpened(TestData["Url"], TestData["NewTabText"]);
            Assert.IsTrue(UrlCheck, "Url does not match test data ");
            Assert.IsTrue(TabTextCheck, "Tab text not match test data ");
            browserWindows.CloseTab();
            Assert.IsTrue(browserWindows.IsPageOpened(), "Browser window page not open");
            Assert.IsTrue(Links.ChooseLinksCategory().IsPageOpened(), "Links page not open");
            Links.ClickHomeLink();
            Assert.IsTrue(Home.IsPageOpened(), "Home page not open");
            Assert.IsTrue(Links.ReturnToLinksPage().IsPageOpened(), "Links page not open");
        }
    }
}