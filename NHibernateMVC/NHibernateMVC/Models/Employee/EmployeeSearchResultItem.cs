using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Employee
{
    public class EmployeeSearchResultItem
    {
        /// <summary>
        /// employee id
        /// </summary>
        public Guid? EmployeeId { get; set; }
        /// <summary>
        /// employee name - employee first name + employe last name
        /// </summary>
        public string Name { get; set; }
    }
}