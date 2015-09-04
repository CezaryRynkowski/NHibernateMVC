using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using NHibernate;
using NHibernateMVC.Domain.Employee;
using NHibernateMVC.Infrastructure.Command;
using NHibernateMVC.Models.Project;

namespace NHibernateMVC.Domain.Project
{
    /// <summary>
    /// create 
    /// </summary>
    public class CreateProjectCommand : Command<Guid>, INeedSession, INeedAutocommitTransaction
    {
        private ProjectForm ProjectForm;
        private ProjectBuilder ProjectBuilder;

        public CreateProjectCommand(ProjectForm projectForm)
        {
            this.ProjectForm = projectForm;
        }
        /// <summary>
        /// Executes query
        /// </summary>
        /// <returns></returns>
        public override Guid Execute()
        {
            ProjectBuilder builder = new ProjectBuilder(Session);

            var project = builder.ConstructProject(ProjectForm);
            Session.Save(project);

            return project.ProjectId;
        }

        public ISession Session { get; set; }

        public override void SetupDependencies(IWindsorContainer container)
        {
            ProjectBuilder = container.Resolve<ProjectBuilder>();

        }
    }
}