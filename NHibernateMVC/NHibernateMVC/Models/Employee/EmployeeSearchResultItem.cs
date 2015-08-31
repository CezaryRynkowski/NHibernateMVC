using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Employee
{
    public class EmployeeSearchResultItem
    {
        public Guid? EmployeeId { get; set; }

        public string Name { get; set; }
    }
}