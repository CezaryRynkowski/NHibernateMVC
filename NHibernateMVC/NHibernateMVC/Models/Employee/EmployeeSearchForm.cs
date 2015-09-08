using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateMVC.Domain.Employee;
using NHibernateMVC.Domain.JobHistory;

namespace NHibernateMVC.Models.Employee
{
    public class EmployeeSearchForm
    {
        /// <summary>
        /// Emplyoee Id
        /// </summary>
        public Guid? EmployeeId { get; set; }
        /// <summary>
        /// employee first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// employee last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// employee zip code
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// employee manager id
        /// </summary>
        public string ManagerId { get; set; }
        /// <summary>
        /// employee positon
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// project
        /// </summary>
        public string Project { get; set; }
        /// <summary>
        /// List of all position from db
        /// </summary>
        public List<Position> Positions { get; set; }
        /// <summary>
        /// List of all project from db
        /// </summary>
        public List<Domain.Project.Project> AllProjects { get; set; }

        public List<EmployeeListItem> AllManagers { get; set; }
    }
}