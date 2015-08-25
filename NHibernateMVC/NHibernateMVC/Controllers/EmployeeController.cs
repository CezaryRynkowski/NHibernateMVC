using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernateMVC.Models.Employee;

namespace NHibernateMVC.Controllers
{
    public class EmployeeController : Controller
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
        }

    }
}
