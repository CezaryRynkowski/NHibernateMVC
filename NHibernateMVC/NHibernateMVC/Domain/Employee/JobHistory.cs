using System;
using System.Text;
using System.Collections.Generic;


namespace NHibernateMVC.Domain.Employee
{

    public class JobHistory
    {
        public virtual Guid Jobhistoryid { get; set; }
        public virtual int Positionid { get; set; }
        public virtual DateTime Startdate { get; set; }
        public virtual DateTime Stopdate { get; set; }
        public virtual string Salary { get; set; }
        public virtual System.Guid Employeeid { get; set; }
    }
}
