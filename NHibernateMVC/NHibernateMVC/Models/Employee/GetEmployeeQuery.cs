using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Models.Employee
{
    public class GetEmployeeQuery : Query<EmployeeForm>
    {
        private readonly Guid employeeId;

        public GetEmployeeQuery(Guid employeeId)
        {
            this.employeeId = employeeId;
        }

        public override EmployeeForm Execute(ISession session)
        {
            var p = session.Get<Domain.Employee.Employee>(employeeId);

            return EmployeeToModelMapper.MapToEnpoyeeForm(p);
        }
    }
}