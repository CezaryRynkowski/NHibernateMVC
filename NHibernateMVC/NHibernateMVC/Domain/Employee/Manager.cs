using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Domain.Employee
{
    public class Manager : Employee
    {
        public virtual Guid EmployeeId { get; set; }
        public virtual Guid? ManagerId { get; set; }
        public virtual string RoomNumber { get; set; }
        public virtual string Subordinates { get; set; }

        public virtual Employee Employees { get; set; } 
    }
}