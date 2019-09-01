using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingService.Domain
{
	public class ChatMessage
	{
		public Guid ChatId { get; set; }
		public Guid MessageId { get; set; }
		public Chat Chat { get; set; }
		public Message Message { get; set; }
	}
}
