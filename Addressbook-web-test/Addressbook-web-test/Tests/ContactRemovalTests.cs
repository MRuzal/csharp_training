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
    public class ContactRemovalTests : AuthTestBase
    {
        [SetUp]
        public void VerifyContactPresent()
        {
            app.Contacts.ContactPresentCheck();
        }

        [Test]
        public void GontactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(1);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);
        }

    }


}
