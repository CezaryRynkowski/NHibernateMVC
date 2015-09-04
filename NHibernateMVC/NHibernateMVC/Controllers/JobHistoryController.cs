using System;
using System.Web.Mvc;
using NHibernateMVC.Domain.JobHistory;
using NHibernateMVC.Models.JobHistory;

namespace NHibernateMVC.Controllers
{
    /// <summary>
    /// Job History controller
    /// </summary>
    public class JobHistoryController : Infrastructure.Web.ControllerBase
    {
        /// <summary>
        /// Show table with job history for employee
        /// </summary>
        /// <param name="employeeId">employee id</param>
        [HttpGet]
        public ActionResult ShowJobHistory(Guid employeeId)
        {
            var vm = new JobHistoryViewModel(Query(new GetJobHistoryQuery(employeeId)));
            return View(vm);
        }
        /// <summary>
        /// Add StopDate to job history table
        /// </summary>
        /// <param name="jobHistoryId"></param>
        public ActionResult ChangePositon(Guid jobHistoryId)
        {
            var test = ExecuteCommand(new ChangePositionCommand(jobHistoryId));
            return RedirectToAction("ShowJobHistory", "JobHistory", new {employeeId = test.Result});
        }
        /// <summary>
        /// Shows job history form
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            var positions = Query(new GetPositionQuery());
            var vm = new JobHistoryViewModel(positions);
            return View(vm);
        }
        /// <summary>
        /// Creates new position/job history
        /// </summary>
        /// <param name="jobHistoryForm"></param>
        [HttpPost]
        public ActionResult Create(JobHistoryForm jobHistoryForm)
        {
            var vm = new JobHistoryViewModel(jobHistoryForm);

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var cmdResult = ExecuteCommand(new CreateJobHistoryCommand(jobHistoryForm));
            if (cmdResult.Success) return RedirectToAction("ShowJobHistory", new {employeeId = cmdResult.Result});
            return View(vm);
        }
    }
}
