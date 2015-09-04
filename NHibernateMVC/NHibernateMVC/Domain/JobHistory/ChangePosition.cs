using System;
using Castle.Windsor;
using NHibernate;
using NHibernateMVC.Infrastructure.Command;
using NHibernateMVC.Models.JobHistory;

namespace NHibernateMVC.Domain.JobHistory
{
    public class ChangePositionCommand : Command<Guid>, INeedSession, INeedAutocommitTransaction
    {
        private readonly Guid _jobHistoryId;
        private JobHistoryBuilder _jobHistoryBuilder;
        private JobHistoryForm _jobHistoryForm;

        public ChangePositionCommand(Guid jobHistoryId)
        {
            this._jobHistoryId = jobHistoryId;
        }
        /// <summary>
        /// Executes query
        /// </summary>
        /// <returns></returns>
        public override Guid Execute()
        {
            //construct entity
            var j = Session.Get<JobHistory>(_jobHistoryId);
            j.StopDate = DateTime.Today;
            Session.Update(j);

            return j.EmployeeId;
        }

        public ISession Session { get; set; }

        public override void SetupDependencies(IWindsorContainer container)
        {
            _jobHistoryBuilder = container.Resolve<JobHistoryBuilder>();
        }
    }
}