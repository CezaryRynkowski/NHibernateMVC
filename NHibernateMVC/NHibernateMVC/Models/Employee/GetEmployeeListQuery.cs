using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Transform;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Models.Employee
{
    public class GetEmployeeListQuery : Query<List<EmployeeListItem>>
    {
        private readonly EmployeeSearchForm searchForm;

        public GetEmployeeListQuery(EmployeeSearchForm searchForm)
        {
            this.searchForm = searchForm;
        }

        public GetEmployeeListQuery()
        {
            searchForm = new EmployeeSearchForm();
        }
        /// <summary>
        /// Executes query
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public override List<EmployeeListItem> Execute(ISession session)
        {
            return session.GetNamedQuery("employeeSearchQuery")
                .SetParameter("employeeid",searchForm.EmployeeId)
                .SetParameter("firstname", searchForm.FirstName)
                .SetParameter("lastname", searchForm.LastName)
                .SetParameter("manager", searchForm.ManagerId)
                .SetParameter("zipcode",searchForm.ManagerId)
                .SetParameter("position", searchForm.Position)
                .SetParameter("project", searchForm.Project)
                .SetResultTransformer(Transformers.AliasToBean<EmployeeListItem>())
                .List<EmployeeListItem>().ToList();
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

        public int PositionId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? StopDate { get; set; }

        public List<Domain.Project.Project> Projects { get; set; }

        public Guid? ProjectId { get; set; }
    }
}