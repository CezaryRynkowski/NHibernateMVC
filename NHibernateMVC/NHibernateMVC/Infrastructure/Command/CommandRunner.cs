using System.Data;
using Castle.Core.Logging;
using Castle.Windsor;
using NHibernate;

namespace NHibernateMVC.Infrastructure.Command
{
    public class CommandRunner
    {
        private readonly IWindsorContainer _windsor;
        //private readonly ILogger log;

        /// <summary>
        /// Creates instance of command runner
        /// </summary>
        /// <param name="windsor">IoC container</param>
        public CommandRunner(IWindsorContainer windsor) 
        {
            this._windsor = windsor;
            //this.log = this.windsor.Resolve<ILogger>();
        }

        /// <summary>
        /// Executes command and returns result from command together with information if command succeeded or failed.
        /// </summary>
        /// <typeparam name="T">return type of command</typeparam>
        /// <param name="cmd">command to execute</param>
        /// <returns></returns>
        public CommandExecutionResult<T> ExecuteCommand<T>(Command<T> cmd)
        {
            ProvideCommonServices(cmd);

            //cmd.SetupDependencies(windsor);

            return InternalRun(cmd);
        }

        /// <summary>
        /// Injects commoan services into command instance
        /// </summary>
        protected virtual void ProvideCommonServices<T>(Command<T> cmd) 
        {
            if (cmd is INeedSession) 
            {
                ((INeedSession)cmd).Session = _windsor.Resolve<ISession>();
            }

            if (cmd is INeedLogger)
            {
                ((INeedLogger) cmd).Logger = _windsor.Resolve<ILogger>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <returns></returns>
        protected virtual CommandExecutionResult<T> InternalRun<T>(Command<T> cmd)
        {
            try
            {
                var decoratedCommand = Decorate(cmd);
                var result = decoratedCommand.Execute();
            
                return CommandExecutionResult<T>.SuccessResult(result);
            }
            catch (NoNullAllowedException businessEx)
            {
                LogCommandExecutionError(cmd, businessEx);
                return CommandExecutionResult<T>.FailureResult(businessEx.InnerException.ToString(), businessEx.Message);
            }
        }

        /// <summary>
        /// Provides aspect behaviours for command using decorator pattern
        /// </summary>
        /// <returns>command object wrapped in set of decarator according to marker interfeces applied to command class</returns>
        protected virtual ICommand<T> Decorate<T>(Command<T> cmd)
        {
            if (cmd is INeedAutocommitTransaction)
            {
                var decoratedCmd = new TxDecorator<T>(cmd);
                decoratedCmd.SetupDependencies(_windsor);
                return decoratedCmd;

            }
            else
                return cmd;
        }

        /// <summary>
        /// Logs erros that occured during command execution
        /// </summary>
        /// <param name="cmd">cmd being executed</param>
        /// <param name="exception">exception</param>
        protected void LogCommandExecutionError<T>(Command<T> cmd,System.Exception exception)
        {
            //log.ErrorFormat("Execution of command: {0} failed. Error details below",cmd.GetType().ToString());
            //log.Error(exception.Message, exception);            
        }
    }

    /// <summary>
    /// Transactional aspect behaviour for command
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TxDecorator<T> : Command<T>
    {
        private readonly ICommand<T> component;
        private ISession currentSession;
        
        /// <summary>
        /// Creates a decorator for given command
        /// </summary>
        /// <param name="component"></param>
        public TxDecorator(ICommand<T> component) 
        {
            this.component = component;
        }

        /// <summary>
        /// Executes command
        /// </summary>
        /// <returns></returns>
        public override T Execute()
        {
            using (var tx = currentSession.BeginTransaction())
            {
                var cmdResult = component.Execute();
                tx.Commit();
                return cmdResult;
            }
        }

        /// <summary>
        /// Resolves NHibenrate session from container
        /// </summary>
        public override void SetupDependencies(IWindsorContainer container)
        {
            currentSession = container.Resolve<ISession>();
        }
        
    }

    /// <summary>
    /// Wraps result from command with information if executed succesfully or not
    /// if not finised sucesfully provides humen friendly message and error code for machines
    /// </summary>
    /// <typeparam name="T">wrapped command result type</typeparam>
    public class CommandExecutionResult<T>
    {
        /// <summary>
        /// True if execution succeeded
        /// </summary>
        public bool Success { get; protected set; }
        /// <summary>
        /// Error code
        /// </summary>
        public string ErrorCode { get; protected set; }
        /// <summary>
        /// Human friendly message
        /// </summary>
        public string MessageForHumans { get; protected set; }
        /// <summary>
        /// Result from wrapped command
        /// </summary>
        public T Result { get; protected set; }

        /// <summary>
        /// Creates success result
        /// </summary>
        public static CommandExecutionResult<T> SuccessResult(T result)
        {
            return new CommandExecutionResult<T> { Success = true, Result = result };
        }

        /// <summary>
        /// Creates failure result
        /// </summary>
        /// <param name="errCode">error code</param>
        /// <param name="msg">human friendly message</param>
        public static CommandExecutionResult<T> FailureResult(string errCode, string msg)
        {
            return new CommandExecutionResult<T> { Success = false, ErrorCode = errCode, MessageForHumans = msg };
        }
    }
}