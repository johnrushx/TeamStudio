using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InoSoft.TeamStudio.Core.Entities;

namespace InoSoft.TeamStudio.Core.Services
{
	public class TasksService
	{
		public List<Task> GetAllUsers()
		{
			using (var manager = new DataManager())
			{
				return manager.Context.Tasks.ToList();
			}
		}
	}
}
