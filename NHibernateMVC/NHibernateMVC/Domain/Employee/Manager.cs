using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Domain.Employee
{
    public class Manager
    {
        public virtual string Employee { get; set; }
        public virtual Guid? ManagerId { get; set; }
        public string RoomNumber { get; set; }
        public string Subordinates { get; set; }
    }
}