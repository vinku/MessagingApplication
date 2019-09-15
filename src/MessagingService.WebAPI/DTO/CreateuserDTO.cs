using MessagingService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.WebAPI.DTO
{
	// Represents the information the client needs to send while creating an object.
	public class CreateuserDTO
	{
		public string Name { get; set; }
		public string CellNumber { get; set; }

		//. TODO: automapper can do this.
		public User GetUserFromDTO()
		{
			User user = new User
			{
				Name = Name,
				UserCellId = CellNumber
			};
			return user;
		}
	}
}
