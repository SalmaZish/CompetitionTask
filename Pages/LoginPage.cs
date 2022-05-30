using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace Competition_task_2.Pages
{
    public class LoginPage
    {

        // IWebDriver driver
        public void LoginPages(IWebDriver mydriver)
        {
            // Open chrome browser

            mydriver.Manage().Window.Maximize();

            try
            {

                // Launch Blockchain-based skill exchange platform
                mydriver.Navigate().GoToUrl("http://localhost:5000/");
                // Click the sign in button

                IWebElement signin = mydriver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
                signin.Click();

                // Enter LoginId with valid data
                IWebElement emailid = mydriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
                emailid.SendKeys("salma.aftab15@gmail.com");

                // Enter password with valid data

                IWebElement password = mydriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
                password.SendKeys("Zish@4509");



                // Click Login button

                IWebElement login = mydriver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
                login.Click();

            }

            catch (Exception ex)
            {
                Assert.Fail("Login page did not launch successfully", ex.Message);
            }
        }
    }
}
