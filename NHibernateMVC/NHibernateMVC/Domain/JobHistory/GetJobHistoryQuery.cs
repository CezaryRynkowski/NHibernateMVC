using System;
using System.Linq;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;
using NHibernateMVC.Models.JobHistory;

namespace NHibernateMVC.Domain.JobHistory
{
    /// <summary>
    /// Loads data for job history form for employee with given Id
    /// </summary>
    public class GetJobHistoryQuery : Query<JobHistoryForm>
    {
        private readonly Guid _employeeId;
        /// <summary>
        /// construct query objcect
        /// </summary>
        /// <param name="employeeId"></param>
        public GetJobHistoryQuery(Guid employeeId)
        {
            _employeeId = employeeId;
        }
        /// <summary>
        /// Executes query
        /// </summary>
        /// <param name="session">NHibernate session</param>
        /// <returns>jon history data</returns>
        public override JobHistoryForm Execute(ISession session)
        {
            var j = session.QueryOver<JobHistory>()
                .Where(x => x.EmployeeId == _employeeId)
                .List<JobHistory>().ToList();

            return JobHistoryToModelMapper.MapToJobHistoryForm(j);
        }
    }
}