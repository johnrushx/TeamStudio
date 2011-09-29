using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InoSoft.TeamStudio.Core.Entities;

namespace InoSoft.TeamStudio.Core.Services
{
	public class UsersService
	{
		public List<User> GetAllUsers()
		{
			using (var manager = new DataManager())
			{
				return manager.Context.Users.ToList();
			}
		}

		public User GetUserById(int id)
		{
			using (var manager = new DataManager())
			{
				return manager.Context.Users.SingleOrDefault(u => u.UserId == id);
			}
		}
	}
}
