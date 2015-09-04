using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateMVC.Models.Employee;

namespace NHibernateMVC.Models.Project
{
    public class ProjectForm
    {
        /// <summary>
        /// project id
        /// </summary>
        public Guid ProjectId { get; set; }
        /// <summary>
        /// project name
        /// </summary>
        public string ProjectName { get; set; } 
        /// <summary>
        /// list of all project from db
        /// </summary>
        public List<Domain.Project.Project> AllProjects { get; set; }
        /// <summary>
        /// List of employee form project list item
        /// </summary>
        public List<EmployeeFromProjectListItem> List { get; set; } 
        /// <summary>
        /// list of all employees
        /// </summary>
        public List<EmployeeListItem> EmployeesList { get; set; } 
        /// <summary>
        /// empoyee id to string
        /// </summary>
        public string EmployeeGuidToDb { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="projectForm"></param>
        public ProjectForm(ProjectForm projectForm)
        {
            ProjectId = projectForm.ProjectId;
            ProjectName = projectForm.ProjectName;
        }
        /// <summary>
        /// empty constructor
        /// </summary>
        public ProjectForm() { }
    }
}