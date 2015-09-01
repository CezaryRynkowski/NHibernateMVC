using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Project
{
    public class ProjectViewModel
    {
        public ProjectForm ProjectForm { get; set; }

        public ProjectViewModel()
        {
            ProjectForm = new ProjectForm();
        }

        public ProjectViewModel(ProjectForm projectForm)
        {
            ProjectForm = new ProjectForm(projectForm);
        }
    }
}