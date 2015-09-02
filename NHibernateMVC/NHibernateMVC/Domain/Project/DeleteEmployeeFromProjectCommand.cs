using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Command;
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

        public override Project Execute(ISession session)
        {
             session.GetNamedQuery("deleteEmployee")
                 //.CreateQuery("delete from EmployeeProject where EmployeeId = @employee and ProjectId = @project")
                .SetParameter("employee", _employeeId)
                .SetParameter("project", _projectId)
                .UniqueResult();

            return null;
        }
    }
}