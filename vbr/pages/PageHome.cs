using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace vbr.pages
{
    class PageHome
    {
        /// <summary>таб вкладов </summary>
        [FindsBy(How = How.CssSelector, Using = "div[class='btn-product-block btn-product-block-main'] button:first-child")]
        public IWebElement TabDeposits { get; set; }
        ///<summary> поле ввода суммы вклада </summary> 
        [FindsBy(How = How.CssSelector, Using = "input[placeholder = 'Сумма вклада']")]
        public IWebElement InputAmount { get; set; }
        /// <summary> input c выпадающим списком для ввода месяца по умолчанию 1 год </summary>
        [FindsBy(How = How.CssSelector, Using = "#react-select-3-input")]
        public IWebElement InputDeadline { get; set; }
        /// <summary> button перехода на страницу вкладов </summary>
        [FindsBy(How = How.CssSelector, Using = "button[class='btn -h56']")]
        public IWebElement ButtonToSelect { get; set; }
        //селектор первого изображения в блоке меню
        [FindsBy(How = How.CssSelector, Using = "div.mobile-scroll-container div div:first-child img")]
        public IWebElement FirstImageInNews { get; set; }
        //кнопка меню на новом сайте
        [FindsBy(How = How.CssSelector, Using = "div.header-menu-btn")]
        public IWebElement MenuBtn { get; set; }
   
    }
}
