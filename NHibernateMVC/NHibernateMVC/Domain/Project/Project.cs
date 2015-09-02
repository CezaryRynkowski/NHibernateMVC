using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;
using NHibernate.Collection;

namespace NHibernateMVC.Domain.Project
{

    public class Project
    {
        public virtual Guid ProjectId { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual List<Project> AllProjects { get; set; } 

        public virtual IList<Employee.Employee> Employees { get; set; }


        public Project()
        {
            //Employees = new HashedSet<Employee.Employee>();
        }
    }
}
