using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateMVC.Domain.JobHistory;

namespace NHibernateMVC.Models.JobHistory
{
    public class JobHistoryForm
    {
        /// <summary>
        /// Job History id - guid
        /// </summary>
        public Guid JobHistoryId { get; set; }
        /// <summary>
        /// position id int
        /// </summary>
        public int PositionId { get; set; }
        /// <summary>
        /// start date
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// stop/end date
        /// </summary>
        public DateTime? StopDate { get; set; }
        /// <summary>
        /// salary
        /// </summary>
        public string Salary { get; set; }
        /// <summary>
        /// employee id
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// List of all positions from db
        /// </summary>
        public List<PositionModel> Positions { get; set; } 
        /// <summary>
        /// list of job history for employee
        /// </summary>
        public List<Domain.JobHistory.JobHistory> List { get; set; } 
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="jobHistoryForm"></param>
        public JobHistoryForm(JobHistoryForm jobHistoryForm)
        {
            //JobHistoryId = jobHistoryForm.JobHistoryId;
            PositionId = jobHistoryForm.PositionId;
            StartDate = jobHistoryForm.StartDate;
            StopDate = jobHistoryForm.StopDate;
            Salary = jobHistoryForm.Salary;
            EmployeeId = jobHistoryForm.EmployeeId;
            List = jobHistoryForm.List;
            Positions = jobHistoryForm.Positions;
        }
        /// <summary>
        /// empty constructor
        /// </summary>
        public JobHistoryForm() {  }
    }
}