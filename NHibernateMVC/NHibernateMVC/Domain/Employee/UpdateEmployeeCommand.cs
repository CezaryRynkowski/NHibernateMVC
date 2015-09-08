using System;
using NHibernate;
using NHibernateMVC.Infrastructure.Command;
using NHibernateMVC.Models.Employee;

namespace NHibernateMVC.Domain.Employee
{
    /// <summary>
    /// Updates employee data
    /// </summary>
    public class UpdateEmployeeCommand : Command<Guid>, INeedSession, INeedAutocommitTransaction
    {
        private readonly EmployeeForm _employeeForm;
        private EmployeeBuilder _employeeBuilder;

        public UpdateEmployeeCommand(EmployeeForm employeeForm)
        {
            _employeeForm = employeeForm;
        }

        public override Guid Execute()
        {
            EmployeeBuilder builder = new EmployeeBuilder(Session);
            var employee = Session.Get<Employee>(_employeeForm.EmployeeId);
            builder.UpdateEmployee(employee,_employeeForm);
            Session.Update(employee);

            return employee.Id;
        }

        public ISession Session { get; set; }

        public override void SetupDependencies(Castle.Windsor.IWindsorContainer container)
        {
            _employeeBuilder = container.Resolve<EmployeeBuilder>();
        }

    }
}