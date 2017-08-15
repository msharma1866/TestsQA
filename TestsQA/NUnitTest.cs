using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using TestsQA.Utilities;

namespace TestsQA
{
    class NUnitTest
    {
        IWebDriver driver = null;
       [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void GoogleTest()
        {
            // And now use this to visit Google
            driver.Navigate().GoToUrl("http://www.google.com");
            // Find the text input element by its name
            IWebElement query = driver.FindElement(By.Name("q"));
            // Enter something to search for
            query.SendKeys("Hello Selenium WebDriver!");
            // Submit the form based on an element in the form
            //query.Submit();
           driver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[3]/center/input[1]")).Click();          
        }

        [Test]
        public void SampleTest2()
        {

        }

        [Test]
        public void TestFocusComponents()
        {
            driver.Navigate().GoToUrl("https://www.incometaxindia.gov.in/Pages/tax-services/know-your-tan.aspx");
            // driver.FindElement(By.Id("wirlFirst")).SendKeys("Manish");
            driver.FindElement(By.XPath("//*[@id='ctl00_SPWebPartManager1_g_a3fc13cd_5236_4a93_8fa9_14ec9d4473b1_lblIRS']")).Click();
            //driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='wrapper']/section/div[2]/div[4]/div/div/h2")));
            // elem.Click();
            //IWebElement elem = driver.FindElement(By.Id("wirlAddress"));
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].focus();", elem);

            //driver.FindElement(By.XPath("//input[contains(@src, 'button_go.jpg')]")).Click();
            //*[@id="ctl00_ctl23_ctl00_ctl01_SmallSearchInputBox1_csr_sbox"]
        }

        [Test]
        public void TestSelectionList()
        {
            driver.Navigate().GoToUrl("http://www.incometaxindia.gov.in/Pages/communications/circulars.aspx");
            new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_SPWebPartManager1_g_5dfb7f33_6e2c_4d3e_b244_c2874a376703_ddlYear']"))).SelectByIndex(4);
        }

        [Test]
        public void OpenAppTest()
        {   
            string currentUrl = driver.Url = "http://testwisely.com/demo";
            string newUrl = driver.FindElement(By.LinkText("Page with iframes")).GetAttribute("href");
            driver.Navigate().GoToUrl(newUrl);
            driver.FindElement(By.LinkText("Link on page")).Click();
            driver.Navigate().GoToUrl(currentUrl);
        }

        [TearDown]
        public void EndTest()
        {
           // driver.Quit();
        }

    }
}
