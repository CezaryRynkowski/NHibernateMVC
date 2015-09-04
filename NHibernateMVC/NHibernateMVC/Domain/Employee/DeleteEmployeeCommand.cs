using System;
using Castle.Windsor;
using NHibernateMVC.Infrastructure.Command;

namespace NHibernateMVC.Domain.Employee
{
    public class DeleteEmployeeCommand : Command<Employee>, INeedSession, INeedAutocommitTransaction
    {
        private readonly Guid _employeeId;
        private EmployeeBuilder _employeeBuilder;

        public DeleteEmployeeCommand(Guid employeeId)
        {
            _employeeId = employeeId;
        }
        /// <summary>
        /// Executes query
        /// </summary>
        /// <returns></returns>
        public override Employee Execute()
        {
            //construct entity
            var employee = Session.Get<Employee>(_employeeId);
            Session.Delete(employee);
            return employee;
        }

        public NHibernate.ISession Session { get; set; }

        public override void SetupDependencies(IWindsorContainer container)
        {
            _employeeBuilder = container.Resolve<EmployeeBuilder>();
        }
    }
}