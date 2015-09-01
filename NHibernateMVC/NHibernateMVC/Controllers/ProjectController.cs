using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernateMVC.Domain.Project;
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

            return null;
        }

        [HttpGet]
        public ActionResult Edit(Guid projectId)
        {
            var vm = new ProjectViewModel(Query(new GetProjectQuery(projectId)));
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
    }
}
