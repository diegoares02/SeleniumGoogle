using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumGoogle
{
    [TestFixture]
    public class GoogleTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://www.math.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestCaseSource("Right")]
        //[Test]
        public void ThePrueba1Test(string operation, string answer)
        {
            driver.Navigate().GoToUrl(baseURL + "/students/calculators/source/basic.htm");
            Operation(operation);
            driver.FindElement(By.Name("DoIt")).Click();
            IWebElement resElement= driver.FindElement(By.Name("Input"));
            string res = resElement.GetAttribute("value");
            Assert.AreEqual(answer, res);
        }
        [TestCaseSource("Wrong")]
        public void ThePrueba2Test(string operation, string answer)
        {
            driver.Navigate().GoToUrl(baseURL + "/students/calculators/source/basic.htm");
            Operation(operation);
            driver.FindElement(By.Name("DoIt")).Click();
            IWebElement resElement = driver.FindElement(By.Name("Input"));
            string res = resElement.GetAttribute("value");
            Assert.AreEqual(answer, res);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        private IEnumerable Right 
        {
            get { return GetValues(); }
        }

        private IEnumerable Wrong
        {
            get { return GetWrongValues(); }
        }

        private IEnumerable GetWrongValues()
        {
            var doc =
               XDocument.Load("C:\\Users\\Administrator\\Documents\\GitHub\\SeleniumGoogle\\SeleniumGoogle\\Wrong.xml");
            return from vars in doc.Descendants("vars")
                   let operation = vars.Attribute("operation").Value
                   let answer = vars.Attribute("answer").Value
                   select new object[] { operation, answer };
        }
        private IEnumerable GetValues()
        {
            var doc =
                XDocument.Load("C:\\Users\\Administrator\\Documents\\GitHub\\SeleniumGoogle\\SeleniumGoogle\\Right.xml");
            return from vars in doc.Descendants("vars")
                let operation = vars.Attribute("operation").Value
                let answer = vars.Attribute("answer").Value
                select new object[] {operation, answer};
        }

        #region Operations
        private void Operation(string op)
        {
            foreach (var operation in op)
            {
                switch (operation)
                {
                    case '1':
                    {
                        driver.FindElement(By.Name("one")).Click();
                        break;
                    }
                    case '2':
                    {
                        driver.FindElement(By.Name("two")).Click();
                        break;
                    }
                    case '3':
                    {
                        driver.FindElement(By.Name("three")).Click();
                        break;
                    }
                    case '4':
                    {
                        driver.FindElement(By.Name("four")).Click();
                        break;
                    }
                    case '5':
                    {
                        driver.FindElement(By.Name("five")).Click();
                        break;
                    }
                    case '6':
                    {
                        driver.FindElement(By.Name("six")).Click();
                        break;
                    }
                    case '7':
                    {
                        driver.FindElement(By.Name("seven")).Click();
                        break;
                    }
                    case '8':
                    {
                        driver.FindElement(By.Name("eight")).Click();
                        break;
                    }
                    case '9':
                    {
                        driver.FindElement(By.Name("nine")).Click();
                        break;
                    }
                    case '0':
                    {
                        driver.FindElement(By.Name("zero")).Click();
                        break;
                    }
                    case '+':
                    {
                        driver.FindElement(By.Name("plus")).Click();
                        break;
                    }
                    case '-':
                    {
                        driver.FindElement(By.Name("minus")).Click();
                        break;
                    }
                    case '*':
                    {
                        driver.FindElement(By.Name("times")).Click();
                        break;
                    }
                    case '/':
                    {
                        driver.FindElement(By.Name("div")).Click();
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
