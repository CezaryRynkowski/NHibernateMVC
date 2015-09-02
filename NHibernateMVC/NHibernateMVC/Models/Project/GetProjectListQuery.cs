using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Transform;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Models.Project
{
    public class GetProjectListQuery : Query<IList<ProjectListItem>>
    {
        private readonly ProjectSearchForm searchForm;

        public GetProjectListQuery(ProjectSearchForm searchForm)
        {
            this.searchForm = searchForm;
        }

        public override IList<ProjectListItem> Execute(ISession session)
        {
            return session.GetNamedQuery("projectSearchQuery")
                .SetResultTransformer(Transformers.AliasToBean<ProjectListItem>())
                .List<ProjectListItem>();
        }

    }

    public class ProjectListItem
    {
        public ProjectListItem(Guid projectId, string projectName)
        {
            ProjectId = projectId;
            ProjectName = projectName;
        }

        public ProjectListItem() { }

        public Guid ProjectId { get; private set; }
        public string ProjectName { get; private set; }
    }
}