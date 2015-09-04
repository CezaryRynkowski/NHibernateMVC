using System;
using System.Web.Mvc;
using NHibernateMVC.Domain.Project;
using NHibernateMVC.Models.Employee;
using NHibernateMVC.Models.Project;

namespace NHibernateMVC.Controllers
{
    /// <summary>
    /// Project operation controller
    /// </summary>
    public class ProjectController : Infrastructure.Web.ControllerBase
    {
        /// <summary>
        /// Shows project search screen
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index", new ProjectSearchViewModel());
        }
        /// <summary>
        /// Returnes table with search results
        /// </summary>
        /// <param name="searchForm"></param>
        [HttpPost]
        public ActionResult Find(ProjectSearchForm searchForm)
        {
            return PartialView("_ProjectList", Query(new GetProjectListQuery(searchForm)));
        }
        /// <summary>
        /// Shows project entry form
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            var vm = new ProjectViewModel();
            return View(vm);
        }
        /// <summary>
        /// Creates project
        /// </summary>
        /// <param name="projectForm"></param>
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
        /// <summary>
        /// Shows project edit form for project with given id
        /// </summary>
        /// <param name="projectId">project id</param>
        [HttpGet]
        public ActionResult Edit(Guid projectId)
        {
            var employeeList = Query(new GetEmployeeListQuery());
            var employeesInProject = Query(new GetEmployeeFromProjectQuery(projectId));
            var vm = new ProjectViewModel(Query(new GetProjectQuery(projectId)));
            vm.ProjectForm.List = employeesInProject;
            vm.ProjectForm.EmployeesList = employeeList;
            return View(vm);
        }
        /// <summary>
        /// Update project
        /// </summary>
        /// <param name="projectForm"></param>
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
        /// <summary>
        /// delete employee by id from project 
        /// </summary>
        /// <param name="employeeId">employee id</param>
        /// <param name="projectId">project id</param>
        public ActionResult DeleteEmployeeFromProject(Guid employeeId, Guid projectId)
        {
            var query = Query(queryToRun: new DeleteEmployeeFromProjectCommand(employeeId, projectId));
            return RedirectToAction("Edit","Project",new {projectId=projectId});
        }

        public ActionResult AddEmplyoeeToProject(Guid employeeId, Guid projectId)
        {
            var query = Query(new AddEmployeeToProjectCommand(employeeId, projectId));
            return RedirectToAction("Edit", "Project", new {projectId = projectId});
        }
    }
}
