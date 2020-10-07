using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace vbr.pages
{
    class PBankiDeposity
    {
        /// <summary> input ввода суммы для расчета </summary>
        [FindsBy(How = How.CssSelector, Using = "input[id='formSearch-Sum']")]
        public IWebElement InputAmount { get; set; }
        /// <summary>Наличие поля с названием Депозит</summary>
        [FindsBy(How = How.CssSelector, Using = "div#productsTable div:first-child tbody th:last-child")]
        public IWebElement deposit{ get; set; }
        /// <summary> iframe c изображением индексов вкладов </summary>
        [FindsBy(How = How.CssSelector, Using = "iframe[title = 'Индекс']")]
        public IWebElement IndexIframe { get; set; }
        /// <summary> изображения в ifrmame индексах вкладов </summary>
        [FindsBy(How = How.CssSelector, Using = "div#GraphContainer img")]
        public IWebElement ImageOfDepositIndexes { get; set; }


    }
}
