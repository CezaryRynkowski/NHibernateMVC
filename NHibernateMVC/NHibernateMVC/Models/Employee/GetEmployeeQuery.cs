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
        /// <summary>
        /// executes query
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public override EmployeeForm Execute(ISession session)
        {
            var p = session.Get<Domain.Employee.Employee>(employeeId);

            var q = session.QueryOver<Domain.Project.Project>()
                .Where(x => x.ProjectId!=null)
                .List<Domain.Project.Project>().ToList();

            return EmployeeToModelMapper.MapToEnpoyeeForm(p,q);
        }
    }
}