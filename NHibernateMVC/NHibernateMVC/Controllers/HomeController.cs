using System.Linq;
using System.Web.Mvc;
using NHibernateMVC.Data;
using NHibernateMVC.Domain.Employee;

namespace NHibernateMVC.Controllers
{
    public class HomeController : Infrastructure.Web.ControllerBase
    {
        private readonly IDao<Employee> _daoEmployee;

        public HomeController(IDao<Employee> daoEmployee)
        {
            _daoEmployee = daoEmployee;
        }

        public ActionResult Index()
        {
            var employees = _daoEmployee.RetriveAll().ToList();
            return View(employees);
        }

    }
}
