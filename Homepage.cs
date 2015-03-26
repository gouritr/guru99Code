using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace ProjectGuru99
{
    class Homepage:BasePage
    {
        string expectedTitle = "Home page";


        [FindsBy(How = How.LinkText,Using = "MOBILE")]
        IWebElement linkMobile;
        
          public  Homepage(IWebDriver driver):base(driver)
        {

         }

        public MobilePage clickMobile()
          {
              linkMobile.Click();
              MobilePage m = new MobilePage(_Driver);
              PageFactory.InitElements(_Driver,m );
              return m;

          }


        public void vfTitle()
        {
            string actual = _Driver.Title.ToString();
            Assert.AreEqual(expectedTitle, actual);
        }

        
    }
}
