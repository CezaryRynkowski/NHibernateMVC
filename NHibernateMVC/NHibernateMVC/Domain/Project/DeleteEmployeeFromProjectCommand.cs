using System;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Domain.Project
{
    public class DeleteEmployeeFromProjectCommand : Query<Domain.Project.Project>
    {
        private readonly Guid _employeeId;
        private readonly Guid _projectId;

        public DeleteEmployeeFromProjectCommand(Guid employeeId, Guid projectId)
        {
            _employeeId = employeeId;
            _projectId = projectId;
        }
        /// <summary>
        /// execites query
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public override Project Execute(ISession session)
        {
             session.GetNamedQuery("deleteEmployee")
                .SetParameter("employee", _employeeId)
                .SetParameter("project", _projectId)
                .UniqueResult();

            return null;
        }
    }
}