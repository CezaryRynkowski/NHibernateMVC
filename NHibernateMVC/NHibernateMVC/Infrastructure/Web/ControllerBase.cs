using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Windsor;
using NHibernate;
using NHibernateMVC.Infrastructure.Command;
using NHibernateMVC.Infrastructure.Query;

namespace NHibernateMVC.Infrastructure.Web
{
    public abstract class ControllerBase : Controller
    {
        /// <summary>
        /// Windsor container reference injected on controller creation
        /// </summary>
        public IWindsorContainer Container{ get; set; }

        private CommandRunner commandRunner { get; set; }
    
        /// <summary>
        /// Command runner used internally to execute commands, resolved from container
        /// </summary>
        protected CommandRunner CommandRunner
        {
            get
            {
                if (commandRunner == null)
                    commandRunner = Container.Resolve<CommandRunner>();
                return commandRunner;
            }
        }

        /// <summary>
        /// Executes command and provides generic processing of results
        /// </summary>
        protected CommandExecutionResult<T> ExecuteCommand<T>(Command<T> cmd)
        {
                var cmdResult = CommandRunner.ExecuteCommand(cmd);
                if (!cmdResult.Success)
                {
                    Error(cmdResult.MessageForHumans);
                }
                return cmdResult;
        }

        /// <summary>
        /// Executes given query and returns results
        /// </summary>
        protected TResult Query<TResult>(Query<TResult> queryToRun)
        {
            return ProvideSession().Query(queryToRun);
        }

        /// <summary>
        /// Gives access to session
        /// </summary>
        protected ISession ProvideSession()
        {
            return Container.Resolve<ISession>();
        }

        private void AddMessage(string msgType, string msg)
        {
            if (TempData.ContainsKey(msgType))
            {
                ((List<string>) TempData[msgType]).Add(msg);
            }
            else
            {
                TempData[msgType] = new List<string> {msg};
            }
        }

        /// <summary>
        /// Causes bootstrap attention message to be rendered
        /// </summary>
        protected void Attention(string message)
        {
            //AddMessage(Alerts.ATTENTION, message);
        }

        /// <summary>
        /// Causes bootstrap success message to be rendered
        /// </summary>
        protected void Success(string message)
        {
            //AddMessage(Alerts.SUCCESS, message);
        }

        /// <summary>
        /// Causes bootstrap information message to be rendered
        /// </summary>
        protected void Information(string message)
        {
            //AddMessage(Alerts.INFORMATION, message);
        }

        /// <summary>
        /// Causes bootstrap error message to be rendered
        /// </summary>
        protected void Error(string message)
        {
            //AddMessage(Alerts.ERROR, message);
        }

        /// <summary>
        /// renders bootstrap error for all errors in model state
        /// </summary>
        protected void Error(ModelStateDictionary modelState)
        {
            var errMsg = new System.Text.StringBuilder();
            foreach (var m in ViewData.ModelState.Values)
            {
                foreach (var modelError in m.Errors)
                {
                    errMsg.AppendLine(modelError.ErrorMessage);
                }
            }
            //AddMessage(Alerts.ERROR, errMsg.ToString());
        }
    }
}