using System;
using Iesi.Collections.Generic;

namespace NHibernateMVC.Domain.Project
{

    public class Project
    {
        public virtual Guid ProjectId { get; set; }
        public virtual string ProjectName { get; set; }

        public virtual Iesi.Collections.Generic.ISet<Employee.Employee> Employees { get; set; }

        public Project()
        {
            Employees = new HashedSet<Employee.Employee>();
        }
    }
}
