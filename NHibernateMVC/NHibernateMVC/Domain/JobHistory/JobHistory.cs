using System;

namespace NHibernateMVC.Domain.JobHistory
{
    public class JobHistory
    {
        /// <summary>
        /// job history id - guid
        /// </summary>
        public virtual Guid JobHistoryId { get; set; }
        /// <summary>
        /// positon id - int
        /// </summary>
        public virtual int PositionId { get; set; }
        /// <summary>
        /// date when employee start job
        /// </summary>
        public virtual DateTime StartDate { get; set; }
        /// <summary>
        /// date when employee end job /nullable
        /// </summary>
        public virtual DateTime? StopDate { get; set; }
        /// <summary>
        /// salary 
        /// </summary>
        public virtual string Salary { get; set; }
        /// <summary>
        /// employee id - guid
        /// </summary>
        public virtual Guid EmployeeId { get; set; }
    }
}
