using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MessagingService.Domain
{
	public class User
	{
		public User()
		{
			this.UserChats = new List<UserChat>();
		}

		public string UserCellId { get; set; }
		public string Name { get; set; }
		public DateTime LastSeenTime { get; set; }
		public List<UserChat> UserChats { get; set; }
	}
}