using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateMVC.Domain.Employee;
using NHibernateMVC.Domain.JobHistory;

namespace NHibernateMVC.Models.Employee
{
    public class EmployeeSearchViewModel
    {
        /// <summary>
        /// employee search form
        /// </summary>
        public EmployeeSearchForm SearchForm { get; set; }
        /// <summary>
        /// results query
        /// </summary>
        private IList<EmployeeSearchResultItem> Results { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public EmployeeSearchViewModel()
        {
            Results = new List<EmployeeSearchResultItem>();
        }

        public EmployeeSearchViewModel(List<NHibernateMVC.Domain.JobHistory.Position> position, List<Domain.Project.Project> projects )
        {
            SearchForm = new EmployeeSearchForm {Positions = position, AllProjects = projects};
        }
    }
}