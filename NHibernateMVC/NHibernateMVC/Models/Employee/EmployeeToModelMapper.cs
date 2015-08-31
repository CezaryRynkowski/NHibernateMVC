using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Employee
{
    public class EmployeeToModelMapper
    {
        public static EmployeeForm MapToEnpoyeeForm(Domain.Employee.Employee employee)
        {
            return new EmployeeForm
            {
              EmployeeId  = employee.EmployeeId,
              BirthDate = employee.BirthDate,
              City = employee.City,
              County = employee.City,
              FirstName = employee.FirstName,
              LastName = employee.LastName,
              ManagerId = employee.ManagerId,
              Sex = employee.Sex,
              Street = employee.Street,
              ZipCode = employee.ZipCode,
            };
        }

       public static EmployeeSearchResultItem EmployeeToEmployeeSearchResultItem(Domain.Employee.Employee e)
       {
           return new EmployeeSearchResultItem()
           {
               EmployeeId = e.EmployeeId,
               Name = string.Concat(e.FirstName," ",e.LastName)
           };
       }
    }

}