using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using ExcelDataReader;
using Competition_task_2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data;

namespace Competition_task_2.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlreport;
        public static ExtentTest test;
        public static string ScreenshotFileName;
        public static FileStream stream;


        [OneTimeSetUp]

        public void LoginFunction()

        {
            string fileName = @"T:\Salma_Testing\IndustryConnect\Internship\Competition_Task\Competition_SS\CompetitionTask\InputFile\ExcelOperationsDetails.xlsx";
            //open file and returns as stream
            stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            ExcelOperations.ReadDataTable(stream, "LoginSheet");

            //extent report
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"T:\Salma_Testing\IndustryConnect\Internship\Competition_Task\Competition_SS\CompetitionTask\InputFile\CommonDriver.html");
            extent.AttachReporter(htmlReporter);

            //open chrome
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginPages(driver);
        }

        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Close();
            extent.Flush();
        }
    }
}
