using System;
using System.Web.Mvc;
using NHibernateMVC.Domain.Employee;
using NHibernateMVC.Domain.JobHistory;
using NHibernateMVC.Models.Employee;
using NHibernateMVC.Models.Project;

namespace NHibernateMVC.Controllers
{
    /// <summary>
    /// This controller manages employees
    /// </summary>
    public class EmployeeController : Infrastructure.Web.ControllerBase
    {
        /// <summary>
        /// Index - empty page
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Display empty employee form
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            var vm = new EmployeeViewModel();
            return View(vm);
        }
        /// <summary>
        /// Creates employee
        /// </summary>
        /// <param name="employeeForm"></param>
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
        /// <summary>
        /// Shows employee edit form for employee with given id 
        /// </summary>
        /// <param name="employeeId">employee id </param>
        [HttpGet]
        public ActionResult Edit(Guid employeeId)
        {
            var vm = new EmployeeViewModel(Query(new GetEmployeeQuery(employeeId)));
            return View(vm);
        }
        /// <summary>
        /// Updates employee
        /// </summary>
        /// <param name="employeeForm"></param>
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
        /// <summary>
        /// Shows search screen
        /// </summary>
        public ActionResult Search()
        {
            var cmdResults = Query(new GetPositionQuery());
            var cmd2 = Query(new GetAllProjectsQuery());
            return View("Search", new EmployeeSearchViewModel(cmdResults.AllPositions, cmd2.AllProjects));
        }
        /// <summary>
        /// Returnes table with search results
        /// </summary>
        [HttpPost]
        public ActionResult Find(EmployeeSearchForm searchForm)
        {
            return PartialView("_EmployeeList", Query(new GetEmployeeListQuery(searchForm)));
        }
        /// <summary>
        /// Delete employee from db
        /// </summary>
        /// <param name="employeeId">employee id</param>
        /// <returns>Redirect to Search Action</returns>
        public ActionResult Delete(Guid employeeId)
        {
            ExecuteCommand(new DeleteEmployeeCommand(employeeId));
            return RedirectToAction("Search", "Employee");
        }

    }
}