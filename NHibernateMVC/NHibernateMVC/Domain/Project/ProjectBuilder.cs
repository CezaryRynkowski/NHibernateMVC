using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Service;
using NHibernateMVC.Models.Project;

namespace NHibernateMVC.Domain.Project
{
    /// <summary>
    /// class responsible for creation of project entities
    /// </summary>
    public class ProjectBuilder : BusinessService
    {
        /// <summary>
        /// Construct new instance of project builder
        /// </summary>
        /// <param name="session"></param>
        public ProjectBuilder(ISession session)
            :base(session) { }
        /// <summary>
        /// construct new project out of form data
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Project ConstructProject(ProjectForm form)
        {
            var p = new Project
            {
                ProjectId = form.ProjectId,
                ProjectName = form.ProjectName
            };

            return p;
        }
        /// <summary>
        /// Updates roject with data from the web form 
        /// </summary>
        /// <param name="projectToUpdate">project entity from database</param>
        /// <param name="projectForm">data entered on web form</param>
        public void UpdateProject(Project projectToUpdate, ProjectForm projectForm)
        {
            projectToUpdate.ProjectName = projectForm.ProjectName;
        }
    }
}