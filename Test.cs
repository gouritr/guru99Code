using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;

namespace ProjectGuru99
{
    public class Test
    {
        IWebDriver driver;

       [SetUp]
        public void setup()
        {
           driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://live.guru99.com/index.php/");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [Test]
        public void verfiySortingByName()
       {
           Homepage h = new Homepage(driver);
           PageFactory.InitElements(driver, h);
           h.vfTitle();
           MobilePage m =  h.clickMobile();
           m.vfbileTitle();
           m.SortByName();
           m.VerifySortingByName();
           
       }
        [Test]
        public void VerifyAddingMoreProduct()
        {
            Homepage h = new Homepage(driver);
            PageFactory.InitElements(driver, h);
            h.vfTitle();
            MobilePage m = h.clickMobile();
            m.vfbileTitle();
           ShoppingCartPage s = m.AddToCart();
           s.UpdateQty("1000");
           s.checkOutofQuantityError();
           s.emptyCart();


        }

        [Test]
        public void VerifyPriceinListSameAsDetailed()
        {
            Homepage h = new Homepage(driver);
            PageFactory.InitElements(driver, h);
            h.vfTitle();
            MobilePage m = h.clickMobile();
            m.vfbileTitle();
            string priceInList = m.getItemPrice("Sony Xperia");
            DetailsPage d = m.ClickItem("Sony Xperia");
            d.verifythePricedisplayed(priceInList);

        }
        [Test]
        public void CompareMobiles()
        {
            Homepage h = new Homepage(driver);
            PageFactory.InitElements(driver, h);
            h.vfTitle();
            MobilePage m = h.clickMobile();
            m.vfbileTitle();
            m.AddToCompare("Samsung Galaxy","Sony Xperia");
            m.clickCompare("Samsung Galaxy", "Sony Xperia");
        }

    [Test]
        public void VerifyAccountCreationAndWishListAddition()
        {
            Homepage h = new Homepage(driver);
            PageFactory.InitElements(driver, h);
            h.vfTitle();
            CustomerAccountPage CustAccount = h.clickMyAccount();
            CreateAccountPage CA = CustAccount.ClickCreateAccount();
            userHomePage U = CA.Register("Abc","XYZ","abc2@abc.com","123456");
            MobilePage M = U.ClickLinkMobile();
            myWishListPage W = M.addtowishlist("Sony Xperia");
            W.verifySuccessdisplayedforWishlistItem("Sony Xperia");
            shareWishListPage S = W.clickShareWishListPage();
            W =  S.clickShareWishList("abc@abc.com", "hi");
            W.verifyWishlistShared();
        }
    }
}
