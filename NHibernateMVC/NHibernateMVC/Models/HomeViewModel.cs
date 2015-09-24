using System.Collections.Generic;
using NHibernateMVC.Models.Employee;

namespace NHibernateMVC.Models
{
    public class HomeViewModel
    {
        IList<EmployeeListItem> Employees { get; set; }

        public HomeViewModel(List<EmployeeListItem> employees )
        {
            Employees = employees;
        }
    }
}