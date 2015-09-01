using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Transform;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Models.Employee
{
    public class GetEmployeeListQuery : Query<IList<EmployeeListItem>>
    {
        private readonly EmployeeSearchForm searchForm;

        public GetEmployeeListQuery(EmployeeSearchForm searchForm)
        {
            this.searchForm = searchForm;
        }

        public override IList<EmployeeListItem> Execute(ISession session)
        {
            return session.GetNamedQuery("employeeSearchQuery")
                .SetParameter("employeeid",searchForm.EmployeeId)
                .SetParameter("firstname", searchForm.FirstName)
                .SetParameter("lastname", searchForm.LastName)
                .SetParameter("manager", searchForm.ManagerId)
                .SetParameter("zipcode",searchForm.ManagerId)
                .SetResultTransformer(Transformers.AliasToBean<EmployeeListItem>())
                .List<EmployeeListItem>();
        }
    }

    public class EmployeeListItem
    {
        public Guid EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid? ManagerId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public List<Domain.Project.Project> Projects { get; set; }
    }
}