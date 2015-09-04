using System;
using System.Text;
using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace NHibernateMVC.Domain.Employee
{
    /// <summary>
    /// Represents employee
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// empty constructor
        /// </summary>
        public Employee() { }
        /// <summary>
        /// Employee Id - Guid
        /// </summary>
        public virtual Guid EmployeeId { get; set; }
        /// <summary>
        /// Employee first name
        /// </summary>
        public virtual string FirstName { get; set; }
        /// <summary>
        /// employee last name
        /// </summary>
        public virtual string LastName { get; set; }
        /// <summary>
        /// employee birth date
        /// </summary>
        public virtual DateTime BirthDate { get; set; }
        /// <summary>
        /// employee gender
        /// </summary>
        public virtual int Sex { get; set; }
        /// <summary>
        /// employee manager id - nullable if employee dont have
        /// </summary>
        public virtual Manager Manager { get; set; }
        /// <summary>
        /// list of all projects
        /// </summary>
        public virtual IList<Project.Project> Projects { get; set; }

        public virtual Address Address { get; set; }
    }
}
