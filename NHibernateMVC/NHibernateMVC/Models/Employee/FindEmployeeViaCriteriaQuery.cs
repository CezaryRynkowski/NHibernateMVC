using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using Microsoft.Ajax.Utilities;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Models.Employee
{
    public class FindEmployeeViaCriteriaQuery : Query<IList<EmployeeListItem>>
    {
        private readonly EmployeeSearchForm searchForm;

        public FindEmployeeViaCriteriaQuery(EmployeeSearchForm searchForm)
        {
            this.searchForm = searchForm;
        }

        private void ApplyEmployeeCriteria(
            IQueryOver<Domain.Employee.Employee, Domain.Employee.Employee> employeeSearchQuery)
        {
            if (!string.IsNullOrWhiteSpace(searchForm.FirstName))
            {
                employeeSearchQuery.WhereRestrictionOn(e => e.FirstName).IsLike(searchForm.FirstName);
            }

            if (!string.IsNullOrWhiteSpace(searchForm.LastName))
            {
                employeeSearchQuery.WhereRestrictionOn(e => e.LastName).IsLike(searchForm.LastName);
            }

            if (!searchForm.EmployeeId.ToString().IsNullOrWhiteSpace())
            {
                employeeSearchQuery.WhereRestrictionOn(e => e.Id).IsLike(searchForm.EmployeeId);
            }

            if (!string.IsNullOrWhiteSpace(searchForm.ZipCode))
            {
                employeeSearchQuery.WhereRestrictionOn(e => e.Address.ZipCode).IsLike(searchForm.ZipCode);
            }
        }

        public override IList<EmployeeListItem> Execute(ISession session)
        {
            Domain.Employee.Employee employeeAlias = null;
            var matchingEmployee = new List<EmployeeListItem>();

            var employeeSearchQuery = session.QueryOver(() => employeeAlias);

            ApplyEmployeeCriteria(employeeSearchQuery);

            employeeSearchQuery.List().ForEach(employee => matchingEmployee.Add(new EmployeeListItem(employee)));

            return matchingEmployee;
        }
    }
}