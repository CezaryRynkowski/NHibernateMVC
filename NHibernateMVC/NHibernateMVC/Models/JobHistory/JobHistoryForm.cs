using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateMVC.Domain.JobHistory;

namespace NHibernateMVC.Models.JobHistory
{
    public class JobHistoryForm
    {
        public Guid JobHistoryId { get; set; }
        public int PositionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? StopDate { get; set; }
        public string Salary { get; set; }
        public Guid EmployeeId { get; set; }

        public List<Domain.JobHistory.JobHistory> List { get; set; } 


        public JobHistoryForm(JobHistoryForm jobHistoryForm)
        {
            JobHistoryId = jobHistoryForm.JobHistoryId;
            PositionId = jobHistoryForm.PositionId;
            StartDate = jobHistoryForm.StartDate;
            StopDate = jobHistoryForm.StopDate;
            Salary = jobHistoryForm.Salary;
            EmployeeId = jobHistoryForm.EmployeeId;
            List = jobHistoryForm.List;
        }
        public JobHistoryForm() {  }
    }
}