using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LogInWithValidCredentials()
        {
            //prepare
            app.Auth.Logout();
            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            // verification
            Assert.IsTrue(app.Auth.isLoggedIn(account));
        }

        [Test]
        public void LogInWithInvalidCredentials()
        {
            //prepare
            app.Auth.Logout();
            //action
            AccountData account = new AccountData("admin", "12345");
            app.Auth.Login(account);
            // verification
            Assert.IsFalse(app.Auth.isLoggedIn(account));
        }
    }
}
