using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace ProjectGuru99
{
    class shareWishListPage:BasePage
    {


        [FindsBy(How = How.Id, Using = "email_address")]
        IWebElement txtEmails;

        [FindsBy(How = How.CssSelector, Using = "#message")]
        IWebElement txtMessage;


        [FindsBy(How = How.CssSelector, Using = "button[title='Share Wishlist']")]
        IWebElement btnShareWishList;


        public shareWishListPage(IWebDriver driver)
            : base(driver)
        {


        }

        public myWishListPage clickShareWishList(string email,string message)
        {
            txtEmails.SendKeys(email);
            txtMessage.SendKeys(message);
            btnShareWishList.Click();

            myWishListPage W = new myWishListPage(_Driver);
            PageFactory.InitElements(_Driver, W);
            return W;

        }
    }
}
