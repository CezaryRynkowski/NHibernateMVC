using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Core.Logging;
using Castle.Windsor;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Infrastructure.Command
{
    public interface ICommand<T>
    {
        /// <summary>
        /// Executes a command and returns result
        /// </summary>
        /// <returns>command result</returns>
        T Execute();

        /// <summary>
        /// Tells if command can be executed
        /// </summary>
        /// <returns>true if command can be executed otherwise false</returns>
        bool CanExecute();
    }

    /// <summary>
    /// Base command class
    /// </summary>
    /// <typeparam name="T">type of returned result</typeparam>
    public abstract class Command<T> : ICommand<T>
    {
        /// <summary>
        /// Executes a command and returns result
        /// </summary>
        /// <returns>command result</returns>
        public abstract T Execute();

        /// <summary>
        /// Tells if command can be executed
        /// </summary>
        /// <returns>base implementation returns true</returns>
        public virtual bool CanExecute()
        {
            return true;
        }

        /// <summary>
        /// Executes query. Reqires calling command to implement INeedSession, as it will try to execute query 
        /// on the same session as command
        /// </summary>
        protected virtual TResult Query<TResult>(Query<TResult> queryToExecute)
        {
            var sessionProvider = this as INeedSession;
            //if (sessionProvider == null)
                //throw new TechnicalException("Command classes that require ability to execute queries must implement INeedSession interface.");
            return queryToExecute.Execute(sessionProvider.Session);
        }

        /// <summary>
        /// Override to resolve your command custom dependencies. Other than commmon services you can get by marking ypur class
        /// with INeedSession, INeedLogger,INeedAutocommitTransaction
        /// </summary>
        /// <param name="container">IoC container</param>
        public abstract void SetupDependencies(IWindsorContainer container);
    }

    /// <summary>
    /// Marker interface which tells command runner that it should inject NHibernate session into class
    /// </summary>
    public interface INeedSession
    {
        /// <summary>
        /// NHibernate session instance.
        /// </summary>
        ISession Session { get; set; }
    }

    /// <summary>
    /// Marker interface which tells command runner that it should inject Logger into class
    /// </summary>
    public interface INeedLogger
    {
        ILogger Logger { get; set; }
    }

    /// <summary>
    /// Marker interface that tells command runner that this command should execute in transaction that 
    /// should be commited if Execute methods end normally.
    /// If Execute call causes Exception to be thrown then transaction is rollbacked.
    /// </summary>
    public interface INeedAutocommitTransaction { }
}