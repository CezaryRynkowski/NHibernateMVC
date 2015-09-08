using NHibernate;
using NHibernateMVC.Infrastructure.Service;

namespace NHibernateMVC.Domain.Employee
{
    /// <summary>
    /// Service that implements validations for employee that required data outside employee entity instance
    /// </summary>
    public class EmployeeValidationService : BusinessService
    {
        public EmployeeValidationService(ISession session )
            : base(session) { }

        /// <summary>
        /// Returs true if employee number is unique
        /// </summary>
        /// <param name="employee">employee to check</param>
        /// <returns>true if empoyee number is unique</returns>
        public bool IsEmployeeNumberUnique(Employee employee)
        {
            var employeeWithTheSameNumber =
                Session.QueryOver<Employee>().Where(e => e.Id == employee.Id).SingleOrDefault();
            return employeeWithTheSameNumber == null || employeeWithTheSameNumber.Id == employee.Id;
        }
    }
}