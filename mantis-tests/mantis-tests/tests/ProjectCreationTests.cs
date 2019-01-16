using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests:TestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            ProjectData project = new ProjectData()
            {
                Title = "Project title",
                Description = "Lorem ipsum dolor sit amet orci aliquam."
            };

            List<ProjectData> oldList = app.Project.GetAllProjects();
            app.Project.Create(project);

            List<ProjectData> newList = app.Project.GetAllProjects();
            oldList.Add(project);

            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
            Assert.AreEqual(oldList.Count, newList.Count);
           
        }
    }
}
