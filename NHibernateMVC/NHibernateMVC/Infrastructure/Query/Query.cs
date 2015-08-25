using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Command;

namespace NHibernateMVC.Infrastructure.Query
{
    public abstract class Query<TResult>
    {
        /// <summary>
        /// IMplement this method to construct and execute a query against provided NHibernate session
        /// </summary>
        /// <param name="session">NHibernate session</param>
        public abstract TResult Execute(NHibernate.ISession session);
    }

    /// <summary>
    /// Extension method on NHibernate session that allows execution of queries
    /// </summary>
    public static class NHibernateSessionQueryExtension
    {
        /// <summary>
        /// Executes query on given session
        /// </summary>
        /// <typeparam name="TResult">type of resuts from query</typeparam>
        /// <param name="session">NHibernate session to be used to run query</param>
        /// <param name="queryToRun">query to execute</param>
        public static TResult Query<TResult>(this ISession session, Query<TResult> queryToRun)
        {
            return queryToRun.Execute(session);
        }
    }
}