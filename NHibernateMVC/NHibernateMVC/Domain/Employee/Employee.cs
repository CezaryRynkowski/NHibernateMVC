using System;
using System.Text;
using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace NHibernateMVC.Domain.Employee
{
    public class Employee
    {
        public virtual Guid EmployeeId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual int Sex { get; set; }
        public virtual Guid? ManagerId { get; set; }
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public virtual string Country { get; set; }
        public virtual string ZipCode { get; set; }

        public virtual IList<Project.Project> Projects { get; set; }

        public Employee()
        {
            //Projects = new HashedSet<Project.Project>();
        }

    }
}
