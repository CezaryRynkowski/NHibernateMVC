using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Employee
{
    public class EmployeeForm
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Sex { get; set; }
        public Guid? ManagerId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string County { get; set; }
        public string ZipCode { get; set; }
    }
}