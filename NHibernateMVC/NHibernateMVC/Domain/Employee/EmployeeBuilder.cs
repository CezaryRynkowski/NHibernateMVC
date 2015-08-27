using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Service;
using NHibernateMVC.Models.Employee;

namespace NHibernateMVC.Domain.Employee
{
    public class EmployeeBuilder : BusinessService
    {
        public EmployeeBuilder(ISession session)
            :base(session) { }

        public Employee ConstructEmployee(EmployeeForm form)
        {
            var e = new Employee
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                BirthDate = form.BirthDate,
                City = form.City,
                Country = form.County,
                Street = form.Street,
                Sex = form.Sex,
                EmployeeId = form.EmployeeId,
                ManagerId = form.ManagerId,
                ZipCode = form.ZipCode
            };

            return e;
        }

        public void UpdateEmployee(Employee employeeToUpdate, EmployeeForm employeeForm)
        {
            employeeToUpdate.FirstName = employeeForm.FirstName;
        }
    }
}