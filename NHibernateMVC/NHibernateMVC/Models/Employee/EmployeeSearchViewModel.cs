using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateMVC.Domain.JobHistory;

namespace NHibernateMVC.Models.Employee
{
    public class EmployeeSearchViewModel
    {
        public EmployeeSearchForm SearchForm { get; set; }

        //public EmployeeSearchForm Criteria { get; set; }

        public IList<EmployeeSearchResultItem> Results { get; set; }

        public EmployeeSearchViewModel()
        {
            //Criteria = new EmployeeSearchForm();
            Results = new List<EmployeeSearchResultItem>();
        }

        public EmployeeSearchViewModel(List<NHibernateMVC.Domain.JobHistory.Position> position)
        {
            SearchForm = new EmployeeSearchForm {Positions = position};
        }
    }
}