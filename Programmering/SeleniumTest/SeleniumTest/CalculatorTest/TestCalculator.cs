using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CalculatorTest
{
    [TestClass]
    public class TestCalculator
    {

        private static string driverFolder = "C:\\SeleniumDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _driver = new ChromeDriver();
        }

        [TestInitialize]
        public void Init()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
        }

        [TestMethod]
        public void TestCalculaterAddition()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            
            IWebElement inputElement1 = _driver.FindElement(By.Id("number1"));
            inputElement1.SendKeys("5"); //Skriver input i første inputelement

            IWebElement inputElement2 = _driver.FindElement(By.Id("number2"));
            inputElement2.SendKeys("10"); //Skriver input i andet inputelement

            IWebElement selectElement = _driver.FindElement(By.Id("operation"));
            SelectElement operation = new SelectElement(selectElement);
            operation.SelectByText("+"); //Vælger i select element

            IWebElement calculateButton = _driver.FindElement(By.Id("calculate"));
            calculateButton.Click(); //Klikker på en knap

            var OutputResult = wait.Until(ExpectedConditions.ElementExists(By.Id("result"))); //Venter på at element med "result" findes

            IWebElement outputResult = _driver.FindElement(By.Id("result"));
            string text = outputResult.Text; //Kigger på output element

            Assert.AreEqual("15", text); //Assert testen.
        }

        [TestMethod]
        public void TestCalculaterSubstraction()
        {
            IWebElement inputElement1 = _driver.FindElement(By.Id("number1"));
            inputElement1.SendKeys("10");

            IWebElement inputElement2 = _driver.FindElement(By.Id("number2"));
            inputElement2.SendKeys("5");

            IWebElement selectElement = _driver.FindElement(By.Id("operation"));
            SelectElement operation = new SelectElement(selectElement);
            operation.SelectByText("-");

            IWebElement calculateButton = _driver.FindElement(By.Id("calculate"));
            calculateButton.Click();

            IWebElement outputResult = _driver.FindElement(By.Id("result"));
            string text = outputResult.Text;

            Assert.AreEqual("5", text);
        }

        [TestMethod]
        public void TestCalculaterMultiplication()
        {
            IWebElement inputElement1 = _driver.FindElement(By.Id("number1"));
            inputElement1.SendKeys("5");

            IWebElement inputElement2 = _driver.FindElement(By.Id("number2"));
            inputElement2.SendKeys("10");

            IWebElement selectElement = _driver.FindElement(By.Id("operation"));
            SelectElement operation = new SelectElement(selectElement);
            operation.SelectByText("*");

            IWebElement calculateButton = _driver.FindElement(By.Id("calculate"));
            calculateButton.Click();

            IWebElement outputResult = _driver.FindElement(By.Id("result"));
            string text = outputResult.Text;

            Assert.AreEqual("50", text);
        }

        [TestMethod]
        public void TestCalculaterDivide()
        {
            IWebElement inputElement1 = _driver.FindElement(By.Id("number1"));
            inputElement1.SendKeys("10");

            IWebElement inputElement2 = _driver.FindElement(By.Id("number2"));
            inputElement2.SendKeys("5");

            IWebElement selectElement = _driver.FindElement(By.Id("operation"));
            SelectElement operation = new SelectElement(selectElement);
            operation.SelectByText("/");

            IWebElement calculateButton = _driver.FindElement(By.Id("calculate"));
            calculateButton.Click();

            IWebElement outputResult = _driver.FindElement(By.Id("result"));
            string text = outputResult.Text;

            Assert.AreEqual("2", text);
        }
    }
}
