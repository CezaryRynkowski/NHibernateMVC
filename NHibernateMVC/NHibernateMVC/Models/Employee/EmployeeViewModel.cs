using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Employee
{
    public class EmployeeViewModel
    {
        /// <summary>
        /// employee form
        /// </summary>
        public EmployeeForm EmployeeForm { get; set; }
        
        public EmployeeViewModel(EmployeeForm employeeForm)
        {
            EmployeeForm = new EmployeeForm(employeeForm);
        }
        /// <summary>
        /// constructor
        /// </summary>
        public EmployeeViewModel()
        {
            EmployeeForm = new EmployeeForm();
        }

        public EmployeeViewModel(List<EmployeeListItem> items)
        {
            EmployeeForm = new EmployeeForm { AllManagers = items};
            
        }
    }
}