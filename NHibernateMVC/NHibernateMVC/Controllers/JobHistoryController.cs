using System;
using System.Web.Mvc;
using NHibernateMVC.Domain.JobHistory;
using NHibernateMVC.Models.JobHistory;

namespace NHibernateMVC.Controllers
{
    public class JobHistoryController : Infrastructure.Web.ControllerBase
    {
        [HttpGet]
        public ActionResult ShowJobHistory(Guid employeeId)
        {
            var vm = new JobHistoryViewModel(Query(new GetJobHistoryQuery(employeeId)));
            return View(vm);
        }

    }
}
