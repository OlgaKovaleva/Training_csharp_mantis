using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class ProjectHelper:HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public void Create(ProjectData project)
        {
            IWebDriver driver = manager.Admin.LoginAsAdmin();
            manager.Navigate.OpenProjectsPage();
            InitiateProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();

        }

        public List<ProjectData> GetAllProjects()
        {
            IWebDriver driver = manager.Admin.LoginAsAdmin();
            manager.Navigate.OpenProjectsPage();
            List<ProjectData> projects = new List<ProjectData>();
            IList<IWebElement> rows = driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string title = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;
                projects.Add(new ProjectData()
                {
                    Title = title,
                    Id = id
                });

            }
            return projects;
        }

        public void SubmitProjectCreation()
        {
           driver.FindElement(By.XPath("//form[@id='manage-project-create-form']/div/div[3]/input")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Title);
            driver.FindElement(By.Id("project-description")).Click();
            driver.FindElement(By.Id("project-description")).Clear();
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
        }

        public void InitiateProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
    }
}
