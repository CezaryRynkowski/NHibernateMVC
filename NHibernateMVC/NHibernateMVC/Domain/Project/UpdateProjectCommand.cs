﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using NHibernate;
using NHibernateMVC.Infrastructure.Command;
using NHibernateMVC.Models.Project;

namespace NHibernateMVC.Domain.Project
{
    /// <summary>
    /// Updates project data
    /// </summary>
    public class UpdateProjectCommand : Command<Guid>, INeedSession, INeedAutocommitTransaction
    {
        private readonly ProjectForm _projectForm;
        private ProjectBuilder _projectBuilder;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="projectForm"></param>
        public UpdateProjectCommand(ProjectForm projectForm)
        {
            _projectForm = projectForm;
        }
        /// <summary>
        /// Executes query
        /// </summary>
        /// <returns></returns>
        public override Guid Execute()
        {
            ProjectBuilder builder = new ProjectBuilder(Session);
            var project = Session.Get<Project>(_projectForm.ProjectId);
            builder.UpdateProject(project,_projectForm);
            Session.Update(project);

            return project.ProjectId;
        }

        public ISession Session { get; set; }

        public override void SetupDependencies(IWindsorContainer container)
        {
            _projectBuilder = container.Resolve<ProjectBuilder>();
        }
    }
}