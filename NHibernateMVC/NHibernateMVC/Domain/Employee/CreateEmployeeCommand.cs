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
            //TODO
        }

        public NHibernate.ISession Session { get; set; }

        public override void SetupDependencies(IWindsorContainer container)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}