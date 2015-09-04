using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Project
{
    /// <summary>
    /// maps project to model instances
    /// </summary>
    public class ProjectToModelMapper
    {
        /// <summary>
        /// maps project entity to project form model
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public static ProjectForm MapToProjectForm(Domain.Project.Project project)
        {
            return new ProjectForm
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName
            };
        }
        /// <summary>
        /// amaps project entity to project form model
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public static ProjectForm MapToForm(List<Domain.Project.Project> project)
        {
            return new ProjectForm
            {
                AllProjects = project.ToList()
            };
        }
    }
}