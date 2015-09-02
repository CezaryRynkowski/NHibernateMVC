using System;
using System.Linq;
using System.Web.Mvc;
using NHibernateMVC.Domain.Employee;
using NHibernateMVC.Domain.JobHistory;
using NHibernateMVC.Domain.Project;
using NHibernateMVC.Infrastructure.Command;
using NHibernateMVC.Models.Employee;
using NHibernateMVC.Models.Project;

namespace NHibernateMVC.Controllers
{
    public class EmployeeController : Infrastructure.Web.ControllerBase
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var vm = new EmployeeViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(EmployeeForm employeeForm)
        {
            var vm = new EmployeeViewModel(employeeForm);

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var cmdResult = ExecuteCommand(new CreateEmployeeCommand(employeeForm));

            if (cmdResult.Success) return RedirectToAction("Edit", new { employeeId = cmdResult.Result });
            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit(Guid employeeId)
        {
            var vm = new EmployeeViewModel(Query(new GetEmployeeQuery(employeeId)));
            return View(vm);
        }

        [HttpPost]
        public ActionResult Update(EmployeeForm employeeForm)
        {
            var vm = new EmployeeViewModel(employeeForm);

            if (!ModelState.IsValid)
            {
                return View("Edit", vm);
            }

            var cmdResult = ExecuteCommand(new UpdateEmployeeCommand(employeeForm));

            if (cmdResult.Success) return RedirectToAction("Edit", new {employeeId = cmdResult.Result});
            return View("Edit", vm);
        }

        public ActionResult Search()
        {
            var cmdResults = Query(new GetPositionQuery());
            EmployeeSearchViewModel searchViewModel = new EmployeeSearchViewModel();
            return View("Search", new EmployeeSearchViewModel(cmdResults.AllPositions));
        }

        [HttpPost]
        public ActionResult Find(EmployeeSearchForm searchForm)
        {
            return PartialView("_EmployeeList", Query(new GetEmployeeListQuery(searchForm)));
        }

        public ActionResult Delete(Guid employeeId)
        {
            ExecuteCommand(new DeleteEmployeeCommand(employeeId));
            return RedirectToAction("Search", "Employee");
        }

    }
}