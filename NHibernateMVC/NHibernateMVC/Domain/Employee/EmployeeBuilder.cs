using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Service;
using NHibernateMVC.Models.Employee;

namespace NHibernateMVC.Domain.Employee
{
    /// <summary>
    /// Class responsible for creation of employee entities
    /// </summary>
    public class EmployeeBuilder : BusinessService
    {
        /// <summary>
        /// Consctruct new instance of employee builder
        /// </summary>
        /// <param name="session">NHibernate session</param>
        public EmployeeBuilder(ISession session)
            :base(session) { }

        /// <summary>
        /// Construct new employee out of form data
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Employee ConstructEmployee(EmployeeForm form)
        {
            var e = new Employee
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                BirthDate = form.BirthDate,
                Sex = form.Sex,
                EmployeeId = form.EmployeeId,
            };
            e.Address.City = form.City;
            e.Address.Country = form.City;
            e.Address.Street = form.Street;
            e.Address.ZipCode = form.ZipCode;
            e.Managers = form.ManagerId;

            return e;
        }

        /// <summary>
        /// Updates employee with data from the web form
        /// </summary>
        /// <param name="employeeToUpdate">employee entity from db</param>
        /// <param name="employeeForm">data entered on web form</param>
        public void UpdateEmployee(Employee employeeToUpdate, EmployeeForm employeeForm)
        {
            employeeToUpdate.FirstName = employeeForm.FirstName;
            employeeToUpdate.LastName = employeeForm.LastName;
            employeeToUpdate.BirthDate = employeeForm.BirthDate;
            employeeToUpdate.Address.City = employeeForm.City;
            employeeToUpdate.Address.Country = employeeForm.County;
            employeeToUpdate.Sex = employeeForm.Sex;
            employeeToUpdate.Address.Street = employeeForm.Street;
            employeeToUpdate.Address.ZipCode = employeeForm.ZipCode;
        }
    }
}