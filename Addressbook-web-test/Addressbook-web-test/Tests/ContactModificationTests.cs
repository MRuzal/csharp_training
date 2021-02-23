using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationsTests : TestBase
    {
        [Test]
        public void ContactModificationTests()
        {
            ContactData newInfo = new ContactData();

            newInfo.Firstname = "Russel";
            newInfo.Lastname = "Mukham";

            app.Contacts.Modify(1, newInfo);
            app.logout.LogOut();
        }
    }
}
