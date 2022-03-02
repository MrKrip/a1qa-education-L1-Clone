using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Elements;
using Task3.Util;

namespace Task3.Pages
{
    class UploadDownloadPage : BasePage
    {
        private static Label Def = new Label(By.XPath("//div[contains(@class,'main-header') and text()='Upload and Download']"), "Default element");
        private Button UploadDownloadCategory = new Button(By.XPath("//div[contains(@class,'element-list')]//*[contains(.,'Upload and Download') and contains(@class,'btn')]"), "Upload and Download button in category submenu");
        private Button Download = new Button(By.Id("downloadButton"), "Download button");
        private Label FormLabel = new Label(By.XPath("//div[contains(@class,'element-group') and contains(.,'Forms')]"), "Form label");
        private Input Upload = new Input(By.Id("uploadFile"), "Upload input");
        private Label UploadPath = new Label(By.Id("uploadedFilePath"), "Upload path");
        private static string name = "Upload and Download page";

        public UploadDownloadPage() : base(name, Def)
        {

        }

        public UploadDownloadPage ClickUplDownCategory()
        {
            FormLabel.MoveToElement();
            UploadDownloadCategory.Click();
            return this;
        }

        public bool IsFileDownloaded(string path)
        {
            try
            {
                Download.Click();
                WaiterUtil.WaitFileExist(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UploadDownloadPage UploadFile(string path)
        {
            Upload.SendKeys(path);
            return this;
        }

        public bool IsfileUploaded(string fileName)
        {
            return UploadPath.GetText().Contains(fileName);
        }
    }
}
