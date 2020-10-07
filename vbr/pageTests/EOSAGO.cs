using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace vbr
{
    [TestFixture]
    class EOSAGO
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://moskva.vbr.ru/strahovanie/eosago/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        [Category("notCompleted")]
        public void СompleteEOSAGO()
        {
            //Фамилия
            IWebElement element = driver.FindElement(By.Id("ContractRequest_TransportOwner_LastName"));
            element.SendKeys("Чиров");
            //Имя
            element = driver.FindElement(By.Id("ContractRequest_TransportOwner_FirstName"));
            element.SendKeys("Андрей");
            //Отчество
            element = driver.FindElement(By.Id("ContractRequest_TransportOwner_MiddleName"));
            element.SendKeys("Валерьевич");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
            //телефон
            element = driver.FindElement(By.Id("ContractRequest_TransportOwner_Phone"));
            element.SendKeys("9999999999");
            //дата рождения
            element = driver.FindElement(By.Id("ContractRequest_TransportOwner_BirthDate"));
            element.SendKeys("10.12.2000");
            //пол
            element = driver.FindElement(By.CssSelector("input[id='ContractRequest.TransportOwner.IsMale']+span"));
            element.Click();
            element = driver.FindElement(By.CssSelector("ul[id='ContractRequest.TransportOwner.IsMaleUl'] li span:first-child"));
            element.Click();
            element = driver.FindElement(By.Id("ContractRequest_TransportOwner_Email"));
            element.SendKeys("hekewa2809@maileze.net");
            //серия паспорта
            element = driver.FindElement(By.Id("ContractRequest_TransportOwner_PersonDocument_Serial"));
            element.SendKeys("4444");
            //номер паспорта
            element = driver.FindElement(By.Id("ContractRequest_TransportOwner_PersonDocument_Number"));
            element.SendKeys("999999");
            //дата выдачи паспорта
            element = driver.FindElement(By.Id("ContractRequest_TransportOwner_PersonDocument_DateIssue"));
            element.SendKeys("10.10.2018");
            //кем выдан
            element = driver.FindElement(By.Id("ContractRequest_TransportOwner_PersonDocument_Issued"));
            element.SendKeys("тп уфмс");
            //адрес места жительства
            element = driver.FindElement(By.Id("OwnerActualLocalityText"));
            element.SendKeys("г Москва, д Картмазово, ул Московская, д 2, кв 1");
            IWebElement HideLi = driver.FindElement(By.CssSelector("#ui-id-2 li:first-child"));
            HideLi.Click();
            //чекбокс соглашаюсь
            driver.FindElement(By.CssSelector("label[for='ConsentProcessingPersonalData']")).Click();
            //Тест не дописан. Так вообще не стоит делать.
            //второй шаг
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}
