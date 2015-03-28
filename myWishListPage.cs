using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace ProjectGuru99
{
    class myWishListPage:BasePage
    {
        [FindsBy(How = How.CssSelector,Using=".success-msg")]
        IWebElement msgWishlistSuccess;

        
        [FindsBy(How = How.CssSelector,Using="button[title='Share Wishlist']")]
        IWebElement btnShareWishlist;

        public myWishListPage(IWebDriver driver) : base(driver)
        {

        }

        public void verifySuccessdisplayedforWishlistItem(string itemName)
        {
            Assert.That(msgWishlistSuccess.Text.Contains(itemName));
        }

        public shareWishListPage clickShareWishListPage()
        {
            btnShareWishlist.Click();
            shareWishListPage S = new shareWishListPage(_Driver);
            PageFactory.InitElements(_Driver, S);
            return S;
        }

        public void verifyWishlistShared()
        {
            Assert.That(msgWishlistSuccess.Text.CompareTo("Your Wishlist has been shared.") == 0);
        }

    }
}
