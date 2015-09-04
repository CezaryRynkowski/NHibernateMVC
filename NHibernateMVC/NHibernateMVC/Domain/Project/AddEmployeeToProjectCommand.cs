using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Domain.Project
{
    /// <summary>
    /// add employee to project
    /// </summary>
    public class AddEmployeeToProjectCommand : Query<Project>
    {
        private readonly Guid _employeeId;
        private readonly Guid _projectId;

        public AddEmployeeToProjectCommand(Guid employeeId, Guid projectId)
        {
            _employeeId = employeeId;
            _projectId = projectId;
        }
        /// <summary>
        /// Executes query
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public override Project Execute(ISession session)
        {
            session.GetNamedQuery("addEmployee")
                .SetParameter("employee", _employeeId)
                .SetParameter("project", _projectId)
                .UniqueResult();

            return null;
        }
    }
}