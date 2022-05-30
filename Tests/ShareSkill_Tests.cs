using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using OpenQA.Selenium;
using System.IO;
using System.Data;
using System.Diagnostics;
using Competition_task_2.Utilities;
using Competition_task_2.Pages;

namespace CompetitionTasks.Pages
{
    [TestFixture]

    public class ShareSkillDetails_Tests : CommonDriver
    {
        [Test, Order(1)]
        public void ExcelReaderMethod()
        {
            try
            {
                ExcelOperations.ClearData();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        [Test, Order(2)]
        public void CreateShareSkillDetails_Test()
        {
            ExcelOperations.ReadDataTable(stream, "ShareSkill");
            test = extent.CreateTest("test1").Info("Test started");

            //Profile create page object initialization and definition
            ShareSkillPage shareSkillPageObj = new ShareSkillPage();
            shareSkillPageObj.ShareSkillSteps(driver);
            test.Log(Status.Info, "shareskill details saved");
            test.Log(Status.Pass, "Test passed");



        }
        [Test, Order(3)]
        public void EditSkillDetails_Test()
        {
            ExcelOperations.ReadDataTable(stream, "ManageListing");
            test = extent.CreateTest("test2").Info("Test started");
            //edit
            ManageListingPage manageListingPageObj = new ManageListingPage();

            manageListingPageObj.EditingSteps(driver);
            test.Log(Status.Info, "shareskill details edited");
            test.Log(Status.Pass, "Test passed");

            // Assert.That(editCheck.Text == "Service Type", " not created successfully");

        }
        [Test, Order(4)]
        public void DeleteSkillDetails_Tests()
        {
            test = extent.CreateTest("test3").Info("Test started");
            ManageListingPage manageListingPageObj = new ManageListingPage();
            manageListingPageObj.deleteSteps(driver);
            test.Log(Status.Info, "shareskill details deleted");
            test.Log(Status.Pass, "Test passed");
            //takeScreenshot(driver);
            // IWebElement editCheck = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/thead/tr/th[5]"));
            // Assert.That(editCheck.Text == "Service Type", " not created successfully");
        }


    }
}

