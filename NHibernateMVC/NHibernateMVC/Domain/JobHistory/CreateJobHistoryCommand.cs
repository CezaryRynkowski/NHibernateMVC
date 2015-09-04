using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using NHibernate;
using NHibernateMVC.Infrastructure.Command;
using NHibernateMVC.Models.JobHistory;

namespace NHibernateMVC.Domain.JobHistory
{
    public class CreateJobHistoryCommand : Command<Guid>, INeedSession, INeedAutocommitTransaction
    {
        private JobHistoryForm jobHistoryForm;
        private JobHistoryBuilder builder;

        public CreateJobHistoryCommand(JobHistoryForm jobHistoryForm)
        {
            this.jobHistoryForm = jobHistoryForm;
        }
        /// <summary>
        /// Executes query
        /// </summary>
        /// <returns></returns>
        public override Guid Execute()
        {
            //construct entity
            JobHistoryBuilder builder = new JobHistoryBuilder(Session);
            var jobHistory = builder.ConstructJobHistory(jobHistoryForm);
            Session.Save(jobHistory);

            return jobHistory.EmployeeId;
        }

        public ISession Session { get; set; }

        public override void SetupDependencies(IWindsorContainer container)
        {
            builder = container.Resolve<JobHistoryBuilder>();
        }
    }
}