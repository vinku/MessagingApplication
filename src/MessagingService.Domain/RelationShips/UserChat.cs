using System;

namespace MessagingService.Domain
{
	public class UserChat
	{
		public string UserCellId { get; set; }
		public Guid ChatId { get; set; }
		public User User { get; set; }
		public Chat Chat { get; set; }
	}
}
 