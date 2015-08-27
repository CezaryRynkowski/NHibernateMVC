using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using NHibernateMVC.Infrastructure.Command;
using NHibernateMVC.Models.Employee;

namespace NHibernateMVC.Domain.Employee
{
    public class CreateEmployeeCommand : Command<Guid>, INeedSession, INeedAutocommitTransaction
    {
        private EmployeeForm employeeForm;
        private EmployeeBuilder employeeBuilder;
        private EmployeeValidationService employeeValidationService;

        public CreateEmployeeCommand(EmployeeForm employeeForm)
        {
            this.employeeForm = employeeForm;
        }

        public override Guid Execute()
        {
            EmployeeBuilder builder = new EmployeeBuilder(Session);
            //construct entity
            var employee = builder.ConstructEmployee(employeeForm);
            Session.Save(employee);

            return employee.EmployeeId;
        }

        public NHibernate.ISession Session { get; set; }

        public override void SetupDependencies(IWindsorContainer container)
        {
            employeeBuilder = container.Resolve<EmployeeBuilder>();
            employeeValidationService = container.Resolve<EmployeeValidationService>();
        }
    }
}