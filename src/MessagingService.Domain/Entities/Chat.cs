using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingService.Domain
{
	public class Chat
	{
		public Chat()
		{
			this.ChatMessages = new List<ChatMessage>();
			this.UserChats = new List<UserChat>();
		}

		public Guid ChatId { get; set; }
		public DateTime LastActivityTime { get; set; }
		public List<UserChat> UserChats { get; set; }
		public List<ChatMessage> ChatMessages { get; set; }
	}
}