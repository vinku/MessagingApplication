using MessagingService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MessagingService.Data
{
	public class Repository
	{
		private MessaginContext _context;

		public Repository(MessaginContext context)
		{
			_context = context;
			_context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
		}

		public User GetUserFromCellNumber(string cellNumber)
		{
			var user =
				_context.Users
				.FirstOrDefault(s => s.UserCellId == cellNumber);
			return user;
		}

		public User GetUserFromCellNumberWithChats(string cellNumber)
		{
			var user =
				_context.Users
				.Include(u => u.UserChats)
				.FirstOrDefault(u => u.UserCellId == cellNumber);
			return user;
		}

		public void AddNewuser(User user)
		{
			// ToDo : Remove this method and add a save method which would work for both update and creation of new resource.
			_context.Users.Add(user);
			_context.SaveChanges();
		}

		public bool UseridExists(string cellNumber)
		{
			return GetUserFromCellNumber(cellNumber) != null;
		}
	}
}
