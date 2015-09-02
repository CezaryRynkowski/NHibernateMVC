using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Transform;
using NHibernateMVC.Infrastructure.Query;
using NHibernateMVC.Models.Employee;

namespace NHibernateMVC.Models.Project
{
    public class GetEmployeeFromProjectQuery : Query<List<EmployeeFromProjectListItem>>
    {
        private readonly Guid _projectId;
        
        public GetEmployeeFromProjectQuery(Guid projectId)
        {
            _projectId = projectId;
        }

        public override List<EmployeeFromProjectListItem> Execute(ISession session)
        {
            return session.GetNamedQuery("employeFromProject")
                .SetParameter("projectId", _projectId)
                .SetResultTransformer(Transformers.AliasToBean<EmployeeFromProjectListItem>())
                .List<EmployeeFromProjectListItem>().ToList();

        }
    }

    public class EmployeeFromProjectListItem
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}