using System;
using System.Web.Mvc;
using NHibernateMVC.Domain.Project;
using NHibernateMVC.Models.Employee;
using NHibernateMVC.Models.Project;

namespace NHibernateMVC.Controllers
{
    public class ProjectController : Infrastructure.Web.ControllerBase
    {
        //
        // GET: /Project/

        [HttpGet]
        public ActionResult Index()
        {
            return View("Index", new ProjectSearchViewModel());
        }

        [HttpPost]
        public ActionResult Find(ProjectSearchForm searchForm)
        {
            return PartialView("_ProjectList", Query(new GetProjectListQuery(searchForm)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var vm = new ProjectViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(ProjectForm projectForm)
        {
            var vm= new ProjectViewModel(projectForm);

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var cmdResult = ExecuteCommand(new CreateProjectCommand(projectForm));
            
            if(cmdResult.Success) return RedirectToAction("Edit","Project", new {projectId=cmdResult.Result});
            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit(Guid projectId)
        {
            var EmployeeList = Query(new GetEmployeeListQuery());
            var employeesInProject = Query(new GetEmployeeFromProjectQuery(projectId));
            var vm = new ProjectViewModel(Query(new GetProjectQuery(projectId)));
            vm.ProjectForm.List = employeesInProject;
            vm.ProjectForm.EmployeesList = EmployeeList;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Update(ProjectForm projectForm)
        {
            var vm = new ProjectViewModel(projectForm);

            if (!ModelState.IsValid)
            {
                return View("Edit", vm);
            }

            var cmdResult = ExecuteCommand(new UpdateProjectCommand(projectForm));

            if (cmdResult.Success) return RedirectToAction("Edit", new {projectId = cmdResult.Result});
            return View("Edit", vm);
        }

        public ActionResult DeleteEmployeeFromProject(Guid employeeId, Guid projectId)
        {
            var query = Query(new DeleteEmployeeFromProjectCommand(employeeId, projectId));
            return RedirectToAction("Edit","Project",new {projectId=projectId});
        }
    }
}
