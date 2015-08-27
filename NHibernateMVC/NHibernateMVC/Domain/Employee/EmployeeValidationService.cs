using NHibernate;
using NHibernateMVC.Infrastructure.Service;

namespace NHibernateMVC.Domain.Employee
{
    public class EmployeeValidationService : BusinessService
    {
        public EmployeeValidationService(ISession session )
            : base(session) { }

        public bool IsEmployeeNumberUnique(Employee employee)
        {
            var employeeWithTheSameNumber =
                Session.QueryOver<Employee>().Where(e => e.EmployeeId == employee.EmployeeId).SingleOrDefault();
            return employeeWithTheSameNumber == null || employeeWithTheSameNumber.EmployeeId == employee.EmployeeId;
        }
    }
}