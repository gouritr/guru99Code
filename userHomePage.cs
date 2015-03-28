using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;

namespace ProjectGuru99
{
    class userHomePage:BasePage
    {
        [FindsBy(How = How.LinkText, Using = "MOBILE")]
        IWebElement linkMobile;

         public userHomePage(IWebDriver driver) : base(driver)
        {

        }
        public MobilePage ClickLinkMobile()
         {
             linkMobile.Click();
             MobilePage m = new MobilePage(_Driver);
             PageFactory.InitElements(_Driver, m);
             return m;
         }
       
    }
}
