using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingService.Domain
{
	public class MessageSender
	{
		public Guid MessageId { get; set; }
		public string UserCellId { get; set; }
		public Message Message { get; set; }
		public User Sender { get; set; }
	}
}
