using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace ProjectGuru99
{
    class MobilePage:BasePage
    {
        string expectedTitle = "Mobile";

        [FindsBy(How = How.CssSelector,Using="button[title='Add to Cart']")]
        IWebElement btnAddToCart;

        [FindsBy(How = How.CssSelector,Using = "select[title='Sort By']")]
        IWebElement selectSortBy;

        [FindsBy(How= How.CssSelector,Using=".product-name")]
        IList<IWebElement> items;

        [FindsBy(How = How.CssSelector, Using = ".link-compare")]
        IList<IWebElement> AddToComparelinks;

        [FindsBy(How = How.CssSelector, Using = "button[title='Compare']")]
        IWebElement btnCompare;

        public void SortByName()
        {
            SelectElement element = new SelectElement(selectSortBy);
            element.SelectByText("Name");

            
        }

        public MobilePage(IWebDriver driver)
            : base(driver)
        {

         }

        public void vfbileTitle()
        {
            string actual = _Driver.Title.ToString();
            Assert.AreEqual(expectedTitle, actual);
        }

        public void VerifySortingByName()
        {
          string previous = items[0].Text;
          Console.WriteLine(previous);

            foreach(IWebElement i in items)
            {

                if(i.Text.CompareTo(previous) <0)
                {
                    Assert.Fail("Name sorting not working {0}  is less than {1}", i.Text, previous);
                    break;
                }

                previous = i.Text;

                
            }
            Assert.Pass("Sorting by Name working");
        }

        public ShoppingCartPage AddToCart()
        {
            btnAddToCart.Click();
            ShoppingCartPage s = new ShoppingCartPage(_Driver);
            PageFactory.InitElements(_Driver, s);
            return s;
        }

        public string getItemPrice(string itemName)
        {
            IList<IWebElement> Items = _Driver.FindElements(By.CssSelector("h2.product-name"));

            IList<IWebElement> ItemPrice = _Driver.FindElements(By.CssSelector(".price-box"));
            int i = 0;
            foreach(IWebElement item in items)
            {
                if (item.Text.CompareTo(itemName.ToUpper()) == 0)
                {

                    return ItemPrice[i].Text;
                    break;
                }
                i++;
            }


            return "";

        }


        public DetailsPage ClickItem(String itemName)
        {
            IList<IWebElement> Items = _Driver.FindElements(By.CssSelector("h2.product-name"));

            foreach (IWebElement item in items)
            {
                if (item.Text.CompareTo(itemName.ToUpper()) == 0)
                {

                    item.Click();
                    DetailsPage d = new DetailsPage(_Driver);
                    PageFactory.InitElements(_Driver, d);
                    return d;
                    
                }
                
            }

            return null;
        }

        public void AddToCompare(string first,string second)
        {
            //AddToComparelinks[first].Click();
            //AddToComparelinks[second].Click();
           // int i = 0;

            //foreach(IWebElement item in items)
            //{
            //    string ItemText = item.Text;
            //    if (ItemText.CompareTo(first.ToUpper()) == 0)
            //    {
            //        AddToComparelinks[i].Click();
            //        break;
            //    }

            //    i++;
            //}
            int firstItemPosition = Helper.getIndexofElementinList(items,first.ToUpper());
            if(firstItemPosition!=-1)
            {
                AddToComparelinks[firstItemPosition].Click();
            }


           // items = _Driver.FindElements(By.CssSelector("h2.product-name"));

            int secondItemPosition = Helper.getIndexofElementinList(items, second.ToUpper());
            if(secondItemPosition!=-1)
            {
                AddToComparelinks[secondItemPosition].Click();
            }


            //i = 0;

            //foreach (IWebElement item in items)
            //{
            //    string ItemText = item.Text;
            //    if (ItemText.CompareTo(second.ToUpper()) == 0)
            //    {
            //        AddToComparelinks[i].Click();
            //        break;
            //    }

            //    i++;
            //}

        }
        public void clickCompare(string first, string second)
        {
            
            string currentHandle = _Driver.CurrentWindowHandle;
            PopupWindowFinder finder = new PopupWindowFinder(_Driver);
            string newpopupHandle = finder.Click(btnCompare);
            _Driver.SwitchTo().Window(newpopupHandle);
            string PopupTitle = _Driver.FindElement(By.CssSelector("h1")).Text;
            Assert.That("COMPARE PRODUCTS".CompareTo(PopupTitle) == 0);

            IList<IWebElement> DisplayedProducts = _Driver.FindElements(By.CssSelector("h2.product-name"));

            Assert.That(Helper.CheckifElementExistByText(DisplayedProducts,first.ToUpper()),"First Item not found in the popup");
            Assert.That(Helper.CheckifElementExistByText(DisplayedProducts,second.ToUpper()),"Second Item not found in the popup");
            
            _Driver.FindElement(By.CssSelector("button[title='Close Window']")).Click();

        }
    }
}
