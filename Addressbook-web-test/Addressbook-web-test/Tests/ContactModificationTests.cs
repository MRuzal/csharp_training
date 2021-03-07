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
    public class ContactModificationsTests : AuthTestBase
    {
      

        [SetUp]
        public void VerifyContactPresent()
        {
            app.Contacts.ContactPresentCheck();
        }


        [Test]
        public void ContactModificationTests()
        {
            ContactData newInfo = new ContactData("Ruzzikk", "Muhhh");

            newInfo.Firstname = "Russel";
            newInfo.Lastname = "Muh";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(1, newInfo);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);

        }
    }
}
