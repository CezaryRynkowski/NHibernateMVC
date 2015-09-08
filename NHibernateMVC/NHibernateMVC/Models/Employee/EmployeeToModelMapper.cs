using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Components.DictionaryAdapter;
using NHibernate.Linq;
using NHibernate.Util;
using NHibernateMVC.Domain.Employee;

namespace NHibernateMVC.Models.Employee
{
    /// <summary>
    /// Maps policies to model instances
    /// </summary>
    public class EmployeeToModelMapper
    {
        /// <summary>
        /// Maps policy entity to employee form model
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static EmployeeForm MapToEnpoyeeForm(Domain.Employee.Employee employee, List<Domain.Project.Project> q)
        {
            return new EmployeeForm
            {
              EmployeeId  = employee.Id,
              BirthDate = employee.BirthDate,
              City = employee.Address.City,
              County = employee.Address.City,
              FirstName = employee.FirstName,
              LastName = employee.LastName,
              ManagerId = employee.Managers,
              Sex = employee.Sex,
              Street = employee.Address.Street,
              ZipCode = employee.Address.ZipCode,
              Projects = employee.Projects.ToList(),
              
              AllProjects = q.ToList()
            };
        }

       public static EmployeeSearchResultItem EmployeeToEmployeeSearchResultItem(Domain.Employee.Employee e)
       {
           return new EmployeeSearchResultItem()
           {
               EmployeeId = e.Id,
               Name = string.Concat(e.FirstName," ",e.LastName)
           };
       }

       public static EmployeeForm MapToItem(Models.Employee.EmployeeSearchForm m)
       {
           return new EmployeeForm()
           {
               AllManagers = m.AllManagers
           };
       }
    }

}