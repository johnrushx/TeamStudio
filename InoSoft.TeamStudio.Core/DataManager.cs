using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using InoSoft.TeamStudio.Core.Entities;

namespace InoSoft.TeamStudio.Core
{
	public class DataManager : IDisposable
	{
		private TeamStudioEntities _context = new TeamStudioEntities();

		public TeamStudioEntities Context
		{
			get { return _context; }
			set { _context = value; }
		}

		public void SaveChanges()
		{
			Context.SaveChanges();
		}

		public void Dispose()
		{
			Context.Dispose();
		}
	}
}
