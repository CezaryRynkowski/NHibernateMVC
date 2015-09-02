using System.Collections.Generic;
using System.Linq;
using NHibernateMVC.Domain.JobHistory;

namespace NHibernateMVC.Models.JobHistory
{
    public partial class JobHistoryToModelMapper
    {
        public static JobHistoryForm MapToJobHistoryForm(List<Domain.JobHistory.JobHistory> job)
        {
            return new JobHistoryForm
            {
                List = job.ToList(),              
            };
        }
    }
}