using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("qw");
            group.Header = "qa";
            group.Footer = "qe";
            
            List<GroupData> oldGroups = app.groups.GetGroupList();
            
            app.groups.Create(group);

            List<GroupData> newGroups = app.groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            
            
        }


        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
           
            List<GroupData> oldGroups = app.groups.GetGroupList();
           
            app.groups.Create(group);

            List<GroupData> newGroups = app.groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
