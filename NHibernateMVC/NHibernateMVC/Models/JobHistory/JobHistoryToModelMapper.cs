using System.Collections.Generic;
using System.Linq;
using NHibernateMVC.Domain.JobHistory;

namespace NHibernateMVC.Models.JobHistory
{
    /// <summary>
    /// Maps jobhistory to model instances
    /// </summary>
    public class JobHistoryToModelMapper
    {
        /// <summary>
        /// maps jobhistory entity to jobhistory form model
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public static JobHistoryForm MapToJobHistoryForm(List<Domain.JobHistory.JobHistory> job)
        {
            return new JobHistoryForm
            {
                List = job.ToList(),              
            };
        }
    }
}