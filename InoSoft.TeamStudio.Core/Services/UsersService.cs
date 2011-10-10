using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InoSoft.TeamStudio.Core.Entities;
using InoSoft.TeamStudio.Core.Helpers;

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

        public void CreateUser(User newUser)
        {
            using (var manager = new DataManager())
            {
                manager.Context.Users.AddObject(newUser);
                manager.Context.SaveChanges();
                MessagesSender Sender = new MessagesSender();
                Sender.Send(newUser);
            }
        }

        public void EditUser(User user)
        {
            using (var manager = new DataManager())
            {
                User editedUser = new User { UserId = user.UserId };
                manager.Context.Users.Attach(editedUser);
                editedUser.FirstName = user.FirstName;
                editedUser.LastName = user.LastName;
                editedUser.UserName = user.UserName;
                editedUser.Email = user.Email;
                manager.Context.SaveChanges();
            }
        }

        public aspnet_Users GetAspUser(string userName)
        {
            using (var manager = new DataManager())
            {
                return manager.Context.aspnet_Users.SingleOrDefault(u => u.UserName == userName);
            }
        }
	}
}
