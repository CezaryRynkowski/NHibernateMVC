using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Project
{
    public class ProjectSearchViewModel
    {
        public ProjectSearchForm SearchForm { get; set; }

        public IList<ProjectSearchResultItem> Result { get; set; }

        public ProjectSearchViewModel()
        {
            SearchForm = new ProjectSearchForm();
            Result = new List<ProjectSearchResultItem>();
        }
    }
}