using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InoSoft.TeamStudio.Core.Entities;

using InoSoft.TeamStudio.Core.Services;

namespace InoSoft.TeamStudio.Controllers
{
    public class TaskController : Controller
    {
        private TasksService _tasksServise = new TasksService();
        private UsersService _userServise = new UsersService();
        private ProjectsService _projectServise = new ProjectsService();
        private VersionService _versionServise = new VersionService();



        public ViewResult Index()
        {
            string UserName = User.Identity.Name;
            return View(_tasksServise.GetTasksAboutUser(UserName));
        }

        public ActionResult Edit(int TaskId)
        {
            Task Task = _tasksServise.GetTask(TaskId);
            Project Project = _projectServise.GetProjectAboutId(Task.ProjectId);
            Team Team = new Team();
            InoSoft.TeamStudio.Core.Entities.Version Version = _versionServise.GetVersion(Convert.ToInt32(Task.VersionId)); 
            List<User> UsersTeam = new List<Core.Entities.User>();
            UsersTeam = _userServise.GetUsersAboutTeam(Project.TeamId);
            List<string> UsersName = new List<string>();
            foreach (var item in UsersTeam)
            {
                UsersName.Add(item.UserName);
            }
            ViewData["UsersList"] = new SelectList(UsersName);
            ViewData["Project"] = Project.Name;
            ViewData["Version"] = Version.VersionNum;
            return View(Task);
        }

        [HttpPost]
        public ActionResult Edit(Task Task, string UsersList, string Version)
        {
            Task.AssigneeId = _userServise.GetUser(UsersList).UserId;
             InoSoft.TeamStudio.Core.Entities.Version Versions= _versionServise.GetVersion(Version);
             if (Versions != null)
             {
                 Task.VersionId = Versions.VersionId;
             }
             else
             {
                 //create version.....
             }
            if (ModelState.IsValid)
            {
                _tasksServise.EditTask(Task);
                return RedirectToAction("Index");
            }
            return View(Task);
        }
    }
}