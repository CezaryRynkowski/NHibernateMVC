using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Project
{
    public class ProjectSearchResultItem
    {
        public Guid? ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}