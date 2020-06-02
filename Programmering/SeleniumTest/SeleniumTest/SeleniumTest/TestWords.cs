using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    [TestClass]
    public class TestWords
    {

        private static string driverFolder = "C:\\SeleniumDrivers";
        private static IWebDriver _driver;

        
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _driver = new ChromeDriver(driverFolder);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestDriverTitle()
        {

            _driver.Navigate().GoToUrl("http://localhost:3000/");
            string title = _driver.Title;
            Assert.AreEqual("Coding Template", title);

            IWebElement inputElement = _driver.FindElement(By.Id("input"));
            inputElement.SendKeys("Say Hello"); //Skriver i inputfelt

            IWebElement saveButtonElement = _driver.FindElement(By.Id("saveButton"));
            saveButtonElement.Click(); //klikker på "Save" knap

            IWebElement showButtonElement = _driver.FindElement(By.Id("showButton"));
            showButtonElement.Click(); //klikker på "show" knap

            IWebElement outputElement = _driver.FindElement(By.Id("output"));
            string text = outputElement.Text; //kigger på output felt

            Assert.AreEqual("Say Hello", text); //Assert testen.

        }
    }
}
