using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(100),
                    Lastname = GenerateRandomString(100)

                });

            }
            return contacts;
        }




        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {  

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);


            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }

    }
}
