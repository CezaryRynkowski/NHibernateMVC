using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using NHibernateMVC.Domain.Employee;
using NHibernateMVC.Models.Employee;
using NHibernateMVC.Infrastructure.Web;
using NHibernateMVC.Infrastructure.Service;

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

            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                .Select(x => new {x.Key, x.Value.Errors})
                .ToArray();
                

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var cmdResult = ExecuteCommand(new CreateEmployeeCommand(employeeForm));

            if (cmdResult.Success) return RedirectToAction("Edit", new { employeeId = cmdResult.Result });
            else return View(vm);
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
            return View("Search", new EmployeeSearchViewModel());
        }

        [HttpPost]
        public ActionResult Find(EmployeeSearchForm searchForm)
        {
            return PartialView("_EmployeeList", Query(new GetEmployeeListQuery(searchForm)));
        }

        public ActionResult Delete(Guid employeeId)
        {
            var cmdResult = ExecuteCommand(new DeleteEmployeeCommand(employeeId));
            return RedirectToAction("Search", "Employee");
        }

    }
}
