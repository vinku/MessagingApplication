using System;

namespace MessagingService.Domain
{
	public enum MessageStatus
	{
		Waiting = 0,
		Sent = 1,
		Received =2 ,
		Read = 3,
	}

	public class Message
	{
		public Guid MessageId { get; set; }
		public string MessageText { get; set; }
		public MessageStatus Status { get; set; }
		public DateTime SentTime { get; set; }
		public ChatMessage ChatMessage { get; set; }
		public MessageSender MessageSender { get; set; }
	}
}