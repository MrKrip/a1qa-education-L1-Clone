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
            LoggerUtil.MakeLog(TestCaseMark + "Test Case 1 start" + TestCaseMark);
            HomePage Home = new HomePage();
            Dictionary<string, string> TestData = ParseJSON.GetDataFile<Dictionary<string, string>>(ConfigClass.AlertData);
            AlertsPage Alerts = new AlertsPage();
            Assert.IsTrue(Home.IsPageOpened(), "Home page not open");
            Home.ClickAlertsLink();
            Assert.IsTrue(Alerts.IsAlertCategoryOpen(), "Alert not selected");
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
            HomePage Home = new HomePage();
            NestedFramesPage NestedFrames = new NestedFramesPage();
            FramesPage FramePage = new FramesPage();
            Dictionary<string, string> TestData = ParseJSON.GetDataFile<Dictionary<string, string>>(ConfigClass.AlertData);
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
        [TestCase(0)]
        public void TestCase3(int id)
        {
            LoggerUtil.MakeLog(TestCaseMark + "Test Case 3 start" + TestCaseMark);
            List<RegistrationModel> TestData = ParseJSON.GetDataFile<List<RegistrationModel>>(ConfigClass.WebTablesData);
            HomePage Home = new HomePage();
            WebTabelsPage webTabels = new WebTabelsPage();
            Assert.IsTrue(Home.IsPageOpened(), "Home page not open");
            Home.ClickElementsLink();
            Assert.IsTrue(webTabels.ChooseWebTablesCategory().IsPageOpened(), "Web tables page not open");
            Assert.IsTrue(webTabels.ClickAddButton().IsRegistrationFromOpened(), "Registration form not open");
            webTabels.FillRegistrationForm(TestData[id]).SubmitRegistrationForm();
            Assert.IsTrue(webTabels.IsRecordAdded(TestData[id]), "New record not added");
            Assert.IsFalse(webTabels.DeleteRecord(TestData[id]).IsRecordAdded(TestData[id]), "Record is not deleted");
        }

        [Test]
        public void TestCase4()
        {
            LoggerUtil.MakeLog(TestCaseMark + "Test Case 4 start" + TestCaseMark);
            HomePage Home = new HomePage();
            BrowserWindowsPage browserWindows = new BrowserWindowsPage();
            LinksPage Links = new LinksPage();
            Dictionary<string, string> TestData = ParseJSON.GetDataFile<Dictionary<string, string>>(ConfigClass.BrowserWindowsData);
            Assert.IsTrue(Home.IsPageOpened(), "Home page not open");
            Home.ClickAlertsLink();
            browserWindows.ChooseWindowsCategory();
            Assert.IsTrue(browserWindows.IsPageOpened(), "Browser window page not open");
            (bool TabOpen, bool TabTextCheck) = browserWindows.ClickNewTabButton().IsTabOpened(TestData["NewTabText"]);
            Assert.IsTrue(TabOpen, "New tab not open");
            Assert.IsTrue(TabTextCheck, "Tab text not match test data ");
            DriverUtil.CloseTab();
            DriverUtil.SwitchToWindow(0);
            Assert.IsTrue(browserWindows.IsPageOpened(), "Browser window page not open");
            Assert.IsTrue(Links.ChooseLinksCategory().IsPageOpened(), "Links page not open");
            Links.ClickHomeLink();
            Assert.IsTrue(Home.IsPageOpened(), "Home page not open");
            Assert.IsTrue(Links.ReturnToLinksPage().IsPageOpened(), "Links page not open");
        }

        [Test]
        public void TestCase6()
        {
            LoggerUtil.MakeLog(TestCaseMark + "Test Case 6 start" + TestCaseMark);
            HomePage Home = new HomePage();
            DatePickerPage datePicker = new DatePickerPage();
            Assert.IsTrue(Home.IsPageOpened(), "Home page not open");
            Home.ClickWidgetsButton();
            (bool SelectDate, bool DateAndTime) = datePicker.ClickDatePickerCategory().IsDateCorrect();
            Assert.IsTrue(SelectDate, "Select date is not matched with date now");
            Assert.IsTrue(DateAndTime, "Date and time not matched with date and time now");
            string value = datePicker.FindDate();
            Assert.IsTrue(datePicker.IsFabruary29DateCorrect(value),"Select date is not correct");
        }
    }
}