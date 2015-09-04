using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateMVC.Models.Project
{
    public class ProjectSearchViewModel
    {
        /// <summary>
        /// search form
        /// </summary>
        public ProjectSearchForm SearchForm { get; set; }
        /// <summary>
        /// list of results query
        /// </summary>
        public IList<ProjectSearchResultItem> Result { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public ProjectSearchViewModel()
        {
            SearchForm = new ProjectSearchForm();
            Result = new List<ProjectSearchResultItem>();
        }
    }
}