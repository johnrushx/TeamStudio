using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InoSoft.TeamStudio.Core.Entities;

namespace InoSoft.TeamStudio.Core.Services
{
	public class ProjectsService
	{
		public List<Project> GetAllUsers()
		{
			using (var manager = new DataManager())
			{
				return manager.Context.Projects.ToList();
			}
		}
	}
}
