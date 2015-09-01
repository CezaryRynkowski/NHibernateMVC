using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernateMVC.Data;
using NHibernateMVC.Domain.Employee;

namespace NHibernateMVC.Controllers
{
    public class HomeController : Infrastructure.Web.ControllerBase
    {
        private readonly IDao<Employee> daoEmployee;

        public HomeController(IDao<Employee> daoEmployee)
        {
            this.daoEmployee = daoEmployee;
        }

        public ActionResult Index()
        {
            var employees = daoEmployee.RetriveAll().ToList();
            return View(employees);
        }

    }
}
