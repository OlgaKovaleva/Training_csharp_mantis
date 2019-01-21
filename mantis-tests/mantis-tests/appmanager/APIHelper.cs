﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class APIHelper: HelperBase
    {
        public APIHelper (ApplicationManager manager): base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id=project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetAllProjects(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = new Mantis.ProjectData[] { };
            
            projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            List<ProjectData> allProjects = new List<ProjectData>();
            int projectCount = projects.Count();
            for (int i = 0; i < projectCount; i++)
            {

                allProjects.Add(new ProjectData()
                {
                    Id = projects[i].id,
                    Title = projects[i].name,
                    Description = projects[i].description,
                    State = projects[i].status.name,
                    Visibility = projects[i].view_state.name,
                    InheritGlobalCategory = projects[i].inherit_global
                });
                
            }
            return allProjects;
        }

        public void CreateProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData();
            projectData.id = project.Id;
            projectData.name = project.Title;
            projectData.description = project.Description;
            projectData.status.name = project.State;
            projectData.view_state.name = project.Visibility;
            projectData.inherit_global = project.InheritGlobalCategory;
            
            client.mc_project_add(account.Name, account.Password, projectData);
            

        }
    }
}
