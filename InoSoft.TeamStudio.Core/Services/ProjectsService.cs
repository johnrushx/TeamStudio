using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InoSoft.TeamStudio.Core.Entities;

namespace InoSoft.TeamStudio.Core.Services
{
	public class ProjectsService
	{
		public List<Project> GetAllProject()
		{
			using (var manager = new DataManager())
			{
				return manager.Context.Projects.ToList();
			}
		}
		public Project GetProjectAboutId(int ProjectId)
		{
			using (var Manager = new DataManager())
			{
				return Manager.Context.Projects.SingleOrDefault(p => p.ProjectId==ProjectId);
			}
		}
		
		
	}
}
