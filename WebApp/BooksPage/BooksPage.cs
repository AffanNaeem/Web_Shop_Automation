using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Shop_Automation  
{
    public class BooksPage : CorePage
    {
        #region Locators
        By BooksBtn= By.XPath("/html/body/div[4]/div[1]/div[2]/ul[1]/li[1]/a");
        #endregion

        public void SearchBooks()
        {
           driver.FindElement(BooksBtn).Click(); 
        }
    }
}
