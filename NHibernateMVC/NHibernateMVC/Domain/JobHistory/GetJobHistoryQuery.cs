using System;
using System.Linq;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;
using NHibernateMVC.Models.JobHistory;

namespace NHibernateMVC.Domain.JobHistory
{
    public class GetJobHistoryQuery : Query<JobHistoryForm>
    {
        private readonly Guid _employeeId;

        public GetJobHistoryQuery(Guid employeeId)
        {
            this._employeeId = employeeId;
        }

        public override JobHistoryForm Execute(ISession session)
        {
            var j = session.QueryOver<JobHistory>()
                .Where(x => x.EmployeeId == _employeeId)
                .List<JobHistory>().ToList();

            return JobHistoryToModelMapper.MapToJobHistoryForm(j);
        }
    }
}