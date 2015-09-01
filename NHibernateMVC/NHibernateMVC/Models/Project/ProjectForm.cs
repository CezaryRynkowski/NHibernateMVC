using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Project
{
    public class ProjectForm
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } 

        public ProjectForm(ProjectForm projectForm)
        {
            ProjectId = projectForm.ProjectId;
            ProjectName = projectForm.ProjectName;
        }

        public ProjectForm() { }

    }
}