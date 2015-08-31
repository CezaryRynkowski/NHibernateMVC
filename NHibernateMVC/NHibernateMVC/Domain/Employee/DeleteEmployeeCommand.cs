using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using NHibernateMVC.Infrastructure.Command;

namespace NHibernateMVC.Domain.Employee
{
    public class DeleteEmployeeCommand : Command<Employee>, INeedSession, INeedAutocommitTransaction
    {
        private readonly Guid employeeId;
        private EmployeeBuilder employeeBuilder;

        public DeleteEmployeeCommand(Guid employeeId)
        {
            this.employeeId = employeeId;
        }

        public override Employee Execute()
        {
            var employee = Session.Get<Employee>(employeeId);
            Session.Delete(employee);
            return employee;
        }

        public NHibernate.ISession Session { get; set; }

        public override void SetupDependencies(IWindsorContainer container)
        {
            this.employeeBuilder = container.Resolve<EmployeeBuilder>();
        }
    }
}