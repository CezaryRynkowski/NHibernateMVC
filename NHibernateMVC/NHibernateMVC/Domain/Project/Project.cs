using System;
using System.Collections.Generic;

namespace NHibernateMVC.Domain.Project
{
    /// <summary>
    /// reoresents project
    /// </summary>
    public class Project
    {
        /// <summary>
        /// project id - guid
        /// </summary>
        public virtual Guid ProjectId { get; set; }
        /// <summary>
        /// project name
        /// </summary>
        public virtual string ProjectName { get; set; }
        /// <summary>
        /// list of all projects in db
        /// </summary>
        public virtual List<Project> AllProjects { get; set; } 
        /// <summary>
        /// list of all employees
        /// </summary>
        public virtual IList<Employee.Employee> Employees { get; set; }
    }
}
