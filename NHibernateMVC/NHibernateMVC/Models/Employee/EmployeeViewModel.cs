using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Employee
{
    public class EmployeeViewModel
    {
        public EmployeeForm EmployeeForm { get; set; }
        
        public EmployeeViewModel(EmployeeForm employeeForm)
        {
            EmployeeForm = employeeForm;
        }

        public EmployeeViewModel()
        {
            EmployeeForm = new EmployeeForm();
        }
    }
}