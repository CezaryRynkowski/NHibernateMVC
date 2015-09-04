using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Project
{
    public class ProjectSearchResultItem
    {
        /// <summary>
        /// project id
        /// </summary>
        public Guid? ProjectId { get; set; }
        /// <summary>
        /// project name
        /// </summary>
        public string ProjectName { get; set; }
    }
}