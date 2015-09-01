using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Models.Project
{
    public class GetProjectQuery : Query<ProjectForm>
    {
        private readonly Guid projectId;

        public GetProjectQuery(Guid projectId)
        {
            this.projectId = projectId;
        }

        public override ProjectForm Execute(ISession session)
        {
            var p = session.Get<Domain.Project.Project>(projectId);

            return ProjectToModelMapper.MapToProjectForm(p);
        }
    }
}