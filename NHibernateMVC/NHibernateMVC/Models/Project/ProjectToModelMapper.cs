using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Project
{
    public class ProjectToModelMapper
    {
        public static ProjectForm MapToProjectForm(Domain.Project.Project project)
        {
            return new ProjectForm
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName
            };
        }
    }
}