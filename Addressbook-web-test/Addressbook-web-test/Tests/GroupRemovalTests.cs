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
    public class GroupRemovalTests : AuthTestBase
    {

        [SetUp]
        public void VerifyGroupPresent()
        {
            app.groups.GroupPresentCheck();
        }

        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.groups.GetGroupList();

            app.groups.Remove(1);

            List<GroupData> newGroups = app.groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
        }

     }
}

