using System.Collections.Generic;
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
            get { return commandRunner ?? (commandRunner = Container.Resolve<CommandRunner>()); }
        }

        /// <summary>
        /// Executes command and provides generic processing of results
        /// </summary>
        protected CommandExecutionResult<T> ExecuteCommand<T>(Command<T> cmd)
        {
                var cmdResult = CommandRunner.ExecuteCommand(cmd);
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
        }
    }
}