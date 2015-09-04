using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Project
{
    public class ProjectViewModel
    {
        /// <summary>
        /// project form
        /// </summary>
        public ProjectForm ProjectForm { get; set; }
        /// <summary>
        /// constructor 
        /// </summary>
        public ProjectViewModel()
        {
            ProjectForm = new ProjectForm();
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="projectForm"></param>
        public ProjectViewModel(ProjectForm projectForm)
        {
            ProjectForm = new ProjectForm(projectForm);
        }
    }
}