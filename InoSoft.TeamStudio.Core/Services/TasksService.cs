using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InoSoft.TeamStudio.Core.Entities;

namespace InoSoft.TeamStudio.Core.Services
{
	public class TasksService
	{

         public Task GetTask (int TaskId)
        {
            using (var Manager = new DataManager())
            {
                return Manager.Context.Tasks.SingleOrDefault(u => u.TaskId == TaskId);
            }
        }

		public List<Task> GetTasksAboutUser(int UserID)
		{
			using (var Manager = new DataManager())
			{
                return Manager.Context.Tasks.Where(u => u.AssigneeId == UserID).ToList();
			}
        }

        public List<Task> GetTasksAboutUser(string UserName)
        {
            using (var Manager = new DataManager())
            {
                return Manager.Context.Tasks.Where(u => u.User.UserName==UserName).ToList();
            }
        }


        public List<Task> GetTasksAboutProject(int ProjectId)
        {
            using (var Manager = new DataManager())
            {
                return Manager.Context.Tasks.Where(u => u.ProjectId == ProjectId).ToList();               
            }
        }

        public List<Task> GetTasksAboutProject(int ProjectId, int UserId)
        {
            using (var Manager = new DataManager())
            {
                return Manager.Context.Tasks.Where(u => u.ProjectId == ProjectId && u.AssigneeId == UserId).ToList();
            }
        }


        public List<Task> GetAllChildrenTasks(int TaskId)
        {
            using (var Manager = new DataManager())
            {
                return Manager.Context.Tasks.Where(u => u.ParentTaskId == TaskId).ToList();
            }
        }


        public void CreateTask(Task NewTask)
        {
            using (var Manager = new DataManager())
            {
                Manager.Context.Tasks.AddObject(NewTask);
                Manager.Context.SaveChanges();
            }
        }


        public void EditTask(Task Task)
        {
            using (var Manager = new DataManager())
            {
                Task EditedTask = new Task { TaskId = Task.TaskId };
                Manager.Context.Tasks.Attach(EditedTask);
                EditedTask.AssigneeId = Task.AssigneeId;
                EditedTask.VersionId = Task.VersionId;
                EditedTask.Description = Task.Description;
                EditedTask.IsFixed = Task.IsFixed;
                EditedTask.Name = Task.Name;
                Manager.Context.SaveChanges();
            }
        }

	}
}
