using System;

namespace NHibernateMVC.Domain.Employee
{
    public class Manager : Employee
    {
        /// <summary>
        /// Manager id
        /// </summary>
        public virtual Guid ManagerId { get; set; }
        /// <summary>
        /// manager id as employee
        /// </summary>
        public virtual Guid EmployeeId { get; set; }
        /// <summary>
        /// room number, nullable
        /// </summary>
        public virtual int RoomNumber { get; set; }
    }
}