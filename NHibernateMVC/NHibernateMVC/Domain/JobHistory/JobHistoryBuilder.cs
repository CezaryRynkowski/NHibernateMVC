using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Service;
using NHibernateMVC.Models.JobHistory;

namespace NHibernateMVC.Domain.JobHistory
{
    /// <summary>
    /// Class responsible for creations of jobhistory entities
    /// </summary>
    public class JobHistoryBuilder : BusinessService
    {
        /// <summary>
        /// Construct new instance of jobhistory builder
        /// </summary>
        /// <param name="session">nhibernate session</param>
        public JobHistoryBuilder(ISession session)
            :base(session) { }
        /// <summary>
        /// Connstruct new job history out of form data
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public JobHistory ConstructJobHistory(JobHistoryForm form)
        {
            var jh = new JobHistory
            {
                EmployeeId = form.EmployeeId,
                StartDate = DateTime.Today,
                StopDate = null,
                PositionId = form.PositionId,
                JobHistoryId = Guid.NewGuid(),
                Salary = form.Salary
            };

            return jh;
        }
    }
}