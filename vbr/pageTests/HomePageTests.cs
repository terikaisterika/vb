using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using vbr.pages;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;


namespace vbr.HomePageTests
{
    [TestFixture]
    //[Category("")]
    class HomePageTests
    {
        ChromeOptions options;
        IWebDriver driver;
        IWebElement element;
        PageHome pageHome = new PageHome();
        PBankiDeposity pBankiDeposity = new PBankiDeposity();
        //вводимое значение
        string inputValue = "50000";
        string actualResult;
        string URL = "https://www.vbr.ru/";

        [SetUp]
        public void Initialize()
        { 
            options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
        }

        /*
         расчет на главной странице с переходом на список вкладов
         assert проверяет, что y в первом элементе списка появилось поле Депозит
         Без расчета на этом месте поле Ставка
         */
        [Test]
        [Category("newOldSite")]
        [Category("calculator")]
        public void CalculateOnTheDepositCalculator_DepositAmount()
        {
            Actions builder = new Actions(driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            PageFactory.InitElements(driver, pageHome);
            element = pageHome.TabDeposits;

            js.ExecuteScript("arguments[0].scrollIntoView();", element);        
            element.Click();
            
            element = pageHome.InputAmount;
            element.Clear();
            element.SendKeys(inputValue);
           
            element = pageHome.InputDeadline;
            builder.Click(element).SendKeys(Keys.ArrowUp).SendKeys(Keys.Return).Build().Perform();
            pageHome.ButtonToSelect.Click();
            //new page banki.deposity
            PageFactory.InitElements(driver, pBankiDeposity);
            actualResult = pBankiDeposity.deposit.GetAttribute("innerHTML"); 
            
            Assert.That("Доход", Does.Contain(actualResult));
        }

        /*
         расчет на главной странице с переходом на список вкладов
         assert проверяет, что сумма введенная на главной странице перенесена 
         поле ввода суммы на странице вкладов
         */
        [Test]
        [Category("newOldSite")]
        [Category("calculator")]
        public void CalculateOnTheDepositCalculator_AvailabilityOfTheDepositField()
        {
            Actions builder = new Actions(driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            PageFactory.InitElements(driver, pageHome);
            element = pageHome.TabDeposits;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);

            element.Click();
            element = pageHome.InputAmount;
            element.Clear();
            element.SendKeys(inputValue);
            element = pageHome.InputDeadline;
            builder.Click(element).SendKeys(Keys.ArrowUp).SendKeys(Keys.Return).Build().Perform();
            pageHome.ButtonToSelect.Click();
            //new page
            PageFactory.InitElements(driver, pBankiDeposity);
            actualResult = pBankiDeposity.InputAmount.GetAttribute("value").Replace(" ", "");
            Assert.AreEqual(Int32.Parse(actualResult), Int32.Parse(inputValue));
        }

        //первая картинка в блоке новостей загружена и имеет natulalWidth не равное 0
        [Test]
        [Category("newSite")]
        public void ImageIsUploaded()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            PageFactory.InitElements(driver, pageHome);
            element = pageHome.FirstImageInNews;
            string widthElement = js.ExecuteScript("return arguments[0].naturalWidth", pageHome.FirstImageInNews).ToString();
            Assert.AreNotEqual(0,  Int32.Parse(widthElement));
        }

        

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
            driver.Quit();
        }
        

        

    }
}
