using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;

namespace ProjectGuru99
{
    class BasePage
    {
         public IWebDriver _Driver;

        public BasePage(IWebDriver Driver)
         {
             this._Driver = Driver;

         }

    }
}
