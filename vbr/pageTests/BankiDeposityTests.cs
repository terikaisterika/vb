using NUnit.Framework;
using System;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using vbr.pages;


namespace vbr.pageTests
{
    [TestFixture]
    class BankiDeposityTests
    {
        IWebDriver driver;
        ChromeOptions options;
        IWebElement element;
        PBankiDeposity pBankiDeposity = new PBankiDeposity();
        //string inputValue = "50000";
        string actualResult;
        string URL = "https://www.vbr.ru/banki/deposity/";

        
        [SetUp]
        public void IInitialize()
        {
            options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
        }

        /* 
         * Проверка того, что изображение индексов вкладов загружено и имеет 
         * naturalWidth больше 0
         */
        [Test]
        [Category("oldSite")]
        public void ImageIsUploaded()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            PageFactory.InitElements(driver, pBankiDeposity);
            element = pBankiDeposity.IndexIframe;
            //js.ExecuteScript("arguments[0].scrollIntoView();", element);
            driver.SwitchTo().Frame(element);
            element = pBankiDeposity.ImageOfDepositIndexes;
            actualResult = js.ExecuteScript("return arguments[0].naturalWidth;", element).ToString();
            
            Assert.AreNotEqual(0, Int32.Parse(actualResult));
        }

        [TearDown]
        public void EndTest()
        {
            //driver.Close();
            driver.Quit();
        }
    }


}
