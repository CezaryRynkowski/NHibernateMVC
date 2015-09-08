using System;

namespace NHibernateMVC.Domain.Employee
{
    public class Manager : Employee
    {
        public virtual Guid ManagerId { get; set; }
        public virtual Guid EmployeeId { get; set; }
        public virtual int RoomNumber { get; set; }
    }
}