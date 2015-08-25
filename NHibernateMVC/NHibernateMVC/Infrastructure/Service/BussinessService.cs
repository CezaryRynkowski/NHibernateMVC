using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Infrastructure.Service
{
    /// <summary>
    /// Base class for business services.
    /// Business services are classes that contain:
    /// business algorithm implentation
    /// validation rules
    /// state management and workflow for business entities.
    /// 
    /// Base class provides ability to access common services like queries execution.
    /// Business servies should not execute commands - it should be the other way around - threfeore there are no methods 
    /// to execute commands.
    /// 
    /// To implement a business service derive your class from business service. Business service installer by default will register
    /// it in container.
    /// </summary>
    public abstract class BusinessService
    {
        protected NHibernate.ISession Session { get; private set; }

        /// <summary>
        /// Construct new instance, expects NHibernate session to be injcected
        /// </summary>
        public BusinessService(NHibernate.ISession session)
        {
            this.Session = session;
        }

        /// <summary>
        /// Executes query
        /// </summary>
        protected virtual TResult Query<TResult>(Query<TResult> queryToExecute)
        {
            return queryToExecute.Execute(Session);
        }
    }
}