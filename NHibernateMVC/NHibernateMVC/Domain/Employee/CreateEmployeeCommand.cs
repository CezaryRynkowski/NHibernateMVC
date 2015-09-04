using System;
using Castle.Windsor;
using NHibernateMVC.Infrastructure.Command;
using NHibernateMVC.Models.Employee;

namespace NHibernateMVC.Domain.Employee
{
    public class CreateEmployeeCommand : Command<Guid>, INeedSession, INeedAutocommitTransaction
    {
        private readonly EmployeeForm _employeeForm;
        private EmployeeBuilder _employeeBuilder;
        private EmployeeValidationService _employeeValidationService;

        public CreateEmployeeCommand(EmployeeForm employeeForm)
        {
            _employeeForm = employeeForm;
        }

        /// <summary>
        /// Executes query
        /// </summary>
        /// <returns></returns>
        public override Guid Execute()
        {
            EmployeeBuilder builder = new EmployeeBuilder(Session);
            //construct entity
            var employee = builder.ConstructEmployee(_employeeForm);
            Session.Save(employee);

            return employee.EmployeeId;
        }

        public NHibernate.ISession Session { get; set; }

        public override void SetupDependencies(IWindsorContainer container)
        {
            _employeeBuilder = container.Resolve<EmployeeBuilder>();
            _employeeValidationService = container.Resolve<EmployeeValidationService>();
        }
    }
}