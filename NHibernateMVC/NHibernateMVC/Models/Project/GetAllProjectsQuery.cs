using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Models.Project
{
    public class GetAllProjectsQuery : Query<ProjectForm>
    {
        public GetAllProjectsQuery() { }
        /// <summary>
        /// Executes query
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public override ProjectForm Execute(ISession session)
        {
            var p = session.QueryOver<Domain.Project.Project>()
                .Where(x => x.ProjectId != null)
                .List<Domain.Project.Project>().ToList();

            return ProjectToModelMapper.MapToForm(p);
        }
    }
}