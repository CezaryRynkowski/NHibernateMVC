using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Models.Employee
{
    internal class GetAllManagers : Query<List<EmployeeListItem>>
    {
        /// <summary>
        /// Implement this method to construct and execute a query against provided NHibernate session
        /// </summary>
        /// <param name="session">NHibernate session</param>
        public override List<EmployeeListItem> Execute(ISession session)
        {
            return session.QueryOver<EmployeeListItem>()
                .Where(x => x.ManagerId != Guid.Empty)
                .List<EmployeeListItem>().ToList();
        }
    }
}