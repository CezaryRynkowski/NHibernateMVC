using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateMVC.Models.Employee;

namespace NHibernateMVC.Models.Project
{
    public class ProjectForm
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } 
        //public List<Domain.Employee.Employee> Employees { get; set; }
        public List<Domain.Project.Project> AllProjects { get; set; }
        public List<EmployeeFromProjectListItem> List { get; set; } 
        public List<EmployeeListItem> EmployeesList { get; set; } 
        
        public ProjectForm(ProjectForm projectForm)
        {
            ProjectId = projectForm.ProjectId;
            ProjectName = projectForm.ProjectName;
            //Employees = projectForm.Employees;
        }

        public ProjectForm() { }

    }
}