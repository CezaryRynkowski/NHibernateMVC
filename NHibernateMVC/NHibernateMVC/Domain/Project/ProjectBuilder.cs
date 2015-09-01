using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Service;
using NHibernateMVC.Models.Project;

namespace NHibernateMVC.Domain.Project
{
    public class ProjectBuilder : BusinessService
    {
        public ProjectBuilder(ISession session)
            :base(session) { }

        public Project ConstructProject(ProjectForm form)
        {
            var p = new Project
            {
                ProjectId = form.ProjectId,
                ProjectName = form.ProjectName
            };

            return p;
        }

        public void UpdateProject(Project projectToUpdate, ProjectForm projectForm)
        {
            projectToUpdate.ProjectName = projectForm.ProjectName;
        }
    }
}