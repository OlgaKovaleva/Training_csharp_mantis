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


            AccountData account = new AccountData() { Name = "administrator", Password = "root" };
            //app.Login.LoginAsUser(account);
            //app.Navigate.OpenProjectsPage();

            List<ProjectData> allProjects = new List<ProjectData>();
            allProjects=app.API.GetAllProjects(account);
            

        }
    }
}
