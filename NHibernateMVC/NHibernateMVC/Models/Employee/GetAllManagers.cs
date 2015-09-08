using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Transform;
using NHibernateMVC.Domain.Employee;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Models.Employee
{
    public class GetAllManagers : Query<List<EmployeeListItem>>
    {
        public override List<EmployeeListItem> Execute(ISession session)
        {
            return session.GetNamedQuery("GetAllManagers")
                 .SetResultTransformer(Transformers.AliasToBean<EmployeeListItem>())
                .List<EmployeeListItem>().ToList();
        }
    }
}