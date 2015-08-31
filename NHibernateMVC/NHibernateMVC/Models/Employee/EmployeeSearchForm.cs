using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Employee
{
    public class EmployeeSearchForm
    {
        public Guid? EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string ZipCode { get; set; }

        public string ManagerId { get; set; }

    }
}