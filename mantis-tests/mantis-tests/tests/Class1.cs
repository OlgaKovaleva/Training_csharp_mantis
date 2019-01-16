using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class Class1: TestBase
    {
        [Test]
        public void TestMethod1()
        {
            app.Admin.LoginAsAdmin();
            app.Navigate.OpenUsersPage();
        }
    }
}
